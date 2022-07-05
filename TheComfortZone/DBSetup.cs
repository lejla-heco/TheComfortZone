using Microsoft.EntityFrameworkCore;
using TheComfortZone.SERVICES.DAO;

namespace TheComfortZone
{
    public class DBSetup
    {
        public void Init(TheComfortZoneContext context)
        {
            context.Database.Migrate();
        }

        public void InsertData(TheComfortZoneContext context)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Script", "setup.sql");
            var query = File.ReadAllText(path);
            context.Database.ExecuteSqlRaw(query);
        }

    }
}
