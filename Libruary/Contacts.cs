using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Libruary
{
    class Contacts
    {
        List<Phone> _phones = new List<Phone>();
        Address _address = new Address();
        List<string> _metrostations = new List<string>();
        public Contacts() { }

        /// <summary>
        /// I remove all unnecessary characters from parts of the table row.
        /// </summary>
        /// <param name="line"> An array of strings, correctly separated by columns.</param>
        /// <exception cref="ArgumentException"> If the line is not correct.</exception>
        public Contacts(string[] line)
        {
            try
            {
                string phones = line[0];
                string address = line[1];
                string metrostations = line[2];


                phones = phones.Replace(";", CsvReading.separator);
                foreach (var v in phones.Split(CsvReading.separator))
                {
                    _phones.Add(new Phone(v));
                }

                
                _address = new Address(address);

                if (!(metrostations is null))
                {
                    metrostations.Trim('\"');
                    foreach (var v in metrostations.Split(CsvReading.separator))
                    {
                        _metrostations.Add(v.Trim());
                    }
                }
                else 
                {
                    _metrostations.Add("");
                }
            }
            catch (Exception) 
            {
                throw new ArgumentException();
            }

        }

        /// <summary>
        /// Depending on the number of numbers and metro stations, the contact output in the line changes.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (_phones.Count > 1 && _metrostations.Count>1)
            {
                return $"\"{string.Join(",", _phones)}\",{_address.ToString()},\"{string.Join(",", _metrostations)}\"";
            }
            if (_phones.Count > 1)
            {
                return $"\"{string.Join(",", _phones)}\",{_address.ToString()},{string.Join(",", _metrostations)}";
            }
            if (_metrostations.Count > 1)
            {
                return $"{string.Join(",", _phones)},{_address.ToString()},\"{string.Join(",", _metrostations)}\"";
            }
            return $"{string.Join(",", _phones)},{_address.ToString()},{string.Join(",", _metrostations)}";
        }
        internal Address GetAddress() 
        {
            return _address is null ? throw new ArgumentNullException():_address;
        }
        internal List<string> Metro() 
        {
            return _metrostations is null?throw new ArgumentNullException():_metrostations;
        }
    }
}