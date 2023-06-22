using System.Reflection.Emit;
using DeRestaurant.Models.Entitices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Hosting;

namespace DeRestaurant.Models
{
	public partial class DBContext : DbContext
	{
		public DBContext()
		{
		}
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Comment>()
              .HasOne(b => b.bill)
              .WithOne(b => b.comment)
              .HasForeignKey<Comment>(c => c.billid)
            .IsRequired();

            builder.Entity<Comment>()
           .HasMany(e => e.dishes)
           .WithMany(e => e.comments);
        }
    }
}

