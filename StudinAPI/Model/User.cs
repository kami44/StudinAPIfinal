using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudinAPI.Model
{
    public class User
    {
        private int _id;
        private int _scannerkey;
        private string _username;
        private string _password;
        private string _salt;
        private string _firstname;
        private string _lastname;
        private string _email;
        private int _phone;
        private int _accesslevel;

        public User(int id, int scannerkey, string username, string password, string salt, string firstname, string lastname, string email, int phone, int accesslevel)
        {
            Id = id;
            Scannerkey = scannerkey;
            Username = username;
            Password = password;
            Salt = salt;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Phone = phone;
            Accesslevel = accesslevel;
        }
        public User() { }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Scannerkey
        {
            get { return _scannerkey; }
            set { _scannerkey = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Salt
        {
            get { return _salt; }
            set { _salt = value; }
        }

        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public int Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public int Accesslevel
        {
            get { return _accesslevel; }
            set { _accesslevel = value; }
        }
    }
}
