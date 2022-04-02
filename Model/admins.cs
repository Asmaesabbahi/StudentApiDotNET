using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class admins
    {
        public int adminsID { get; set; }

        [Required, MaxLength(256)]
        [DataType(DataType.EmailAddress)]
        public string Login { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Login))]
        public string ConfirmLogin { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
