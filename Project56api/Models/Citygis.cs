namespace Project56api.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Citygis : DbContext
    {
        public Citygis()
            : base("name=Citygis")
        {
        }

        public DbSet<connections> connections { get; set; }
        public DbSet<positions> positions { get; set; }

        public System.Data.Entity.DbSet<Project56api.Models.Event> Events { get; set; }

        public System.Data.Entity.DbSet<Project56api.Models.Monitor> Monitors { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<connections>()
        //        .Property(e => e.Port)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<positions>()
        //        .Property(e => e.quality)
        //        .IsUnicode(false);
        //}
    }
}
