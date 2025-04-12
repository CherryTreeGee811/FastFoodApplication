using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

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

            // Seed Station data with new Management Office station
            modelBuilder.Entity<Station>().HasData(
                new Station { StationId = 1, StationName = "Management Office", Description = "Administrative area for restaurant management", IsActive = true },
                new Station { StationId = 2, StationName = "Front Counter", Description = "Main ordering area for customers", IsActive = true },
                new Station { StationId = 3, StationName = "Drive-Thru", Description = "Order processing for drive-thru customers", IsActive = true },
                new Station { StationId = 4, StationName = "Grill", Description = "Main cooking area for burgers and grilled items", IsActive = true },
                new Station { StationId = 5, StationName = "Fryer", Description = "Station for fried food preparation", IsActive = true },
                new Station { StationId = 6, StationName = "Prep Table", Description = "Food assembly and preparation area", IsActive = true },
                new Station { StationId = 7, StationName = "Dining Area", Description = "Customer seating and eating area", IsActive = true }
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

            // Seed Employee data with additional employees to support a full schedule
            var employees = new List<Employee>
            {
                // Managers (4)
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    EmailAddress = "john.doe@onlybytes.com",
                    JobTitleId = 1, // Manager
                    StationId = 1  // Management Office
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Sarah",
                    LastName = "Johnson",
                    EmailAddress = "sarah.johnson@onlybytes.com",
                    JobTitleId = 1, // Manager
                    StationId = 1  // Management Office
                },
                new Employee
                {
                    EmployeeId = 11,
                    FirstName = "Richard",
                    LastName = "Parker",
                    EmailAddress = "richard.parker@onlybytes.com",
                    JobTitleId = 1, // Manager
                    StationId = 1  // Management Office
                },
                new Employee
                {
                    EmployeeId = 12,
                    FirstName = "Amanda",
                    LastName = "Williams",
                    EmailAddress = "amanda.williams@onlybytes.com",
                    JobTitleId = 1, // Manager
                    StationId = 1  // Management Office
                },

                // Cashiers (7)
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Jane",
                    LastName = "Smith",
                    EmailAddress = "jane.smith@onlybytes.com",
                    JobTitleId = 2, // Cashier
                    StationId = 2 // Front Counter
                },
                new Employee
                {
                    EmployeeId = 4,
                    FirstName = "Michael",
                    LastName = "Brown",
                    EmailAddress = "michael.brown@onlybytes.com",
                    JobTitleId = 2, // Cashier
                    StationId = 3 // Drive-Thru
                },
                new Employee
                {
                    EmployeeId = 5,
                    FirstName = "Emily",
                    LastName = "Davis",
                    EmailAddress = "emily.davis@onlybytes.com",
                    JobTitleId = 2, // Cashier
                    StationId = 2 // Front Counter
                },
                new Employee
                {
                    EmployeeId = 13,
                    FirstName = "Daniel",
                    LastName = "Thompson",
                    EmailAddress = "daniel.thompson@onlybytes.com",
                    JobTitleId = 2, // Cashier
                    StationId = 3 // Drive-Thru
                },
                new Employee
                {
                    EmployeeId = 14,
                    FirstName = "Olivia",
                    LastName = "Rodriguez",
                    EmailAddress = "olivia.rodriguez@onlybytes.com",
                    JobTitleId = 2, // Cashier
                    StationId = 2 // Front Counter
                },
                new Employee
                {
                    EmployeeId = 15,
                    FirstName = "Thomas",
                    LastName = "Lee",
                    EmailAddress = "thomas.lee@onlybytes.com",
                    JobTitleId = 2, // Cashier
                    StationId = 3 // Drive-Thru
                },
                new Employee
                {
                    EmployeeId = 16,
                    FirstName = "Sophia",
                    LastName = "Patel",
                    EmailAddress = "sophia.patel@onlybytes.com",
                    JobTitleId = 2, // Cashier
                    StationId = 2 // Front Counter
                },

                // Cooks (7)
                new Employee
                {
                    EmployeeId = 6,
                    FirstName = "Mike",
                    LastName = "Wilson",
                    EmailAddress = "mike.wilson@onlybytes.com",
                    JobTitleId = 3, // Cook
                    StationId = 4 // Grill
                },
                new Employee
                {
                    EmployeeId = 7,
                    FirstName = "David",
                    LastName = "Garcia",
                    EmailAddress = "david.garcia@onlybytes.com",
                    JobTitleId = 3, // Cook
                    StationId = 5 // Fryer
                },
                new Employee
                {
                    EmployeeId = 8,
                    FirstName = "Jessica",
                    LastName = "Martinez",
                    EmailAddress = "jessica.martinez@onlybytes.com",
                    JobTitleId = 3, // Cook
                    StationId = 6 // Prep Table
                },
                new Employee
                {
                    EmployeeId = 17,
                    FirstName = "James",
                    LastName = "Wilson",
                    EmailAddress = "james.wilson@onlybytes.com",
                    JobTitleId = 3, // Cook
                    StationId = 4 // Grill
                },
                new Employee
                {
                    EmployeeId = 18,
                    FirstName = "Maria",
                    LastName = "Hernandez",
                    EmailAddress = "maria.hernandez@onlybytes.com",
                    JobTitleId = 3, // Cook
                    StationId = 5 // Fryer
                },
                new Employee
                {
                    EmployeeId = 19,
                    FirstName = "Kevin",
                    LastName = "Kim",
                    EmailAddress = "kevin.kim@onlybytes.com",
                    JobTitleId = 3, // Cook
                    StationId = 6 // Prep Table
                },
                new Employee
                {
                    EmployeeId = 20,
                    FirstName = "Jennifer",
                    LastName = "Chen",
                    EmailAddress = "jennifer.chen@onlybytes.com",
                    JobTitleId = 3, // Cook
                    StationId = 4 // Grill
                },

                // Cleaners (4)
                new Employee
                {
                    EmployeeId = 9,
                    FirstName = "Robert",
                    LastName = "Taylor",
                    EmailAddress = "robert.taylor@onlybytes.com",
                    JobTitleId = 4, // Cleaner
                    StationId = 7 // Dining Area
                },
                new Employee
                {
                    EmployeeId = 10,
                    FirstName = "Lisa",
                    LastName = "Anderson",
                    EmailAddress = "lisa.anderson@onlybytes.com",
                    JobTitleId = 4, // Cleaner
                    StationId = 7 // Dining Area
                },
                new Employee
                {
                    EmployeeId = 21,
                    FirstName = "Carlos",
                    LastName = "Gomez",
                    EmailAddress = "carlos.gomez@onlybytes.com",
                    JobTitleId = 4, // Cleaner
                    StationId = 7 // Dining Area
                },
                new Employee
                {
                    EmployeeId = 22,
                    FirstName = "Emma",
                    LastName = "Wright",
                    EmailAddress = "emma.wright@onlybytes.com",
                    JobTitleId = 4, // Cleaner
                    StationId = 7 // Dining Area
                }
            };

            modelBuilder.Entity<Employee>().HasData(employees);

            // Add this line to set the proper identity seed value
            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeId)
                .UseIdentityColumn(23, 1); // Start from 23 (after your last seeded ID of 22)

            // Seed sample training assignments with completion status and date
            // Create a base date for completed trainings
            var now = DateTime.Now;
            var lastMonth = now.AddMonths(-1);
            var twoMonthsAgo = now.AddMonths(-2);
            var threeMonthsAgo = now.AddMonths(-3);

            var trainingAssignments = new List<TrainingAssignment>();

            // Food Safety training for all employees
            foreach (var employee in employees)
            {
                // Base training - all employees have food safety
                trainingAssignments.Add(new TrainingAssignment
                {
                    EmployeeId = employee.EmployeeId,
                    TrainingId = 1,
                    CompletedTraining = true,
                    DateCompleted = employee.EmployeeId <= 10 ? threeMonthsAgo : lastMonth
                });

                // Customer Service - Managers and Cashiers
                if (employee.JobTitleId == 1 || employee.JobTitleId == 2)
                {
                    trainingAssignments.Add(new TrainingAssignment
                    {
                        EmployeeId = employee.EmployeeId,
                        TrainingId = 2,
                        CompletedTraining = employee.EmployeeId != 5 && employee.EmployeeId != 16,
                        DateCompleted = employee.EmployeeId == 5 || employee.EmployeeId == 16 ? null :
                                       (employee.EmployeeId <= 10 ? twoMonthsAgo : lastMonth)
                    });

                    // Cash Handling - Managers and Cashiers
                    trainingAssignments.Add(new TrainingAssignment
                    {
                        EmployeeId = employee.EmployeeId,
                        TrainingId = 3,
                        CompletedTraining = employee.EmployeeId != 4 && employee.EmployeeId != 5 &&
                                           employee.EmployeeId != 15 && employee.EmployeeId != 16,
                        DateCompleted = (employee.EmployeeId == 4 || employee.EmployeeId == 5 ||
                                       employee.EmployeeId == 15 || employee.EmployeeId == 16) ? null :
                                       (employee.EmployeeId <= 10 ? twoMonthsAgo : lastMonth)
                    });
                }

                // Cooking Procedures - Managers and Cooks
                if (employee.JobTitleId == 1 || employee.JobTitleId == 3)
                {
                    trainingAssignments.Add(new TrainingAssignment
                    {
                        EmployeeId = employee.EmployeeId,
                        TrainingId = 4,
                        CompletedTraining = employee.EmployeeId != 8 && employee.EmployeeId != 20,
                        DateCompleted = employee.EmployeeId == 8 || employee.EmployeeId == 20 ? null :
                                       (employee.EmployeeId <= 10 ? twoMonthsAgo : lastMonth)
                    });
                }

                // Cleaning Standards - Managers and Cleaners
                if (employee.JobTitleId == 1 || employee.JobTitleId == 4)
                {
                    trainingAssignments.Add(new TrainingAssignment
                    {
                        EmployeeId = employee.EmployeeId,
                        TrainingId = 5,
                        CompletedTraining = employee.EmployeeId != 10 && employee.EmployeeId != 22,
                        DateCompleted = employee.EmployeeId == 10 || employee.EmployeeId == 22 ? null :
                                       (employee.EmployeeId <= 10 ? twoMonthsAgo : lastMonth)
                    });
                }
            }

            modelBuilder.Entity<TrainingAssignment>().HasData(trainingAssignments);

            // Generate a complete schedule from April 8, 2025 to May 31, 2025
            var shiftAssignments = GenerateShiftSchedule(employees);
            modelBuilder.Entity<ShiftAssignment>().HasData(shiftAssignments);

            base.OnModelCreating(modelBuilder);
        }

        private List<ShiftAssignment> GenerateShiftSchedule(List<Employee> employees)
        {
            var assignments = new List<ShiftAssignment>();

            // Start with April 8, 2025 (current day) and go until May 31, 2025
            var startDate = new DateTime(2025, 4, 8);
            var endDate = new DateTime(2025, 5, 31);

            // Group employees by job title
            var managers = employees.Where(e => e.JobTitleId == 1).ToList();
            var cashiers = employees.Where(e => e.JobTitleId == 2).ToList();
            var cooks = employees.Where(e => e.JobTitleId == 3).ToList();
            var cleaners = employees.Where(e => e.JobTitleId == 4).ToList();

            // Create a schedule for each day
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                // Determine day of week (0 = Sunday through 6 = Saturday)
                int dayOfWeek = (int)date.DayOfWeek;
                bool isWeekend = dayOfWeek == 0 || dayOfWeek == 6;

                // Schedule for each shift (Day, Afternoon, Night)
                for (int shiftId = 1; shiftId <= 3; shiftId++)
                {
                    // Staff needed per shift - higher on weekends for busy periods
                    int managersNeeded = 1;
                    int cashiersNeeded = isWeekend ? 3 : 2;
                    int cooksNeeded = isWeekend ? 3 : 2;
                    int cleanersNeeded = 1;

                    // For night shift, need fewer staff
                    if (shiftId == 3) // Night shift
                    {
                        cashiersNeeded = Math.Max(1, cashiersNeeded - 1);
                        cooksNeeded = Math.Max(1, cooksNeeded - 1);
                    }

                    // Assign the appropriate number of employees of each type to the shift
                    assignments.AddRange(ScheduleEmployeesForShift(date, shiftId, managers, managersNeeded));
                    assignments.AddRange(ScheduleEmployeesForShift(date, shiftId, cashiers, cashiersNeeded));
                    assignments.AddRange(ScheduleEmployeesForShift(date, shiftId, cooks, cooksNeeded));
                    assignments.AddRange(ScheduleEmployeesForShift(date, shiftId, cleaners, cleanersNeeded));
                }
            }

            return assignments;
        }

        private List<ShiftAssignment> ScheduleEmployeesForShift(DateTime date, int shiftId, List<Employee> employees, int count)
        {
            var assignments = new List<ShiftAssignment>();
            if (employees.Count == 0 || count == 0) return assignments;

            // Use employee ID modulo operation to assign different employees to different days
            // This creates a rotation system so the same employees don't always work the same days
            var startIndex = ((int)date.DayOfWeek + date.Day + shiftId) % employees.Count;

            for (int i = 0; i < count; i++)
            {
                var employeeIndex = (startIndex + i) % employees.Count;
                var employee = employees[employeeIndex];

                assignments.Add(new ShiftAssignment
                {
                    EmployeeId = employee.EmployeeId,
                    ShiftId = shiftId,
                    ShiftDate = date
                });
            }

            return assignments;
        }
    }
}
