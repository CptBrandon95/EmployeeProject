using EmployeeProject.Common.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProject.Infrastructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        // A `DbContext` is a class that represents a connection to a database.
        // It is responsible for managing the database connection, querying the database, and saving changes to the database.
        // The DbSet property represents the collection of books in the database.
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Job> Jobs { get; set; }

        /*
         * the constructor is being used to initialize an instance of the ApplicationDbContext class. This constructor takes a parameter of type DbContextOptions<ApplicationDbContext>, named options.
         * The base(options) statement in the constructor is calling the constructor of the base class (presumably DbContext) and passing the options parameter to it.
         * By providing the `DbContextOptions`, the constructor enables, the `ApplicationDbContext` to initialized with specific configuration
         */
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        /*
         * The OnConfiguring method allows the application to establish a connection to the SQLite database when it needs
         * to interact with it.
         * The method is configuring the `DbContextOptionsBuilder` instance to use SQLite as the database provider.
         */

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=EmployeeProject.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>().HasKey(e => e.Id);
            builder.Entity<Employees>().HasKey(e => e.Id);
            builder.Entity<Job>().HasKey(e => e.Id);
            builder.Entity<Team>().HasKey(e => e.Id);

            builder.Entity<Employees>().HasOne(e => e.Address);
            builder.Entity<Employees>().HasOne(e => e.Job);

            builder.Entity<Team>().HasMany(e => e.Employees).WithMany(e => e.Teams);


            base.OnModelCreating(builder);
        }

    }
}