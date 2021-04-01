using System;
using System.Collections.Generic;

namespace Model
{
    public class Global
    {
        public static Dictionary<int, string> semester = new Dictionary<int, string>()
        {
            {11,"大一上学期"},{12,"大一下学期"},{21,"大二上学期"},
            {22,"大二下学期" },{31,"大三上学期"},{32,"大三下学期"}
        };
        private static string url
        {
            get
            {
                string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string newPath = System.IO.Path.Combine(path, "timetable");
                System.IO.Directory.CreateDirectory(newPath);
                return newPath;
                
            }
        }


        public static string FileUrl 
        { 
            get
            {
                return System.IO.Path.Combine(url, "user.json");
            }
        }

        public static string Cookie { get; set; }
        public static string aspxauth { get; set; }
        public static string userid { get; set; }
        public static void clear()
        {
            Cookie = null;
            aspxauth = null;
            userid = null;

        }
        public static int year
        {
            get
            {
                if (userid == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(userid.Substring(0, 2));
                }
            }
        }
        public static string LoginCookie
        {
            get
            {
                if (!string.IsNullOrEmpty(Global.Cookie) && !string.IsNullOrEmpty(Global.aspxauth))
                {
                    string[] cookies = Global.Cookie.Split(";");
                    string[] aspxauths = Global.aspxauth.Split(";");
                    if (cookies.Length > 0 && aspxauths.Length > 0)
                    {
                        return string.Concat(cookies[0], ";", aspxauths[0]);
                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    return null;
                }
            }
        }




    }
}
