namespace ParkingShare
{
    public class TransactionRecord
    {
        public int Id { get; set; }
        public User User { get; set; }
        public ParkingSpace ParkingSpace { get; set; }
    }
}