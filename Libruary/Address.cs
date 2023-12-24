using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Libruary
{
    class Address
    {
        int _postcode=0;
        string _street="";
        // _building contains other information about address.
        List<string> _building = new List<string> { };
        public Address()
        {
            _postcode = 0;
            _street = "";
            _building = new List<string> { "" };
        }
        public Address(string field)
        {
            field = field.Trim('\"');
            string[] parts = field.Split(CsvReading.separator);
            try
            {
                // If address contains the post code, then I accept it. Else I start from street and other it is buildings.
                if (int.TryParse(parts[0], out _postcode))
                {
                    _street = parts[1].Trim();
                    foreach (var v in parts.Skip(2))
                    {
                        _building.Add(v.Trim());
                    }
                }
                else 
                {
                    _street = parts[0].Trim();
                    foreach (var v in parts.Skip(1))
                    {
                        _building.Add(v.Trim());
                    }
                }
            }
            catch (Exception)
            {
                throw new ArgumentNullException();
            }
        }

        public override string ToString() 
        {
            return $"\"{_postcode}, {_street}, {string.Join(CsvReading.separator,_building)}\"";
        }
        internal string Street 
        {
            get { return _street is null ? throw new ArgumentNullException():_street ; }
        }
    }
}
