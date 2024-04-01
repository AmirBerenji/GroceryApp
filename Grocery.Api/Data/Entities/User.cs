using Grocery.Api.Constants;
using Grocery.Shared.Enumerations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Grocery.Api.Data.Entities
{


    [Table(nameof(User))]
    public class User
    {
        [Key]
        public int Id{ get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        [Required,MaxLength(100)]
        public string Email { get; set; }
        [Required,MaxLength(20)]
        public string Mobile { get; set; }
        public int RoleId { get; set; }
        [Required,MaxLength(25)]
        [Comment("This is just for test")]
        public string  Password { get; set; }


        public virtual Role Role { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        internal static IEnumerable<User> GetInitialUsers =>
            new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "Amir Berenji",
                    Email = "Test@test.com",
                    Mobile = "+37495802393",
                    Password = "123456",
                    RoleId = DatabaseConstants.Roles.Admin.Id,

                }
            };




    }
}
