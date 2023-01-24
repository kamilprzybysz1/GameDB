using GameDB.Models;
using Microsoft.EntityFrameworkCore;

namespace GameDB
{
    public class GameContext : DbContext
    {
        public DbSet<GameModel> Games { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptions)
        {
            var cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GameDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";



            dbContextOptions.UseSqlServer(cs);
        }
    }
}
