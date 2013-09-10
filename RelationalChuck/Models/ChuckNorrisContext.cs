using System.Data.Entity;
using RelationalChuck.Models.Mapping;

namespace RelationalChuck.Models
{
    public partial class ChuckNorrisContext : DbContext
    {
        static ChuckNorrisContext()
        {
            Database.SetInitializer<ChuckNorrisContext>(null);
        }

        public ChuckNorrisContext()
            : base("Name=ChuckNorrisContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Joke> Jokes { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new JokeMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
        }
    }
}
