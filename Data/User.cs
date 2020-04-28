using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class User : ApplicationUser
    {
        [Key]
        public Guid UserId { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
    }
}
