using _341_Backend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _341_Backend.Domain.Entities
{
    public class User: BaseEntity
    {
        public String Name { get; set; }
        public String LastName { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String EMail { get; set; }
        public String AcademicRole { get; set; }
    }
}
