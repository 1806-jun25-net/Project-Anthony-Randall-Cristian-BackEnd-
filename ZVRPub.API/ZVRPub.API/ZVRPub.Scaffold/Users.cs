using System;
using System.Collections.Generic;

namespace ZVRPub.API
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string UserAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserPic { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
