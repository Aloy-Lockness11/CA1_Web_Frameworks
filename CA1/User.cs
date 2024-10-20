using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal abstract class User
    {
        private static int HORSE_OWNER_CREATE_KEY = 11002;
        private static int MANAGER_CREATE_KEY = 11001;
        private String name;
        private String id;
        private String email;
        private String username;
        private String password;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }


        protected User(string name, string id, string email, string username, string password)
        {
            this.name = name;
            this.id = id;
            this.email = email;
            this.username = username;
            this.password = password;
        }

        public abstract bool menu();
    }
}
