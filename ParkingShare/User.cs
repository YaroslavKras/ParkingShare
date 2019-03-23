using System.Collections.Generic;

namespace ParkingShare
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { set; get; }
        public string Password { get; set; }
        public bool IsHost { get; set; }
        public List<ParkingSpace> AvailableParkingSpaces { get; set; }
    }
}