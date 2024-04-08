using LSExtensionWindowLib;
using LSSERVICEPROVIDERLib;
using Patholab_Common;
using Patholab_DAL_V1;
using Patholab_XmlService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Configuration;
using UserControl = System.Windows.Forms.UserControl;


namespace SampleVerfication
{
   

    [ComVisible(true)]
    [ProgId("SampleVerfication.SampleVerficationCls")]
    public partial class SampleVerficationCls : UserControl, IExtensionWindow
    {

        #region Private fields

        private INautilusProcessXML xmlProcessor;
        private IExtensionWindowSite2 _ntlsSite;
        private INautilusServiceProvider sp;
        private INautilusDBConnection _ntlsCon;

        private DataLayer dal;
        public bool DEBUG;
        private string mboxHeader = "מסך אימות דגימה -  Nautilus";







        #endregion

        #region Ctor

        public SampleVerficationCls()
        {
            InitializeComponent();
            BackColor = Color.FromName("Control");
            this.Dock = DockStyle.Fill;

        }

        #endregion



        #region Implementation of IExtensionWindow

        public bool CloseQuery()
        {
            if (dal != null) dal.Close();
            this.Dispose();
            return true;
        }

        public void Internationalise()
        {
        }

        public void SetSite(object site)
        {
            _ntlsSite = (IExtensionWindowSite2)site;

            _ntlsSite.SetWindowInternalName("SampleVerfication");
            _ntlsSite.SetWindowRegistryName("SampleVerfication");
            _ntlsSite.SetWindowTitle("אימות דגימה");
            labelResult.Visible = false;
        }




        public void PreDisplay()
        {

            xmlProcessor = Utils.GetXmlProcessor(sp);

            Utils.GetNautilusUser(sp);

            InitializeData();
            timerFocus.Start();
        }

        public WindowButtonsType GetButtons()
        {
            return LSExtensionWindowLib.WindowButtonsType.windowButtonsNone;
        }

        public bool SaveData()
        {
            return false;
        }

        public void SetServiceProvider(object serviceProvider)
        {
            sp = serviceProvider as NautilusServiceProvider;
            _ntlsCon = Utils.GetNtlsCon(sp);

        }

        public void SetParameters(string parameters)
        {

        }

        public void Setup()
        {

        }

        public WindowRefreshType DataChange()
        {
            return LSExtensionWindowLib.WindowRefreshType.windowRefreshNone;
        }

        public WindowRefreshType ViewRefresh()
        {
            return LSExtensionWindowLib.WindowRefreshType.windowRefreshNone;
        }

        public void refresh()
        {
        }

        public void SaveSettings(int hKey)
        {
        }

        public void RestoreSettings(int hKey)
        {
        }

        public void Close()
        {

        }

        #endregion


        #region Initilaize

        public void InitializeData()
        {


            //    Debugger.Launch();
            try
            {
                dal = new DataLayer();

                if (DEBUG)
                    dal.MockConnect();
                else
                    dal.Connect(_ntlsCon);




            }
            catch (Exception e)
            {


                MessageBox.Show("Error in  InitializeData " + "/n" + e.Message, mboxHeader);
                Logger.WriteLogFile(e);
            }

        }


   



        #endregion


        #region Private methods





        #endregion





        private void SampleVerficationCls_Resize(object sender, EventArgs e)
        {
            lblHeader.Location = new Point(Width / 2 - lblHeader.Width / 2, lblHeader.Location.Y);
            panel1.Location = new Point(Width / 2 - panel1.Width / 2, panel1.Location.Y);
        }


 
        //private void btnExit_Click(object sender, EventArgs e)
        // {
        //    ((Form)this.TopLevelControl).Close();
        //}



