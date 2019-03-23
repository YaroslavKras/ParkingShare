using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingShare
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User();
            user.Name = "TestUser11111";
            user.Email = "test@test.com";
            user.Password = "test";
            user.IsHost = true;
            user.AvailableParkingSpaces = new List<ParkingSpace>();

            var user2 = new User();
            user2.Name = "TestUser22222";
            user2.Email = "te23st@te23st.com";
            user2.Password = "te23st";
            user2.IsHost = true;
            user2.AvailableParkingSpaces = new List<ParkingSpace>();


            var parkingSpace = new ParkingSpace();
            parkingSpace.IsAvailable = true;
            parkingSpace.Owner = user;
            parkingSpace.Number = "1527";

            var parkingSpace2 = new ParkingSpace();
            parkingSpace2.IsAvailable = true;
            parkingSpace2.Owner = user2;
            parkingSpace2.Number = "1112";

            var parkingSpace3 = new ParkingSpace();
            parkingSpace2.IsAvailable = false;
            parkingSpace2.Number = "2342352";
            parkingSpace2.Owner = null;

            user.AvailableParkingSpaces.Add(parkingSpace);
            user.AvailableParkingSpaces.Add(parkingSpace3);
            user2.AvailableParkingSpaces.Add(parkingSpace2);

            var transactionRecord = new TransactionRecord();
            transactionRecord.ParkingSpace = parkingSpace;
            transactionRecord.User = user;

            var transactionRecord2 = new TransactionRecord();
            transactionRecord2.ParkingSpace = parkingSpace2;
            transactionRecord2.User = user;

            SaveUser(user);
            SaveUser(user2);
//            SaveParkingSpace(parkingSpace);
//            SaveParkingSpace(parkingSpace2);
//            SaveTransaction(transactionRecord);
//            SaveTransaction(transactionRecord2);
        }

        private static void SaveUser(User user)
        {
            using (var context = new ParkingShareContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Users.Add(user);
                Console.WriteLine(context.SaveChanges());
            }
        }

        private static void SaveParkingSpace(ParkingSpace parkingSpace)
        {
            using (var context = new ParkingShareContext())
            {
                context.Database.Log = Console.WriteLine;
//                context.Entry(parkingSpace.Owner).State = EntityState.Detached;
                context.ParkingSpaces.Add(parkingSpace);
                Console.WriteLine(context.SaveChanges());
            }
        }

        private static void SaveTransaction(TransactionRecord transactionRecord)
        {
            using (var context = new ParkingShareContext())
            {
                context.Database.Log = Console.WriteLine;
                context.TransactionRecords.Add(transactionRecord);
                Console.WriteLine(context.SaveChanges());
            }
        }
    }
}