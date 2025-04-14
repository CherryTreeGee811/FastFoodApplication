using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace FastFoodAPI.Entities {
    //public class FastFoodDbContext : DbContext {
    public class FastFoodDbContext : IdentityDbContext<Employee> {
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
            base.OnModelCreating(modelBuilder);

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

            // Configure TrainingAssignment composite key
            modelBuilder.Entity<TrainingAssignment>()
                .HasKey(ta => new { ta.EmployeeId, ta.TrainingId });  // composite primary key

            // TrainingAssignment to Employee relationship
            modelBuilder.Entity<TrainingAssignment>()
                .HasOne(ta => ta.Employee)  // training assignment has 1 employee
                .WithMany(e => e.TrainingAssignments)  // employee has many training assignments
                .HasForeignKey(ta => ta.EmployeeId)  // using EmployeeId as the foreign key
                .HasPrincipalKey(e => e.Id)  // explicitly use EmployeeId as the principal key
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
                .WithMany(e => e.ShiftAssignments)  // connect to the existing navigation property
                .HasForeignKey(sa => sa.EmployeeId)  // using EmployeeId as the foreign key
                .HasPrincipalKey(e => e.Id)  // explicitly use EmployeeId as the principal key
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
                    Id = Guid.NewGuid().ToString(),
                    UserName = "john.doe@onlybytes.com",
                    NormalizedUserName = "JOHN.DOE@ONLYBYTES.COM",
                    Email = "john.doe@onlybytes.com",
                    NormalizedEmail = "JOHN.DOE@ONLYBYTES.COM",
                    FirstName = "John",
                    LastName = "Doe",
                    JobTitleId = 1, // Manager
                    StationId = 1  // Management Office
                },
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "sarah.johnson@onlybytes.com",
                    NormalizedUserName = "SARAH.JOHNSON@ONLYBYTES.COM",
                    Email = "sarah.johnson@onlybytes.com",
                    NormalizedEmail = "SARAH.JOHNSON@ONLYBYTES.COM",
                    FirstName = "Sarah",
                    LastName = "Johnson",
                    JobTitleId = 1, // Manager
                    StationId = 1  // Management Office
                },
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "richard.parker@onlybytes.com",
                    NormalizedUserName = "RICHARD.PARKER@ONLYBYTES.COM",
                    Email = "richard.parker@onlybytes.com",
                    NormalizedEmail = "RICHARD.PARKER@ONLYBYTES.COM",
                    FirstName = "Richard",
                    LastName = "Parker",
                    JobTitleId = 1, // Manager
                    StationId = 1  // Management Office
                },
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName  = "amanda.williams@onlybytes.com",
                    NormalizedUserName  = "AMANDA.WILLIAMS@ONLYBYTES.COM",
                    Email = "amanda.williams@onlybytes.com",
                    NormalizedEmail = "AMANDA.WILLIAMS@ONLYBYTES.COM",
                    FirstName = "Amanda",
                    LastName = "Williams",
                    JobTitleId = 1, // Manager
                    StationId = 1  // Management Office
                },

                // Cashiers (7)
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName  = "jane.smith@onlybytes.com",
                    NormalizedUserName  = "JANE.SMITH@ONLYBYTES.COM",
                    Email = "jane.smith@onlybytes.com",
                    NormalizedEmail = "JANE.SMITH@ONLYBYTES.COM",
                    FirstName = "Jane",
                    LastName = "Smith",
                    JobTitleId = 2, // Cashier
                    StationId = 2 // Front Counter
                },
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "michael.brown@onlybytes.com",
                    NormalizedUserName = "MICHAEL.BROWN@ONLYBYTES.COM",
                    Email = "michael.brown@onlybytes.com",
                    NormalizedEmail = "MICHAEL.BROWN@ONLYBYTES.COM",
                    FirstName = "Michael",
                    LastName = "Brown",
                    JobTitleId = 2, // Cashier
                    StationId = 3 // Drive-Thru
                },
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName  = "emily.davis@onlybytes.com",
                    NormalizedUserName  = "EMILY.DAVIS@ONLYBYTES.COM",
                    Email = "emily.davis@onlybytes.com",
                    NormalizedEmail = "EMILY.DAVIS@ONLYBYTES.COM",
                    FirstName = "Emily",
                    LastName = "Davis",
                    JobTitleId = 2, // Cashier
                    StationId = 2 // Front Counter
                },
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "daniel.thompson@onlybytes.com",
                    NormalizedUserName = "DANIEL.THOMPSON@ONLYBYTES.COM",
                    Email = "daniel.thompson@onlybytes.com",
                    NormalizedEmail = "DANIEL.THOMPSON@ONLYBYTES.COM",
                    FirstName = "Daniel",
                    LastName = "Thompson",
                    JobTitleId = 2, // Cashier
                    StationId = 3 // Drive-Thru
                },
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName  = "olivia.rodriguez@onlybytes.com",
                    NormalizedUserName  = "OLIVIA.RODRIGUEZ@ONLYBYTES.COM",
                    Email = "olivia.rodriguez@onlybytes.com",
                    NormalizedEmail = "OLIVIA.RODRIGUEZ@ONLYBYTES.COM",
                    FirstName = "Olivia",
                    LastName = "Rodriguez",
                    JobTitleId = 2, // Cashier
                    StationId = 2 // Front Counter
                },
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "thomas.lee@onlybytes.com",
                    NormalizedUserName = "THOMAS.LEE@ONLYBYTES.COM",
                    Email = "thomas.lee@onlybytes.com",
                    NormalizedEmail = "THOMAS.LEE@ONLYBYTES.COM",
                    FirstName = "Thomas",
                    LastName = "Lee",
                    JobTitleId = 2, // Cashier
                    StationId = 3 // Drive-Thru
                },
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "sophia.patel@onlybytes.com",
                    NormalizedUserName = "SOPHIA.PATEL@ONLYBYTES.COM",
                    Email  = "sophia.patel@onlybytes.com",
                    NormalizedEmail  = "SOPHIA.PATEL@ONLYBYTES.COM",
                    FirstName = "Sophia",
                    LastName = "Patel",
                    JobTitleId = 2, // Cashier
                    StationId = 2 // Front Counter
                },

                // Cooks (7)
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "mike.wilson@onlybytes.com",
                    NormalizedUserName = "MIKE.WILSON@ONLYBYTES.COM",
                    Email = "mike.wilson@onlybytes.com",
                    NormalizedEmail = "MIKE.WILSON@ONLYBYTES.COM",
                    FirstName = "Mike",
                    LastName = "Wilson",
                    JobTitleId = 3, // Cook
                    StationId = 4 // Grill
                },
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "david.garcia@onlybytes.com",
                    NormalizedUserName = "DAVID.GARCIA@ONLYBYTES.COM",
                    Email = "david.garcia@onlybytes.com",
                    NormalizedEmail = "DAVID.GARCIA@ONLYBYTES.COM",
                    FirstName = "David",
                    LastName = "Garcia",
                    JobTitleId = 3, // Cook
                    StationId = 5 // Fryer
                },
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "jessica.martinez@onlybytes.com",
                    NormalizedUserName = "JESSICA.MARTINEZ@ONLYBYTES.COM",
                    Email  = "jessica.martinez@onlybytes.com",
                    NormalizedEmail = "JESSICA.MARTINEZ@ONLYBYTES.COM",
                    FirstName = "Jessica",
                    LastName = "Martinez",
                    JobTitleId = 3, // Cook
                    StationId = 6 // Prep Table
                },
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "james.wilson@onlybytes.com",
                    NormalizedUserName = "JAMES.WILSON@ONLYBYTES.COM",
                    Email  = "james.wilson@onlybytes.com",
                    NormalizedEmail = "JAMES.WILSON@ONLYBYTES.COM",
                    FirstName = "James",
                    LastName = "Wilson",
                    JobTitleId = 3, // Cook
                    StationId = 4 // Grill
                },
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "maria.hernandez@onlybytes.com",
                    NormalizedUserName = "MARIA.HERNANDEZ@ONLYBYTES.COM",
                    Email = "maria.hernandez@onlybytes.com",
                    NormalizedEmail = "MARIA.HERNANDEZ@ONLYBYTES.COM",
                    FirstName = "Maria",
                    LastName = "Hernandez",
                    JobTitleId = 3, // Cook
                    StationId = 5 // Fryer
                },
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "kevin.kim@onlybytes.com",
                    NormalizedUserName = "KEVIN.KIM@ONLYBYTES.COM",
                    Email = "kevin.kim@onlybytes.com",
                    NormalizedEmail= "KEVIN.KIM@ONLYBYTES.COM",
                    FirstName = "Kevin",
                    LastName = "Kim",
                    JobTitleId = 3, // Cook
                    StationId = 6 // Prep Table
                },
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "jennifer.chen@onlybytes.com",
                    NormalizedUserName = "JENNIFER.CHEN@ONLYBYTES.COM",
                    Email = "jennifer.chen@onlybytes.com",
                    NormalizedEmail = "JENNIFER.CHEN@ONLYBYTES.COM",
                    FirstName = "Jennifer",
                    LastName = "Chen",
                    JobTitleId = 3, // Cook
                    StationId = 4 // Grill
                },

                // Cleaners (4)
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "robert.taylor@onlybytes.com",
                    NormalizedUserName = "ROBERT.TAYLOR@ONLYBYTES.COM",
                    Email = "robert.taylor@onlybytes.com",
                    NormalizedEmail = "ROBERT.TAYLOR@ONLYBYTES.COM",
                    FirstName = "Robert",
                    LastName = "Taylor",
                    JobTitleId = 4, // Cleaner
                    StationId = 7 // Dining Area
                },
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "lisa.anderson@onlybytes.com",
                    NormalizedUserName = "LISA.ANDERSON@ONLYBYTES.COM",
                    Email = "lisa.anderson@onlybytes.com",
                    NormalizedEmail = "LISA.ANDERSON@ONLYBYTES.COM",
                    FirstName = "Lisa",
                    LastName = "Anderson",
                    JobTitleId = 4, // Cleaner
                    StationId = 7 // Dining Area
                },
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "carlos.gomez@onlybytes.com",
                    NormalizedUserName = "CARLOS.GOMEZ@ONLYBYTES.COM",
                    Email  = "carlos.gomez@onlybytes.com",
                    NormalizedEmail = "CARLOS.GOMEZ@ONLYBYTES.COM",
                    FirstName = "Carlos",
                    LastName = "Gomez",
                    JobTitleId = 4, // Cleaner
                    StationId = 7 // Dining Area
                },
                new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "emma.wright@onlybytes.com",
                    NormalizedUserName = "EMMA.WRIGHT@ONLYBYTES.COM",
                    Email  = "emma.wright@onlybytes.com",
                    NormalizedEmail = "EMMA.WRIGHT@ONLYBYTES.COM",
                    FirstName = "Emma",
                    LastName = "Wright",
                    JobTitleId = 4, // Cleaner
                    StationId = 7 // Dining Area
                }
            };

            modelBuilder.Entity<Employee>().HasData(employees);

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
                // Create an int index based on the employee's position in the list
                int employeeIndex = employees.IndexOf(employee) + 1; // +1 to start from 1 instead of 0

                // Base training - all employees have food safety
                trainingAssignments.Add(new TrainingAssignment
                {
                    EmployeeId = employee.Id, // Use Id from IdentityUser
                    TrainingId = 1,
                    CompletedTraining = true,
                    DateCompleted = employeeIndex <= 10 ? threeMonthsAgo : lastMonth
                });

                // Customer Service - Managers and Cashiers
                if (employee.JobTitleId == 1 || employee.JobTitleId == 2)
                {
                    trainingAssignments.Add(new TrainingAssignment
                    {
                        EmployeeId = employee.Id, // Use Id from IdentityUser
                        TrainingId = 2,
                        CompletedTraining = employeeIndex != 5 && employeeIndex != 16,
                        DateCompleted = employeeIndex == 5 || employeeIndex == 16 ? null :
                                       (employeeIndex <= 10 ? twoMonthsAgo : lastMonth)
                    });

                    // Cash Handling - Managers and Cashiers
                    trainingAssignments.Add(new TrainingAssignment
                    {
                        EmployeeId = employee.Id, // Use Id from IdentityUser
                        TrainingId = 3,
                        CompletedTraining = employeeIndex != 4 && employeeIndex != 5 &&
                                           employeeIndex != 15 && employeeIndex != 16,
                        DateCompleted = (employeeIndex == 4 || employeeIndex == 5 ||
                                       employeeIndex == 15 || employeeIndex == 16) ? null :
                                       (employeeIndex <= 10 ? twoMonthsAgo : lastMonth)
                    });
                }

                // Cooking Procedures - Managers and Cooks
                if (employee.JobTitleId == 1 || employee.JobTitleId == 3)
                {
                    trainingAssignments.Add(new TrainingAssignment
                    {
                        EmployeeId = employee.Id, // Use Id from IdentityUser
                        TrainingId = 4,
                        CompletedTraining = employeeIndex != 8 && employeeIndex != 20,
                        DateCompleted = employeeIndex == 8 || employeeIndex == 20 ? null :
                                       (employeeIndex <= 10 ? twoMonthsAgo : lastMonth)
                    });
                }

                // Cleaning Standards - Managers and Cleaners
                if (employee.JobTitleId == 1 || employee.JobTitleId == 4)
                {
                    trainingAssignments.Add(new TrainingAssignment
                    {
                        EmployeeId = employee.Id, // Use Id from IdentityUser
                        TrainingId = 5,
                        CompletedTraining = employeeIndex != 10 && employeeIndex != 22,
                        DateCompleted = employeeIndex == 10 || employeeIndex == 22 ? null :
                                       (employeeIndex <= 10 ? twoMonthsAgo : lastMonth)
                    });
                }
            }

            modelBuilder.Entity<TrainingAssignment>().HasData(trainingAssignments);

            // Generate a complete schedule from April 8, 2025 to May 31, 2025
            var shiftAssignments = GenerateShiftSchedule(employees);
            modelBuilder.Entity<ShiftAssignment>().HasData(shiftAssignments);
        }

        /// <summary>
        /// Generates a complete shift schedule from April 8, 2025 to May 31, 2025
        /// by assigning employees to Day, Afternoon, and Night shifts. 
        /// Employees are rotated and assigned based on job title and staffing needs.
        private List<ShiftAssignment> GenerateShiftSchedule(List<Employee> employees) {
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

        /// <summary>
        /// Assigns a specified number of employees to a shift on a given date using a rotating strategy.
        /// </summary>
        /// <param name="date">The date of the shift.</param>
        /// <param name="shiftId">The shift ID (1 = Day, 2 = Afternoon, 3 = Night).</param>
        /// <param name="employees">List of available employees for the job type.</param>
        /// <param name="count">Number of employees to assign.</param>
        /// <returns>A list of shift assignments for the specified shift and date.</returns>
        private List<ShiftAssignment> ScheduleEmployeesForShift(DateTime date, int shiftId, List<Employee> employees, int count) {
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
                    EmployeeId = employee.Id,
                    ShiftId = shiftId,
                    ShiftDate = date
                });
            }

            return assignments;
        }


        /// <summary>
        /// Seeds password and role information for employees using the ASP.NET Identity system.
        /// Employees without a password are assigned a default password and role based on their job title.
        /// </summary>
        /// <param name="serviceProvider">Used to retrieve required scoped services such as UserManager and DbContext.</param>
        public static async Task SeedUsersAsync(IServiceProvider serviceProvider) {
            using var scope = serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Employee>>();
            var dbContext = scope.ServiceProvider.GetRequiredService<FastFoodDbContext>();
            
            // Default password for seeded accounts
            const string defaultPassword = "Password123!";
            
            // Get all seeded employees
            var employees = await dbContext.Employees.ToListAsync();
            
            foreach (var employee in employees)
            {
                // Check if password has already been set
                var passwordSet = await userManager.HasPasswordAsync(employee);
                
                if (!passwordSet)
                {
                    // Set password for the employee
                    await userManager.AddPasswordAsync(employee, defaultPassword);
                    
                    // Optionally add to appropriate roles based on JobTitleId
                    string roleName = employee.JobTitleId switch
                    {
                        1 => "Manager",
                        2 => "Cashier",
                        3 => "Cook",
                        4 => "Cleaner",
                        _ => "Employee"
                    };
                    
                    await userManager.AddToRoleAsync(employee, roleName);
                }
            }
        }

        public static async Task SeedRolesAsync(IServiceProvider serviceProvider) {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles = { "Manager", "Cashier", "Cook", "Cleaner", "Employee" };
            foreach (var role in roles) {
                if (!await roleManager.RoleExistsAsync(role)) {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
