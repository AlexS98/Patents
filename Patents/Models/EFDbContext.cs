using Patents.Models.Entities;
using System.Data.Entity;

namespace Patents.Models
{
    public class EFDBContext : DbContext
    {
        public EFDBContext() : base ("EFDbConnection")
        {
            Database.SetInitializer(new ContextInitializer());
        }

        public DbSet<Idea> Ideas { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Inventor> Inventors { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Patent> Patents { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}