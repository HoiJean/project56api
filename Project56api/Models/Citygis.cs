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

        public virtual DbSet<connections> connections { get; set; }
        public virtual DbSet<positions> positions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<connections>()
                .Property(e => e.port)
                .IsUnicode(false);

            modelBuilder.Entity<positions>()
                .Property(e => e.quality)
                .IsUnicode(false);
        }
    }
}
