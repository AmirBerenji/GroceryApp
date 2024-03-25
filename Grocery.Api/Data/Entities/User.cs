using Grocery.Shared.Enumerations;
using System.Drawing;

namespace Grocery.Api.Data.Entities
{


    public class User
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int RoleId { get; set; }

        public string  Password { get; set; }


        public virtual Role Role { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
