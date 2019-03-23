using System;
using System.Data.Entity;
using System.Data.SqlClient;

namespace ParkingShare
{
    public class ParkingShareContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ParkingSpace> ParkingSpaces { get; set; }
        public DbSet<TransactionRecord> TransactionRecords { get; set; }

        public ParkingShareContext() : base("name=ParkingShareContext")
        {
            SqlConnection.ClearAllPools();
//            Database.ExecuteSqlCommand("ALTER DATABASE ParkingShare SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
            Database.SetInitializer<ParkingShareContext>(new DropCreateDatabaseAlways<ParkingShareContext>());
            Console.WriteLine(Database.Connection.DataSource);
        }

 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingSpace>()
                .HasOptional(p => p.Owner)
                .WithMany(o => o.AvailableParkingSpaces)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TransactionRecord>()
                .HasOptional(a => a.ParkingSpace);

            modelBuilder.Entity<TransactionRecord>()
                .Property(a => a.Id)
                .HasColumnName("TransactionId");

            modelBuilder.Entity<TransactionRecord>()
                .HasOptional(a => a.User);

        }
    }
}