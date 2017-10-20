using Microsoft.EntityFrameworkCore;

namespace TimeSheetManagment.Data
{
    public class TimeSheetManagmentDBContext : DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<TimeSheet> TimeSheet { get; set; }
        public DbSet<UserProfileProject> UserProfileProject { get; set; }
        public TimeSheetManagmentDBContext(DbContextOptions<TimeSheetManagmentDBContext> options)
            :base(options)
        {

        }
       
    }
}
