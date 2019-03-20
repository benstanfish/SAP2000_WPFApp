using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAP2000v20;
using SAP2000_WFA;

namespace SAP2000_WFA
{
    public partial class Form1 : Form
    {
        private cOAPI sapApp { get; set; }
        private cSapModel aModel { get; set; }


        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonCloseForm_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void ButtonKillSap_Click(object sender, EventArgs e)
        {
            KillSAP(this.sapApp, this.aModel);
        }

        private void KillSAP(cOAPI myApp, cSapModel myModel)
        {
            //close SAP2000
            myApp.ApplicationExit(false);
            myModel = null;
            //mySapObject = null;
        }

        private void StartSAP()
        {
            bool AttachToInstance = false;
            bool SpecifyPath = false;
            string ProgramPath = "C:\\Program Files\\Computers and Structures\\SAP2000 19\\SAP2000.exe";
            string ModelDirectory = "C:\\CSiAPIexample";

            try
            {
                System.IO.Directory.CreateDirectory(ModelDirectory);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not create directory: " + ModelDirectory);
            }

            string ModelName = "API_1-001.sdb";
            //string ModelPath = ModelDirectory + System.IO.Path.DirectorySeparatorChar + ModelName;
            string ModelPath = "C:\\Users\\ben.fisher\\Desktop\\test_model_2.sdb";

            cOAPI mySapObject = null;
            //Use ret to check if functions return successfully (ret = 0) or fail (ret = nonzero)

            int ret = 0;
            if (AttachToInstance)
            {
                //attach to a running instance of SAP2000
                try
                {
                    //get the active SapObject
                    mySapObject = (cOAPI)System.Runtime.InteropServices.Marshal.GetActiveObject("CSI.SAP2000.API.SapObject");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No running instance of the program found or failed to attach.");
                    return;
                }
            }
            else
            {
                //create API helper object
                cHelper myHelper;
                try
                {
                    myHelper = new Helper();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Cannot create an instance of the Helper object");
                    return;
                }

                if (SpecifyPath)
                {
                    //'create an instance of the SapObject from the specified path
                    try
                    {
                        //create SapObject
                        mySapObject = myHelper.CreateObject(ProgramPath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Cannot start a new instance of the program from " + ProgramPath);
                        return;
                    }
                }
                else
                {
                    //create an instance of the SapObject from the latest installed SAP2000
                    try
                    {
                        //create SapObject
                        mySapObject = myHelper.CreateObjectProgID("CSI.SAP2000.API.SapObject");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Cannot start a new instance of the program.");
                        return;
                    }
                }
                //start SAP2000 application
                ret = mySapObject.ApplicationStart(eUnits.kip_in_F,false);
                

            }

            

            //create SapModel object
            cSapModel mySapModel;
            mySapModel = mySapObject.SapModel;

            this.sapApp = mySapObject;
            this.aModel = mySapModel;

            //initialize model
            //ret = mySapModel.InitializeNewModel((eUnits.kip_in_F));

            //create new blank model
            /*
            ret = mySapModel.File.NewBlank();
            

            
            ret = mySapModel.LoadPatterns.Add("Live", eLoadPatternType.Live, 0, true);
            ret = mySapModel.LoadPatterns.Add("Snow", eLoadPatternType.Snow, 0, true);
            ret = mySapModel.LoadPatterns.Add("Other", eLoadPatternType.Other, 0, true);
            


            // ret = mySapModel.LoadPatterns.Count();

            // MessageBox.Show(ret.ToString());
            ret = mySapModel.File.Save("C:\\Users\\ben.fisher\\Desktop\\test_model.sdb");

            int caseCount = mySapModel.LoadPatterns.Count() - 1;
            string[] caseNames = new string[0];
            ret = mySapModel.LoadPatterns.GetNameList(ref caseCount, ref caseNames);

            MessageBox.Show(ret.ToString());
            foreach (string str in caseNames)
            {
                MessageBox.Show(str.ToString());
            }
            */




            var filePath = ReturnFilePath();
            ret = mySapModel.File.OpenFile(filePath);

            // ret = mySapModel.File.OpenFile("C:\\Users\\ben.fisher\\Desktop\\test_model_2.sdb");

            // MessageBox.Show(mySapModel.PropArea.Count().ToString());

            // MessageBox.Show(mySapModel.AreaObj.Count().ToString());



            //foreach(string str in shellNames)
            //{
            //    MessageBox.Show(str);
            //}

            CreateTableFromArray(myString(mySapModel));



            MessageBox.Show("Delayed exit. Press OK to quit.");

        }

        private void ButtonStartSAP_Click(object sender, EventArgs e)
        {
            StartSAP();
            


        }

        public static double[] myString(cSapModel model)
        {
            int ret = 0;
            string[] shellNames = new string[0];
            int shellCount = model.AreaObj.Count();
            string[] shellPressures = new string[0];
            int numItems = 1;
            string[] loadPats = new string[0];
            string[] csys = new string[0];
            int[] direct = new int[0];
            double[] dblVal = new double[0];


            ret = model.AreaObj.GetNameList(ref shellCount, ref shellNames);
            ret = model.AreaObj.SetLoadUniform("16", "ELF", -2.718, 5, true, "Global");
            ret = model.AreaObj.GetLoadUniform("16", ref numItems, ref shellNames, ref loadPats,ref csys,ref direct,ref dblVal);

            return dblVal;
        }


        public void CreateTableFromArray(double[] myStrings)
        {
            DataTable dataTable = new DataTable();
            DataColumn myCol = new DataColumn();
            dataTable.Columns.Add(myCol);
            
            foreach(double str in myStrings)
            {
                dataTable.Rows.Add(str.ToString());
            }

            this.dgvTest.DataSource = dataTable;

        }

        public static string ReturnFilePath()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "c:\\";
                ofd.RestoreDirectory = true;

                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath = ofd.FileName;
                }
            }

            return filePath;
        }


    }
}
