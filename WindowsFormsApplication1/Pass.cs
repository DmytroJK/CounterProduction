using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{  [Serializable]
    class Pass
    {

        public string Login { get; set; }
        public string Password { get; set; }

        public Pass (string login, string password)
        {
            Login = login;
            Password = password;
        }
        public Pass()
        {

        }
    }
}
