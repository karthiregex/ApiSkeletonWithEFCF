using DatingApp.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.DataLayer
{
    public class DatingAppDbContext : IdentityDbContext<UserMaster>
    {
        public DatingAppDbContext(DbContextOptions<DatingAppDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// Seed and create DbSet for all Dating App classes
        /// </summary>
        
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<LoginHistoy> LoginHistoys { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Profile>().HasKey(x => x.ProfileId);
            builder.Entity<LoginHistoy>().HasKey(x => x.LoginTransId);
            builder.Entity<FeedBack>().HasKey(x => x.FeedbackId);
            base.OnModelCreating(builder);
        }
    }
}
