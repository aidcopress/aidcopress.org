using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aidcopress.org.Domain.Entities.Users
{
    public class User
    {
        public int Id { get; set; } 
        public string Fname { get; set; }    
        public string Lname { get; set; }   
        public string Username { get; set; }    
        public string Password { get; set; }
        public bool IsActive { get; set; }
        

        public ICollection<UserInRole> UserInRoles { get; set; }


    }
}
