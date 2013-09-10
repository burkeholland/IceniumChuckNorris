using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RelationalChuck.Models.Mapping
{
    public class JokeMap : EntityTypeConfiguration<Joke>
    {
        public JokeMap()
        {
            // Primary Key
            this.HasKey(t => t.JokeId);

            // Properties
            this.Property(t => t.JokeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.JokeText)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Joke");
            this.Property(t => t.JokeId).HasColumnName("JokeId");
            this.Property(t => t.JokeText).HasColumnName("JokeText");
        }
    }
}
