using Core.Constants;
using Core.Models;
using System;

namespace Core
{
    public class Employe : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public int RoleTypeID { get; set; }
        public RoleType Role { get; set; }

        private static int _id;
        public Employe()
        {
            Id = ++_id;
        }
    }
}
