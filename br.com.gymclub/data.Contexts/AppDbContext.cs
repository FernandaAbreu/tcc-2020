using System;
using domain.models;
using EntityConfiguration;
using helpers;
using Microsoft.EntityFrameworkCore;

namespace data.Contexts
{
    public class AppDbContext : DbContext
    {
        private readonly IPasswordManager _passwordManager;
        public AppDbContext(DbContextOptions<AppDbContext> options, IPasswordManager passwordManager) : base(options)
        {
            _passwordManager = passwordManager;
        }

        public AppDbContext()
        {
        }

        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<ClassType> ClassType { get; set; }
        public DbSet<DaysWeek> DaysWeek { get; set; }
        public DbSet<PlanType> PlanType { get; set; }
        public DbSet<TypePayment> TypePayment { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Physiotherapist> Physiotherapist { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<ClassRoom> ClassRoom { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<LessonsClient> lessonsClient { get; set; }
        public DbSet<Evaluation> Evaluation { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new StateConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new ClassTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DaysWeekConfiguration());
            modelBuilder.ApplyConfiguration(new PlanTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TypePaymentConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration(_passwordManager));
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new InstructorConfiguration());
            modelBuilder.ApplyConfiguration(new PhysiotherapistConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new ClassRoomConfiguration());
            modelBuilder.ApplyConfiguration(new LeessonClientConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new EvaluationConfiguration());
            

        }

        public static DbContext GetContexto()
        {
            return new AppDbContext();
        }
    }
}
