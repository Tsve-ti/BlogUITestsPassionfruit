using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Models
{
    public class LogIn
    {
        private string emailAddress;
        private string password;


        public LogIn
            (
            String emailAddress,
            String password
            )
        {
            this.emailAddress = emailAddress;
            this.password = password;
        }

        public LogIn()
        {
        }

        public string EmailAddress
        {
            get { return this.emailAddress; }
            set { this.emailAddress = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }


    }
}
