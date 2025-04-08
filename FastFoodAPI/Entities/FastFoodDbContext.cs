using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace FastFoodAPI.Entities
{
    public class FastFoodDbContext : DbContext
    {
        public FastFoodDbContext(DbContextOptions<FastFoodDbContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingAssignment> TrainingAssignments { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ShiftAssignment> ShiftAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // JobTitle to Employee relationship
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.JobTitle)    // employee has 1 job title
                .WithMany()                 // job title has many employees (no navigation property defined)
                .HasForeignKey(e => e.JobTitleId)  // using JobTitleId as the foreign key
                .OnDelete(DeleteBehavior.Restrict); // prevent cascade delete from job title to employees

            // Station to Employee relationship
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Station)     // employee has 1 station (optional)
                .WithMany(s => s.AssignedEmployees)  // station has many assigned employees
                .HasForeignKey(e => e.StationId)  // using StationId as the foreign key
                .IsRequired(false)          // employee can exist without being assigned to a station
                .OnDelete(DeleteBehavior.SetNull); // if station is deleted, set employee's StationId to null

            // Configure Email in Employee to be unique
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.EmailAddress)
                .IsUnique();

            // Configure TrainingAssignment composite key
            modelBuilder.Entity<TrainingAssignment>()
                .HasKey(ta => new { ta.EmployeeId, ta.TrainingId });  // composite primary key

            // TrainingAssignment to Employee relationship
            modelBuilder.Entity<TrainingAssignment>()
                .HasOne(ta => ta.Employee)  // training assignment has 1 employee
                .WithMany(e => e.TrainingAssignments)  // employee has many training assignments
                .HasForeignKey(ta => ta.EmployeeId)  // using EmployeeId as the foreign key
                .OnDelete(DeleteBehavior.Cascade);  // if employee is deleted, delete their training assignments

            // TrainingAssignment to Training relationship
            modelBuilder.Entity<TrainingAssignment>()
                .HasOne(ta => ta.Training)  // training assignment has 1 training
                .WithMany(t => t.TrainingAssignments)  // training has many training assignments
                .HasForeignKey(ta => ta.TrainingId)  // using TrainingId as the foreign key
                .OnDelete(DeleteBehavior.Cascade);  // if training is deleted, delete related assignments

            // Configure default value for CompletedTraining
            modelBuilder.Entity<TrainingAssignment>()
                .Property(ta => ta.CompletedTraining)
                .HasDefaultValue(false);

            // Configure ShiftAssignment composite key
            modelBuilder.Entity<ShiftAssignment>()
                .HasKey(sa => new { sa.EmployeeId, sa.ShiftId, sa.ShiftDate });  // composite primary key including date

            // ShiftAssignment to Employee relationship
            modelBuilder.Entity<ShiftAssignment>()
                .HasOne(sa => sa.Employee)  // shift assignment has 1 employee
                .WithMany()  // employee can have many shift assignments (no navigation property defined)
                .HasForeignKey(sa => sa.EmployeeId)  // using EmployeeId as the foreign key
                .OnDelete(DeleteBehavior.Cascade);  // if employee is deleted, delete their shift assignments

            // ShiftAssignment to Shift relationship
            modelBuilder.Entity<ShiftAssignment>()
                .HasOne(sa => sa.Shift)  // shift assignment has 1 shift
                .WithMany()  // shift can have many assignments (no navigation property defined)
                .HasForeignKey(sa => sa.ShiftId)  // using ShiftId as the foreign key
                .OnDelete(DeleteBehavior.Cascade);  // if shift is deleted, delete the assignments

            // Configure default value for Shift.ShiftPosition
            modelBuilder.Entity<Shift>()
                .Property(s => s.ShiftPosition)
                .HasDefaultValue(ShiftSchedule.Unassigned);

            // Convert Shift from int to string value
            modelBuilder.Entity<Shift>()
                .Property(e => e.ShiftPosition)
                .HasConversion<string>()
                .HasMaxLength(50);

            // Seed JobTitle data
            modelBuilder.Entity<JobTitle>().HasData(
                new JobTitle { JobTitleId = 1, Title = "Manager", Description = "Oversees restaurant operations and staff" },
                new JobTitle { JobTitleId = 2, Title = "Cashier", Description = "Handles customer transactions and orders" },
                new JobTitle { JobTitleId = 3, Title = "Cook", Description = "Prepares food according to restaurant standards" },
                new JobTitle { JobTitleId = 4, Title = "Cleaner", Description = "Maintains cleanliness of the restaurant" }
            );

            // Seed Station data
            modelBuilder.Entity<Station>().HasData(
                new Station { StationId = 1, StationName = "Front Counter", Description = "Main ordering area for customers", IsActive = true },
                new Station { StationId = 2, StationName = "Drive-Thru", Description = "Order processing for drive-thru customers", IsActive = true },
                new Station { StationId = 3, StationName = "Grill", Description = "Main cooking area for burgers and grilled items", IsActive = true },
                new Station { StationId = 4, StationName = "Fryer", Description = "Station for fried food preparation", IsActive = true },
                new Station { StationId = 5, StationName = "Prep Table", Description = "Food assembly and preparation area", IsActive = true },
                new Station { StationId = 6, StationName = "Dining Area", Description = "Customer seating and eating area", IsActive = true }
            );

            // Seed Training data
            modelBuilder.Entity<Training>().HasData(
                new Training { TrainingId = 1, TrainingName = "Food Safety", TrainingDescription = "Basic food handling and safety procedures" },
                new Training { TrainingId = 2, TrainingName = "Customer Service", TrainingDescription = "Effective customer interaction and problem solving" },
                new Training { TrainingId = 3, TrainingName = "Cash Handling", TrainingDescription = "Proper cash register operations and money handling" },
                new Training { TrainingId = 4, TrainingName = "Cooking Procedures", TrainingDescription = "Standard cooking methods for menu items" },
                new Training { TrainingId = 5, TrainingName = "Cleaning Standards", TrainingDescription = "Restaurant cleaning protocols and standards" }
            );

            // Seed Shift data
            modelBuilder.Entity<Shift>().HasData(
                new Shift { ShiftId = 1, ShiftPosition = ShiftSchedule.Day },
                new Shift { ShiftId = 2, ShiftPosition = ShiftSchedule.Afternoon },
                new Shift { ShiftId = 3, ShiftPosition = ShiftSchedule.Night }
            );

            // Seed Employee data with email addresses
            modelBuilder.Entity<Employee>().HasData(
                // Managers (2)
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    EmailAddress = "john.doe@fastfood.com",
                    JobTitleId = 1 // Manager
                    // No station assigned by default for managers
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Sarah",
                    LastName = "Johnson",
                    EmailAddress = "sarah.johnson@fastfood.com",
                    JobTitleId = 1 // Manager
                    // No station assigned by default for managers
                },

                // Cashiers (3) - assigned to Front Counter and Drive-Thru
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Jane",
                    LastName = "Smith",
                    EmailAddress = "jane.smith@fastfood.com",
                    JobTitleId = 2, // Cashier
                    StationId = 1 // Front Counter
                },
                new Employee
                {
                    EmployeeId = 4,
                    FirstName = "Michael",
                    LastName = "Brown",
                    EmailAddress = "michael.brown@fastfood.com",
                    JobTitleId = 2, // Cashier
                    StationId = 2 // Drive-Thru
                },
                new Employee
                {
                    EmployeeId = 5,
                    FirstName = "Emily",
                    LastName = "Davis",
                    EmailAddress = "emily.davis@fastfood.com",
                    JobTitleId = 2, // Cashier
                    StationId = 1 // Front Counter
                },

                // Cooks (3) - assigned to Grill, Fryer, and Prep Table
                new Employee
                {
                    EmployeeId = 6,
                    FirstName = "Mike",
                    LastName = "Wilson",
                    EmailAddress = "mike.wilson@fastfood.com",
                    JobTitleId = 3, // Cook
                    StationId = 3 // Grill
                },
                new Employee
                {
                    EmployeeId = 7,
                    FirstName = "David",
                    LastName = "Garcia",
                    EmailAddress = "david.garcia@fastfood.com",
                    JobTitleId = 3, // Cook
                    StationId = 4 // Fryer
                },
                new Employee
                {
                    EmployeeId = 8,
                    FirstName = "Jessica",
                    LastName = "Martinez",
                    EmailAddress = "jessica.martinez@fastfood.com",
                    JobTitleId = 3, // Cook
                    StationId = 5 // Prep Table
                },

                // Cleaners (2) - assigned to Dining Area
                new Employee
                {
                    EmployeeId = 9,
                    FirstName = "Robert",
                    LastName = "Taylor",
                    EmailAddress = "robert.taylor@fastfood.com",
                    JobTitleId = 4, // Cleaner
                    StationId = 6 // Dining Area
                },
                new Employee
                {
                    EmployeeId = 10,
                    FirstName = "Lisa",
                    LastName = "Anderson",
                    EmailAddress = "lisa.anderson@fastfood.com",
                    JobTitleId = 4, // Cleaner
                    StationId = 6 // Dining Area
                }
            );

            // Seed sample training assignments with completion status and date
            // Create a base date for completed trainings
            var now = DateTime.Now;
            var lastMonth = now.AddMonths(-1);
            var twoMonthsAgo = now.AddMonths(-2);
            var threeMonthsAgo = now.AddMonths(-3);

            modelBuilder.Entity<TrainingAssignment>().HasData(
                // All employees have Food Safety training (completed)
                new TrainingAssignment { EmployeeId = 1, TrainingId = 1, CompletedTraining = true, DateCompleted = threeMonthsAgo },
                new TrainingAssignment { EmployeeId = 2, TrainingId = 1, CompletedTraining = true, DateCompleted = threeMonthsAgo },
                new TrainingAssignment { EmployeeId = 3, TrainingId = 1, CompletedTraining = true, DateCompleted = threeMonthsAgo },
                new TrainingAssignment { EmployeeId = 4, TrainingId = 1, CompletedTraining = true, DateCompleted = threeMonthsAgo },
                new TrainingAssignment { EmployeeId = 5, TrainingId = 1, CompletedTraining = true, DateCompleted = threeMonthsAgo },
                new TrainingAssignment { EmployeeId = 6, TrainingId = 1, CompletedTraining = true, DateCompleted = twoMonthsAgo },
                new TrainingAssignment { EmployeeId = 7, TrainingId = 1, CompletedTraining = true, DateCompleted = twoMonthsAgo },
                new TrainingAssignment { EmployeeId = 8, TrainingId = 1, CompletedTraining = true, DateCompleted = twoMonthsAgo },
                new TrainingAssignment { EmployeeId = 9, TrainingId = 1, CompletedTraining = true, DateCompleted = lastMonth },
                new TrainingAssignment { EmployeeId = 10, TrainingId = 1, CompletedTraining = true, DateCompleted = lastMonth },

                // Managers, Cashiers have Customer Service training
                new TrainingAssignment { EmployeeId = 1, TrainingId = 2, CompletedTraining = true, DateCompleted = twoMonthsAgo },
                new TrainingAssignment { EmployeeId = 2, TrainingId = 2, CompletedTraining = true, DateCompleted = twoMonthsAgo },
                new TrainingAssignment { EmployeeId = 3, TrainingId = 2, CompletedTraining = true, DateCompleted = lastMonth },
                new TrainingAssignment { EmployeeId = 4, TrainingId = 2, CompletedTraining = true, DateCompleted = lastMonth },
                new TrainingAssignment { EmployeeId = 5, TrainingId = 2, CompletedTraining = false, DateCompleted = null },

                // Managers, Cashiers have Cash Handling training
                new TrainingAssignment { EmployeeId = 1, TrainingId = 3, CompletedTraining = true, DateCompleted = twoMonthsAgo },
                new TrainingAssignment { EmployeeId = 2, TrainingId = 3, CompletedTraining = true, DateCompleted = twoMonthsAgo },
                new TrainingAssignment { EmployeeId = 3, TrainingId = 3, CompletedTraining = true, DateCompleted = lastMonth },
                new TrainingAssignment { EmployeeId = 4, TrainingId = 3, CompletedTraining = false, DateCompleted = null },
                new TrainingAssignment { EmployeeId = 5, TrainingId = 3, CompletedTraining = false, DateCompleted = null },

                // Managers, Cooks have Cooking Procedures training
                new TrainingAssignment { EmployeeId = 1, TrainingId = 4, CompletedTraining = true, DateCompleted = twoMonthsAgo },
                new TrainingAssignment { EmployeeId = 2, TrainingId = 4, CompletedTraining = true, DateCompleted = twoMonthsAgo },
                new TrainingAssignment { EmployeeId = 6, TrainingId = 4, CompletedTraining = true, DateCompleted = lastMonth },
                new TrainingAssignment { EmployeeId = 7, TrainingId = 4, CompletedTraining = true, DateCompleted = lastMonth },
                new TrainingAssignment { EmployeeId = 8, TrainingId = 4, CompletedTraining = false, DateCompleted = null },

                // Managers, Cleaners have Cleaning Standards training
                new TrainingAssignment { EmployeeId = 1, TrainingId = 5, CompletedTraining = true, DateCompleted = twoMonthsAgo },
                new TrainingAssignment { EmployeeId = 2, TrainingId = 5, CompletedTraining = true, DateCompleted = twoMonthsAgo },
                new TrainingAssignment { EmployeeId = 9, TrainingId = 5, CompletedTraining = true, DateCompleted = lastMonth },
                new TrainingAssignment { EmployeeId = 10, TrainingId = 5, CompletedTraining = false, DateCompleted = null }
            );

            // Seed sample shift assignments
            // We'll create shifts for the next 7 days
            var today = DateTime.Today;

            // Sample ShiftAssignment data for the next week (just for 5 employees as examples)
            modelBuilder.Entity<ShiftAssignment>().HasData(
                // Manager 1 - Morning shifts for day 1, 3, 5
                new ShiftAssignment { EmployeeId = 1, ShiftId = 1, ShiftDate = today.AddDays(1) },
                new ShiftAssignment { EmployeeId = 1, ShiftId = 1, ShiftDate = today.AddDays(3) },
                new ShiftAssignment { EmployeeId = 1, ShiftId = 1, ShiftDate = today.AddDays(5) },

                // Manager 2 - Afternoon shifts for day 2, 4, 6
                new ShiftAssignment { EmployeeId = 2, ShiftId = 2, ShiftDate = today.AddDays(2) },
                new ShiftAssignment { EmployeeId = 2, ShiftId = 2, ShiftDate = today.AddDays(4) },
                new ShiftAssignment { EmployeeId = 2, ShiftId = 2, ShiftDate = today.AddDays(6) },

                // Cashier 1 - Morning shifts for day 2, 4, 6
                new ShiftAssignment { EmployeeId = 3, ShiftId = 1, ShiftDate = today.AddDays(2) },
                new ShiftAssignment { EmployeeId = 3, ShiftId = 1, ShiftDate = today.AddDays(4) },
                new ShiftAssignment { EmployeeId = 3, ShiftId = 1, ShiftDate = today.AddDays(6) },

                // Cashier 2 - Afternoon shifts for day 1, 3, 5
                new ShiftAssignment { EmployeeId = 4, ShiftId = 2, ShiftDate = today.AddDays(1) },
                new ShiftAssignment { EmployeeId = 4, ShiftId = 2, ShiftDate = today.AddDays(3) },
                new ShiftAssignment { EmployeeId = 4, ShiftId = 2, ShiftDate = today.AddDays(5) },

                // Cook 1 - Night shifts for days 1-6
                new ShiftAssignment { EmployeeId = 6, ShiftId = 3, ShiftDate = today.AddDays(1) },
                new ShiftAssignment { EmployeeId = 6, ShiftId = 3, ShiftDate = today.AddDays(2) },
                new ShiftAssignment { EmployeeId = 6, ShiftId = 3, ShiftDate = today.AddDays(3) },
                new ShiftAssignment { EmployeeId = 6, ShiftId = 3, ShiftDate = today.AddDays(4) },
                new ShiftAssignment { EmployeeId = 6, ShiftId = 3, ShiftDate = today.AddDays(5) },
                new ShiftAssignment { EmployeeId = 6, ShiftId = 3, ShiftDate = today.AddDays(6) }
            );

            base.OnModelCreating(modelBuilder);
        }
                // Schedule for each shift (Day, Afternoon, Night)
    }
}
