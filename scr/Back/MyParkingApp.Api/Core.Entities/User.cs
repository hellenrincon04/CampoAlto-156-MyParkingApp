using System;

namespace Core.Entities
{
    public class RoleUser
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }


    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public CustomerLevelType CustomerLevel { get; set; }
        public PlatformType Platform { get; set; }
        public string Password { get; set; }
        public string CellPhone { get; set; }
    }
}
