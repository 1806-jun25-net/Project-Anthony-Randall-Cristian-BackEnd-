using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZVRPub.API
{
    public class AllUserInfo
    {
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string UserAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserPic { get; set; }
        public bool? LevelPermission { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
