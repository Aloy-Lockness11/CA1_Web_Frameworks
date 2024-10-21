using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal class Horse
    {
        private String name;
        private String dateOfBirth;
        private int age;
        private int horseID;
        private static int nextID = 0;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public int HorseID
        {
            get { return horseID; }
        }

        public Horse(string name, string dateOfBirth, int age, int horseID)
        {
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.age = age;
            this.horseID = horseID;
        }
    }
}
