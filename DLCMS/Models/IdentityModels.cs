using Microsoft.AspNet.Identity.EntityFramework;

namespace DLCMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("DLCMSUsers").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<ApplicationUser>().ToTable("DLCMSUsers").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityUserRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("DLCMSLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("DLCMSClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("DLCMSRoles");
        }

    }
}