using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Libruary
{
    public static class CsvProcessing
    {
        /// <summary>
        /// I check "metrostations" with Array.Contains() because notary can have several metro.
        /// </summary>
        /// <param name="data"> List of notary from dataset. </param>
        /// <param name="samplestring"> String by which the sample is taken. </param>
        /// <param name="fieldName"> Name of column for sample. </param>
        /// <returns> List of strings satisfying the sample. </returns>
        /// <exception cref="ArgumentException"></exception>
        public static List<string> Sample(List<Notary> data, string? samplestring, string fieldName)
        {
            if (data is null || samplestring is null || fieldName is null) 
            {
                throw new ArgumentNullException();
            }
            List<string> ans = new List<string>();
            foreach (Notary notary in data) 
            {
                if (fieldName == "fullname") 
                {
                    if (notary.Name ==samplestring) 
                    {
                        ans.Add(notary.ToString());
                    }
                }
                else
                {
                    if (fieldName == "metrostations")
                    {
                        if (notary.GetMetro().Contains(samplestring))
                        {
                            ans.Add(notary.ToString());
                        }
                    }
                    else 
                    {
                        throw new ArgumentException();
                    }
                }
            }
            return ans;
        }

        public static List<string> SortIn(List<Notary> data,bool reverse) 
        {
            if (data is null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                List<string> ans = new List<string> { };
                // Bool reverse affects on data sort .
                foreach (Notary notary in (reverse ? data.OrderBy(x => x.GetStreet()).Reverse<Notary>() : data.OrderBy(x => x.GetStreet())))
                {
                    ans.Add(notary.ToString());
                }
                return ans;
            }
            catch (Exception) 
            {
                throw new ArgumentException();
            }
        }
        public enum DisplayMode
        {
            Top,
            Bottom,
        }

        public static List<string> GetNStrings(List<Notary> data, DisplayMode mode, int N) 
        {
            if (data is null)
            {
                throw new ArgumentNullException();
            }
            List<string> ans= new List<string>{ };
            // Check correct N .
            if (!(1<N && N<=data.Count())) 
            {
                throw new ArgumentOutOfRangeException();
            }
            switch (mode)
            {
                case (DisplayMode.Top):
                    {
                        for (int i = 0; i < N; i++)
                        {
                            ans.Add(data[i].ToString());
                        }
                        return ans;
                    }
                case (DisplayMode.Bottom): 
                    {
                        for (int i = N-1; i >=0; i--)
                        {
                            ans.Add(data[i].ToString());
                        }
                        ans.Reverse();
                        return ans;
                    }
                default: 
                    {
                        throw new ArgumentException();
                    }
            }
            
        }
    }
}
