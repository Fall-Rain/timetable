using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Utity;
namespace timetable
{
    public partial class FormLogin : Form
    {
        public string login { get; set; }
        public FormLogin()
        {
            InitializeComponent();
        }

        private string NewFile()
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string newPath = System.IO.Path.Combine(path, "timetable");
            System.IO.Directory.CreateDirectory(newPath);
            return System.IO.Path.Combine(newPath, "user.json");
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

            //IConfiguration config = new ConfigurationBuilder()
            //      .SetBasePath(Directory.GetCurrentDirectory())
            //      .AddJsonFile("app.json", optional: true, reloadOnChange: true)
            //      .Build();
            IConfiguration config = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile(Global.FileUrl, optional: true, reloadOnChange: true)
                  .Build();
            UserSecret userSecret = new UserSecret();
            config.Bind(userSecret);
                GUI_User_Name.Text = userSecret.UserName;
                GUI_User_Pwd.Text = userSecret.PassWord?.DecryptDES();
                GUI_rememberpassword.Checked = userSecret.RememberPassword;
            string sourcepass = userSecret.UserName;
            login = HttpHelp.HttpGet("http://jw.jltc.edu.cn/", out string cookie);
            Global.Cookie = cookie;
            GetVerfyCode();
        }
        private void GetVerfyCode()
        {
            byte[] imgbytes = HttpHelp.GetImg("http://jw.jltc.edu.cn/other/CheckCode.aspx?datetime=az", Global.Cookie);
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(imgbytes, 0, imgbytes.Length);
                ms.Seek(0, SeekOrigin.Begin);
                verfyCodeImg.Image = new Bitmap(ms);
            }
        }

        private void verfyCodeImg_Click(object sender, EventArgs e)
        {
            GetVerfyCode();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            Global.userid = GUI_User_Name.Text;
            Dictionary<string, FeildDetail> formdata = new Dictionary<string, FeildDetail>()
            {
                    { "__VIEWSTATE",new FeildDetail() { Xpath="//*[@id='__VIEWSTATE']", ContentType=ContentType.AttributeValue, AttributeKey="value" } },
                    { "__EVENTVALIDATION",new FeildDetail() { Xpath="//*[@id='__EVENTVALIDATION']", ContentType=ContentType.AttributeValue, AttributeKey="value" } },

            };
            HtmlHelp.GetBodyInfo(() => login, formdata, null, "/html/body", "", out Dictionary<string, string> rootvalues, out List<Dictionary<string, string>> rangeValues);
            Dictionary<string, string> pams = new Dictionary<string, string>()
            {
                    { "__VIEWSTATE",rootvalues["__VIEWSTATE"]},
                    { "__EVENTVALIDATION",rootvalues["__EVENTVALIDATION"]},
                    { "Account",Global.userid},
                    { "PWD",GUI_User_Pwd.Text},
                    { "CheckCode",GUI_verfyCode.Text},
                    { "cmdok",""}
            };
            Global.aspxauth = HttpHelp.LoginGetSessin("http://jw.jltc.edu.cn/login.aspx", pams, cookie: Global.Cookie);
            if (string.IsNullOrEmpty(Global.LoginCookie))
            {
                MessageBox.Show("用户名/密码/验证码错误");
                return;
            }
                UserSecret userSecret = new UserSecret
                {
                    UserName = GUI_User_Name.Text,
                    //PassWord = GUI_User_Pwd.Text?.EncryptDES(),
                    PassWord = GUI_rememberpassword.Checked ? GUI_User_Pwd.Text?.EncryptDES() : "",
                    RememberPassword = GUI_rememberpassword.Checked ? true : false
                };
                string jsonstr = userSecret.ToJson();
                File.Delete(Global.FileUrl);
                using (FileStream fs = new FileStream(Global.FileUrl, FileMode.CreateNew))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(jsonstr);
                    }
                }
            Hide();

            //FormMain fm = new FormMain();
            //var result = fm.ShowDialog();
            //if (result == DialogResult.Cancel)
            //{
            //    Application.Exit();
            //}
        }
        private void selectall(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                (sender as TextBox).SelectAll();
            });
        }
    }
}
