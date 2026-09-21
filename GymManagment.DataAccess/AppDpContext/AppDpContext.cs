using GymManagment.DataAccess.Congigrations;
using GymManagment.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.AppDpContext
{

    public class AppDpContext : DbContext
    {
        #region Properties
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Category> Categores { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Session> sessions { get; set; }
        public DbSet<MemberShip> memberShips { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<HealthRecord> healthRecords { get; set; }


        #endregion

        #region Constructors
        public AppDpContext(DbContextOptions<GymManagement.AppDpContext.AppDpContext> options)  :
            base(options)
        {

        }
        #endregion

        #region Protected Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=GymMangmentMin;Trusted_Connection=true;trustservercertificate=true ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlanConfigration());
            modelBuilder.ApplyConfiguration(new CategoryConfigration());
            modelBuilder.ApplyConfiguration(new UserConfigrations<User>());
            modelBuilder.ApplyConfiguration(new SessionConfigration());
            modelBuilder.ApplyConfiguration(new BoockingConfigrations());
            modelBuilder.ApplyConfiguration(new HealthRecordConfigrations());
            modelBuilder.ApplyConfiguration(new MemberShipConfigration());
     

        }
        #endregion
    }   }

