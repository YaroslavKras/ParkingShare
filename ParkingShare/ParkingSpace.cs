namespace ParkingShare
{
    public class ParkingSpace
    {
        public int ParkingSpaceId { get; set; }
        public bool IsAvailable { get; set; }
        public string Number { get; set; }
        public User Owner { get; set; }
    }
}