        private void textBox1_KeDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                leaveText1();
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2_Leave();
            }   
            
        }
        private void textBox2_Leave(){
                string sql1 = "select sdg_id from lims_sys.sample where name='" + textBox2.Text.Trim().ToUpper() + "'";

                //var sdgDtls = dal.RunQuery(sql1);
                decimal? sdgId = dal.GetDynamicDecimal(sql1);
                if (!(sdgId is null))
                {
                    if (textBox1.Text == textBox2.Text)
                    {

                        if (sdgId != 0)
                        {
                        string sql3 = "Select U_Patholab_Number From lims_sys.sdg_user where SDG_ID='" + sdgId.ToString().Trim().ToUpper() + "'";

                        //var sdgDtls = dal.RunQuery(sql1);
                        string bdika = dal.GetDynamicStr(sql3);
                        labelMisBdika.Text = "מס' הבדיקה:  " + bdika.Trim();
                            string sql2 = "select status from lims_sys.sample where name='" + textBox2.Text.Trim().ToUpper() + "'";
                            string STATUS = dal.GetDynamicStr(sql2);
                            if (STATUS == "X")
                            { // סטטוס בוטל

                                textBox1.Text = "";
                                labelResult.Visible = false;
                                textBox2.Text = "";
                                textBox1.Enabled = true;
                                labelZ1.Visible = false;
                                labelZ2.Visible = false;
                                labelZ1.Text = "";
                                labelZ2.Text = "";
                            labelResult.Visible = true;
                            labelResult.Text = "המקרה בוטל ";
                            labelResult.ForeColor = Color.Red;
                        }
                            else
                            { // עברה
                                dal.InsertToSdgLog((long)sdgId, "Cyt.Ver", (long)_ntlsCon.GetSessionId(), textBox2.Text.Trim().ToUpper() + " אימות העברה");

                                //textBox1.Text = "בדיקת אימות חדשה";
                                labelResult.Visible = true;
                                labelResult.Text = "אימות בוצע ";
                                labelResult.ForeColor = Color.Green;
                                textBox1.Text = "";
                                textBox2.Text = "";
                                textBox1.Enabled = true;
                                labelZ2.Visible = false;
                                labelZ1.Visible = false;

                            }

                        }
                        else
                        {// לא מצא
                         // dal.InsertToSdgLog((long)sdgId, "Cyt.Ver", (long)_ntlsCon.GetSessionId(), "אימות לא העברה");



                            labelResult.Visible = true;
                            labelResult.Text = "ברקוד לא נמצא";
                            labelResult.ForeColor = Color.Red;
                            textBox1.Text = "";
                            textBox2.Text = "";

                            textBox1.Enabled = true;
                            labelZ2.Visible = false;
                            labelZ1.Visible = false;
                            labelZ1.Text = "";
                            labelZ2.Text = "";
                        }

                    }
                    else
                    { // לא זהות
                    string sql5 = "select sdg_id from lims_sys.sample where name='" + textBox1.Text.Trim().ToUpper() + "'";
                    decimal? sdgId5 = dal.GetDynamicDecimal(sql5);
                    dal.InsertToSdgLog((long)sdgId5, "Cyt.Ver", (long)_ntlsCon.GetSessionId(), textBox2.Text.Trim().ToUpper() + "  לבין " + textBox1.Text.Trim().ToUpper() + "  אימות נכשל לבין");

                    labelResult.Visible = true;
                        labelResult.Text = "אימות נכשל ";
                        labelResult.ForeColor = Color.Red;
                        textBox1.Text = "";
                        textBox1.Enabled = true;
                        textBox2.Text = "";
                        labelZ2.Visible = false;
                        labelZ1.Visible = false;
                        // labelZ1.Text = "ברקוד לא תקין";
                        //labelZ2.Text = "ברקוד לא תקין";
                    }
                }
                else
                { // לא מצא צנצנת

                labelResult.Visible = true;
                labelResult.Text = "ברקוד לא נמצא";
                labelResult.ForeColor = Color.Red;
                textBox1.Enabled = true;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    labelZ2.Visible = false;
                    labelZ1.Visible = false;
                    labelZ1.Text = "";
                    labelZ2.Text = "";
                }
            timerFocus.Start();

        }
        //private void textBox1_Leave(object sender, EventArgs e)
        //{
        //    textBox1.Enabled = false;
        //    leaveText1();
        //}
        private void leaveText1()
        {
            
            string sql1 = "select sdg_id from lims_sys.sample where name='" + textBox1.Text.Trim().ToUpper() + "'";

            //var sdgDtls = dal.RunQuery(sql1);
            decimal? sdgId = dal.GetDynamicDecimal(sql1);
            if (!(sdgId is null))
            {
                if (sdgId != 0)
                {
                    string sql3 = "Select U_Patholab_Number From lims_sys.sdg_user where SDG_ID='" + sdgId.ToString().Trim().ToUpper() + "'";

                    //var sdgDtls = dal.RunQuery(sql1);
                    string bdika = dal.GetDynamicStr(sql3);

                    labelMisBdika.Text = "מס' הבדיקה:  " + bdika.Trim();
                    string sql2 = "select status from lims_sys.sample where name='" + textBox1.Text.Trim().ToUpper() + "'";
                    string STATUS = dal.GetDynamicStr(sql2);
                    if (STATUS == "X")
                    { // סטטוס בוטל
                        labelResult.Visible = true;
                        labelResult.Text = "המקרה בוטל ";
                        labelResult.ForeColor = Color.Red;

                        //textBox1.Text = "";
                        labelResult.Visible = false;
                        textBox2.Text = "";
                        //textBox1.Enabled = true;
                        labelZ1.Visible = false;
                        labelZ2.Visible = false;
                        labelZ1.Text = "";
                        labelZ2.Text = "";
                        timerFocus.Start();
                    }
                    else
                    {
                        textBox1.Enabled = false;
                        labelZ1.Visible = false;
                        labelZ2.Visible = false;
                    }
                }

            }
            else
            {
                labelResult.Visible = true;
                labelResult.Text = "ברקוד לא נמצא";
                labelResult.ForeColor = Color.Red;
                //textBox1.Enabled = false;               
                textBox2.Text = "";
                labelZ1.Visible = false;
                labelZ2.Visible = false;
                labelZ1.Text = "";
                timerFocus.Start();
            }
        }
        private void timerFocus_Tick(object sender, EventArgs e)
        {
            

            labelResult.Visible = true;
            labelResult.Text = "בדיקת אימות חדשה";
            labelResult.ForeColor = Color.Black;
            labelZ1.Visible = false;
            labelZ2.Visible = false;
            labelMisBdika.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
            timerFocus.Stop();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2_Leave();
        }
    }
}



