using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniLibrary.DAL.Entity;

namespace MiniLibrary.DAL.Context
{
    public class MiniLibraryDbContext : IdentityDbContext<User>
    {
        public MiniLibraryDbContext(DbContextOptions<MiniLibraryDbContext> options) :
            base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
        }
    }
}
