using HolidayMailer.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HolidayMailer.DataBase
{
    public class HolidayDBContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<EventModel> Events { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlite(connectionString: "FileName=HolidayMailer", option =>
            {
                  option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users", "hm");
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired();
                entity.HasIndex(x => x.Email).IsUnique();
                entity.Property(x => x.Name).HasMaxLength(50).IsRequired();
                entity.Property(x => x.Password).IsRequired();
                //entity.HasMany(x => Events).WithOne(y => y.User).HasForeignKey(c => c.UserId);
            });

            modelBuilder.Entity<EventModel>().ToTable("Events", "hm");
            modelBuilder.Entity<EventModel>(entity =>
            {
                entity.HasKey(x => x.Id);                
                entity.Property(x => x.Name).HasMaxLength(50).IsRequired();
                entity.Property(x => x.TargetEmail).IsRequired();
                entity.Property(x => x.TargetName).IsRequired();
                entity.Property(x => x.UserId).HasColumnType("int");
                entity.Property(x => x.Date).HasColumnType("date");
                //entity.HasOne(x => x.User).WithMany(c => c.Events).HasForeignKey(x => x.UserId);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
