using Microsoft.Win32;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utity;

namespace timetable
{
    public partial class FormMain : Form
    {
        private string timetable { get; set; }
        private int itemCount = 1;
        public FormMain()
        {
            InitializeComponent();

        }
        private void load()
        {
            
            if (Global.Cookie == null || Global.aspxauth == null)
            {
                GUI_login.Text = "登录";
                GUI_refresh.Text = "刷新";
                barLoad.Hide();
                loadText.Hide();
                GUI_tips.Show();
                return;
            }
            else
            {
                GUI_login.Text = "注销";
            }
            GUI_tips.Hide();
            for (int i = 1; i < 31; i++)
            {
                GUI_week.Items.Add(i);
            }

            GUI_refresh.Text = "刷新";
            GUI_semester.Text = Current_semester().Value;
            foreach (KeyValuePair<int, string> s in Global.semester)
            {
                GUI_semester.Items.Add(s.Value);
            }

            timetable = HttpHelp.HttpGet("http://jw.jltc.edu.cn/JWXS/pkgl/XsKB_List.aspx", Global.LoginCookie);
            ShowTimeTable(timetable);
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            GUI_tips.Text = "请先登录";
            //GUI_update.Text = update.server_version();
            GUI_update.Text = "更新";
            if (string.Compare(update.server_version(),Application.ProductVersion.ToString())==0||update.server_version()==null) GUI_update.Hide();
            else GUI_update.Show();
            load();
            /*
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                this.lvkb.BeginInvoke(new Action(() =>
                {
                    barLoad.Value = 1;
                    loadText.Text = "正在准备数据";
                }));
                timetable = HttpHelp.HttpGet("http://jw.jltc.edu.cn/JWXS/pkgl/XsKB_List.aspx", Global.LoginCookie);
                List<List<string>> data = HtmlHelp.GetTable(timetable);
                itemCount = data[0].Count;
                this.lvkb.BeginInvoke(new Action(() =>
                {
                    loadText.Text = "数据准备完毕";
                }));
                Thread.Sleep(1000);
                for (int i = 0; i < barLoad.Maximum; i++)
                {
                    this.lvkb.BeginInvoke(new Action(() =>
                    {
                        barLoad.Value = i;
                    }));
                    Thread.Sleep(10);
                }
                this.lvkb.BeginInvoke(new Action(() =>
                {
                    barLoad.Hide();
                    loadText.Hide();
                    ImageList imgList = new ImageList();
                    imgList.ImageSize = new Size(1, 100);
                    lvkb.SmallImageList = imgList;
                    var itemwidth = this.Width / data[0].Count;
                    List<ListViewItem> table_data = new List<ListViewItem> { };
                    data[0][0] = "";
                    foreach (string s1 in data[0])
                    {
                        lvkb.Columns.Add(s1, itemwidth, HorizontalAlignment.Left);
                    }
                    for (int i = 1; i < data.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(data[i][0], 0);
                        for (int j = 1; j < data[i].Count; j++)
                        {
                            item.SubItems.Add(data[i][j]);
                        }
                        table_data.Add(item);
                    }
                    lvkb.Items.AddRange(table_data.ToArray());
                }));
            });
            */
        }
        /// <summary>
        /// 利用当前日期获取现在所对应得年级
        /// </summary>
        /// <returns> 当前所在年级 </returns>
        private KeyValuePair<int, string> Current_semester()
        {
            int Current_semester;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            Console.WriteLine(year);
            Console.WriteLine(month);
            Current_semester = (int.Parse(year.Substring(2, 2)) - Global.year) * 10;
            if (int.Parse(month) < 9)
            {
                Current_semester += 2;
            }
            else
            {
                Current_semester += 11;
            }

            foreach (KeyValuePair<int, string> s1 in Global.semester)
            {
                if (s1.Key == Current_semester)
                {
                    return s1;
                }
            }

            return new KeyValuePair<int, string>(0, "");
        }
        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            int itemwidth = Width / itemCount;
            if (itemCount > 0)
            {
                foreach (object item in lvkb.Columns)
                {
                    (item as ColumnHeader).Width = itemwidth;
                }
            }
        }
        private void ShowTimeTable(string timetable)
        {

            //lvkb.Clear();
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                lvkb.BeginInvoke(new Action(() =>
                {
                    GUI_tips.Hide();
                    lvkb.Clear();
                    barLoad.Show();
                    loadText.Show();
                    barLoad.Value = 0;
                    loadText.Text = "正在准备数据";
                }));
                //timetable = HttpHelp.HttpGet("http://jw.jltc.edu.cn/JWXS/pkgl/XsKB_List.aspx", Global.LoginCookie);
                List<List<string>> data = HtmlHelp.GetTable(timetable);
                if (data == null)
                {
                    lvkb.BeginInvoke(new Action(() =>
                    {
                        loadText.Text = "数据准备完毕";
                    }));
                    Thread.Sleep(1000);
                    for (int i = 0; i < barLoad.Maximum; i++)
                    {
                        lvkb.BeginInvoke(new Action(() =>
                        {
                            barLoad.Value = i;
                        }));
                        Thread.Sleep(10);

                    }
                    lvkb.BeginInvoke(new Action(() =>
                    {
                        GUI_tips.Text = "检测到当前课表为空";
                        barLoad.Hide();
                        loadText.Hide();
                        GUI_tips.Show();
                    }));
                    return;
                }
                itemCount = data[0].Count;
                lvkb.BeginInvoke(new Action(() =>
                {
                    loadText.Text = "数据准备完毕";
                }));
                Thread.Sleep(1000);
                for (int i = 0; i < barLoad.Maximum; i++)
                {
                    lvkb.BeginInvoke(new Action(() =>
                    {
                        barLoad.Value = i;
                    }));
                    Thread.Sleep(10);
                }
                lvkb.BeginInvoke(new Action(() =>
                {
                    barLoad.Hide();
                    loadText.Hide();
                    ImageList imgList = new ImageList
                    {
                        ImageSize = new Size(1, 100)
                    };
                    lvkb.SmallImageList = imgList;
                    int itemwidth = Width / data[0].Count;
                    List<ListViewItem> table_data = new List<ListViewItem> { };
                    data[0][0] = "";
                    foreach (string s1 in data[0])
                    {
                        lvkb.Columns.Add(s1, itemwidth, HorizontalAlignment.Left);
                    }
                    for (int i = 1; i < data.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(data[i][0], 0);
                        for (int j = 1; j < data[i].Count; j++)
                        {
                            item.SubItems.Add(data[i][j]);
                        }
                        table_data.Add(item);
                    }
                    lvkb.Items.AddRange(table_data.ToArray());
                }));
            });
        }
        private void GUI_refresh_Click(object sender, EventArgs e)
        {

            int key = 0;
            foreach (KeyValuePair<int, string> s in Global.semester)
            {
                if (s.Value == GUI_semester.Text)
                {
                    key = s.Key;
                }
            }

            if (key == 0 || GUI_week.Text == "")
            {
                ShowTimeTable(timetable);
                return;
            }
            string ddlxnxqh = "20" + Convert.ToString(Global.year + (key / 10) - 1) + "-20" + Convert.ToString(Global.year + (key / 10)) + "-" + Convert.ToString(key % 10);
            Dictionary<string, FeildDetail> formdata = new Dictionary<string, FeildDetail>()
            {
                    { "__VIEWSTATE",new FeildDetail() { Xpath="//*[@id='__VIEWSTATE']", ContentType=ContentType.AttributeValue, AttributeKey="value" } },
                 //   { "__EVENTVALIDATION",new FeildDetail() { Xpath="//*[@id='__EVENTVALIDATION']", ContentType=ContentType.AttributeValue, AttributeKey="value" } },

            };
            HtmlHelp.GetBodyInfo(() =>
            {
                return timetable;
            }, formdata, null, "/html/body", "", out Dictionary<string, string> rootvalues, out List<Dictionary<string, string>> rangeValues);
            string __VIEWSTATE = rootvalues["__VIEWSTATE"];
            Dictionary<string, string> pams = new Dictionary<string, string>()
            {
                {"__EVENTTARGET","zc" },
                {"__EVENTARGUMENT","" },
                {"__LASTFOCUS","" },
                { "__VIEWSTATE",rootvalues["__VIEWSTATE"]},
                {"ddlxnxqh",ddlxnxqh },
                {"mx","on" },
                { "zc",GUI_week.Text}
            };
            string html = HttpHelp.HttpPost("http://jw.jltc.edu.cn/JWXS/pkgl/XsKB_List.aspx", Global.LoginCookie, pams);
            ShowTimeTable(html);
        }


        private void GUI_login_Click(object sender, EventArgs e)
        {
            if (GUI_login.Text == "登录")
            {
                while (HttpHelp.Network() == null)
                {
                    var result = MessageBox.Show("网路连接失败请重试", "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (result == DialogResult.No) return;
                }
                FormLogin login = new FormLogin();
                login.ShowDialog();
                // load();
            }
            else
            {
                Global.clear();
                lvkb.Clear();
                GUI_tips.Text = "你当前已退出";
                //load();
            }
            load();
        }

        private void GUI_update_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command\");
            string s = key.GetValue("").ToString();
            System.Diagnostics.Process.Start(s.Substring(0,s.Length-8), "https://www.fallrain.cloud/s/KzfdL3mDRszXxHZ");
        }
    }
}
