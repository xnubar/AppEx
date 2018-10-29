using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppEx.Tools
{
   public class HtmlParser
    {
        public static string InsertInto(char ch, string html)
        {
            try
            {
                Randomizer.NextRandom();
                string key = Randomizer.RandomKey;
                int index = html.IndexOf(ch);
                return html.Substring(0, index) + key + html.Substring(index + 1, html.Length - (index + 1));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return "";
            }
        }

    
    }
}
