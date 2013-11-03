using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Infrastructure.Data.MainModule.Models.Mapping;

namespace Infrastructure.Data.MainModule.Models
{
    public partial class ClientApiContext : DbContext
    {
        static ClientApiContext()
        {
            Database.SetInitializer<ClientApiContext>(null);
        }

        public ClientApiContext()
            : base("Name=ClientApiContext")
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
        }
    }
}
