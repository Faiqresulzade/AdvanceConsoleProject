using System.Collections.Generic;

namespace Core.Models
{
    public class RoleType : BaseModel
    {
        public string RoleName { get; set; }
        public List<Employe> Employes { get; set; }
    }
}
