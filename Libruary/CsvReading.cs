using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libruary
{
    public static class CsvReading
    {
        public static string header = "number,fullname,phones,address,metrostations";
        public static string separator = ",";

        public static List<Notary> Read(string href)
        {
            if (href is null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                List<Notary> contacts = new List<Notary>();
                string[] lines = File.ReadAllLines(href);
                string headerfile  = lines[0];
                if (header != headerfile) 
                {
                    throw new FileLoadException();
                }
                foreach (string line in lines.Skip(1))
                {
                    string[] temp;
                    try
                    {
                        temp = ReadLine(line);
                    }
                    catch 
                    {
                        throw new ArgumentException();
                    }
                    contacts.Add(new Notary(temp));
                }
                return contacts;
            }
            catch (Exception e)
            {
    
                throw new FileLoadException();
            }
        }
        /// <summary>
        /// Replace incorrect chars. Split by separator. Then concatenation strings to get correct dadta strings .
        /// </summary>
        /// <param name="line"> Data string .</param>
        /// <returns> Correct for reading data string .</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private static string[] ReadLine(string line)
        {
            if (line is null) 
            {
                throw new ArgumentNullException();
            }
            List<List<string>> lines = new List<List<string>>();
            line=line.Replace("\"\"", "");
            string[] temp = line.Split(CsvReading.separator);
            int start = -1;
            int end = -1;
            string[] ans =  new string[5];
            for ( int i = 0; i < temp.Length; i++ ) 
            {
                if (string.IsNullOrEmpty(temp[i]))
                {
                    lines.Add(new List<string> { "" });
                }
                else
                {
                    if (temp[i][0] == '\"')
                    {
                        start = i;
                    }
                    else
                    {
                        if (temp[i].EndsWith('"'))
                        {
                            end = i + 1;
                            lines.Add(temp[start..end].ToList<string>());
                            start = -1;
                            end = -1;
                        }
                        else
                        {
                            if (start == -1)
                            {
                                lines.Add(new List<string> { temp[i] });
                            }
                        }
                    }
                }
            }
            int k = 0;
            foreach (List<string> i in lines) 
            {
                string tempans = "";
                if (i.Count != 1)
                {
                    foreach (var j in i)
                    {

                        tempans += j.Trim('"') + ",";
                    }
                    ans[k] = tempans.Trim(',');
                }
                else 
                {
                    ans[k] = i[0];
                }
                k++;
            }
            return ans;

        }
    }
}
