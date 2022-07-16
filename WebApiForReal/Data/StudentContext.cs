using Microsoft.EntityFrameworkCore;
using WebApiForReal.Models;

namespace WebApiForReal.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> opt): base(opt)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
