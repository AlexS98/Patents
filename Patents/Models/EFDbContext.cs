﻿using Patents.Models.Entities;
using System.Data.Entity;

namespace Patents.Models
{
    public class EFDBContext : DbContext
    {
        static EFDBContext()
        {
            Database.SetInitializer<EFDBContext>(new ContextInitializer());
        }
        public EFDBContext() : base("EFDbConnection") { }

        public DbSet<Idea> Ideas { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Inventor> Inventors { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Statement> Statements { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Patent> Patents { get; set; }
    }
}