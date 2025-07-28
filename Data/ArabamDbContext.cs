using ArabaSatis.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace ArabaSatis.Data
{
    public class ArabamDbContext:DbContext
    {

        public ArabamDbContext(DbContextOptions<ArabamDbContext> options):base(options)
            {




        }

        public DbSet<Markalar>?Markalars { get; set; }

        public DbSet<YakitEkle>? Yakits { get; set; }

        public DbSet<SeriModel>? SeriModels { get; set; }
        public DbSet<ArabaResim>? ArabaResims { get; set; }
        public object ArabaResim { get; internal set; }
    }
}
