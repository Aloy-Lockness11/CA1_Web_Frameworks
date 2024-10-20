using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal class RaceCourseManager : User
    {
        private List<RaceDayEvent> raceEventList;

        public RaceCourseManager(string name, string id, string email, string username, string password) : base(name, id, email, username, password)
        {
        }

        public override bool menu()
        {
            throw new NotImplementedException();
        }
    }  
}
