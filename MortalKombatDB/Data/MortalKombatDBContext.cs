using Microsoft.EntityFrameworkCore;
using MortalKombatDB.Models;

namespace MortalKombatDB.Data
{
	//Use of Open/Close Solid Principle. Creates a new class with features, and will inherite the base class.
	public class MortalKombatDBContext : DbContext
    {

        public DbSet<Character> Characters { get; set; }
        public DbSet<Move> Moves { get; set; }

        public string DbPath { get; }

        public MortalKombatDBContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "mortalkombat.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
