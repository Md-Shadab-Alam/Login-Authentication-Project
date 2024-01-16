using Full_Stack_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Full_Stack_Project.Data_Access_Layer
{
    public class FullStackDBContext : DbContext
    {
        public FullStackDBContext(DbContextOptions<FullStackDBContext> options) : base(options)
        {
            
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<LoginUser> LoginUser{ get; set; }
    }
}
