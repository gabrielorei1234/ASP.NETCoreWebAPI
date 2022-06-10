using Microsoft.EntityFrameworkCore;
using MimicAPI_5.Model;

namespace MimicAPI_5.Database
{
    public class MimicContext : DbContext
    {
        public MimicContext(DbContextOptions<MimicContext> options) : base(options) 
        {

        }

        public DbSet<Palavra> Palavras { get; set; }
    }
}
