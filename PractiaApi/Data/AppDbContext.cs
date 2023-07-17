using Microsoft.EntityFrameworkCore;
using PractiaApi.Model;

namespace PractiaApi.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Pacient> Pacients { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<HospitalService> HospitalServices{ get; set; }

        protected override void OnModelCreating(ModelBuilder m)
        {
            m.Entity<HospitalService>().HasKey(hs => new { hs.HospitalId, hs.ServiceId });
            m.Entity<HospitalService>().HasOne(hs => hs.Hospital).WithMany(h => h.HospitalServices).HasForeignKey(hs => hs.HospitalId);
            m.Entity<HospitalService>().HasOne(hs => hs.Service).WithMany(h => h.HospitalServices).HasForeignKey(hs => hs.ServiceId);

        }

    }
}
