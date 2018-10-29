using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppEx.Tools
{
   public class FileHelper
    {
        public static string FindFile(string path)
        {
            try
            {
                string pathfile = Assembly.GetExecutingAssembly().Location + "\\..\\..\\.." + path;
                StreamReader reader = new StreamReader(pathfile);
                string text = reader.ReadToEnd();
                reader.Dispose();
                return text;
            }
            catch (Exception err)
            {
               MessageBox.Show(err.Message);
                return "";
            }
        }
    }
}
