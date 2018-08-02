using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZVRPub.API.ModelsNeeded
{
    public class UserModel
    {

        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string UserAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserPic { get; set; }
        public bool? LevelPermission { get; set; }


    }
}
