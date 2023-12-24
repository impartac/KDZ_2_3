using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Libruary
{
    class Phone
    {
        string _phone = null;
        const string _pattern = "^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$";
        public Phone()
        {
            _phone = "";
        }
        public Phone(string phone)
        {
            if (phone is null)
            {
                throw new ArgumentNullException();
            }
            // Checking for correct phone number. Remove other bad symbols .
            phone = phone.Trim('\"');
            phone = phone.Replace(" ","");
            phone = phone.Replace("№", "");
            phone = Regex.Replace(phone, "доб.[\\d]*", "");
            phone = Regex.Replace(phone, "[A-Za-z:./ А-Яа-я]", "");
            string savephone = string.Copy(phone);
            phone = Regex.Replace(phone, "[()]", "");

            if (Regex.IsMatch(phone, _pattern) || Regex.IsMatch(phone, "(?<!\\d|\\.)\\d\\d(?!\\d|\\.)"))
            {
                _phone = savephone;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        public override string ToString() 
        {
            return _phone;
        }
    }
}
