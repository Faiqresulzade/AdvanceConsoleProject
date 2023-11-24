using Core.Constants;
using Core.Models;
using System.Collections.Generic;

namespace Core
{
    public class Employe : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Salary { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public int RoleTypeID { get; set; }
        public RoleType? Role { get; set; }

        public List<Pharamcy>? Pharamcies { get; set; }
    }
}
