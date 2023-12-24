using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Libruary
{
    public static class CsvSaving
    {
        public static void SaveNew(string href,List<string> notarys) 
        {
            try 
            {
                if (Path.GetExtension(href)!=".csv") 
                {
                    throw new Exception();
                }
                notarys.Insert(0,CsvReading.header);
                File.WriteAllLines(href,notarys);
            }
            catch (Exception)
            {
                throw new FileLoadException();
            }
        }
        public static void Add(string href, List<string> notarys)
        {
            try
            {
                if (!File.Exists(href) || Path.GetExtension(href) != ".csv")
                {
                    throw new FileNotFoundException();
                }
                File.AppendAllLines(href, notarys);
            }
            catch (Exception)
            {
                throw new FileLoadException();
            }
        }
        public static void Resave(string href, List<string> notarys)
        {
            try
            {
                if (!File.Exists(href) || Path.GetExtension(href) != ".csv") 
                {
                    throw new FileNotFoundException();
                }
                notarys.Insert(0, CsvReading.header);
                File.WriteAllLines(href, notarys);
            }
            catch (Exception)
            {
                throw new FileLoadException();
            }
        }
        
    }
}
