using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libruary
{
    public class Notary
    {
        int _number = -1;
        string _fullName;
        Contacts _contacts;
        public Notary(string[] line)
        {
            _number = int.Parse(line[0]);
            _fullName = line[1];
            _contacts = new Contacts(line[2..]);
        }
        public Notary() { }
        public override string ToString()
        {
            return $"{_number},{string.Join(" ", _fullName)},{_contacts.ToString()}";
        }
        public int Number 
        {
            get { return _number; }
        }
        public string Name 
        { 
            get { return _fullName is null?throw new ArgumentNullException():_fullName; } 
        }
        public List<string> GetMetro() 
        {
            try
            {
                return _contacts.Metro();
            }
            catch (Exception) 
            {
                throw new ArgumentNullException();
            }
        }
        public string GetStreet() 
        {
            try 
            {
                return _contacts.GetAddress().Street;
            }
            catch (Exception) 
            {
                throw new ArgumentNullException();
            }
        }
    }
}
