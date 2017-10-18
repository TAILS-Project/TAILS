using TAILS.Data;
using System.Linq;
using TAILS.Migrations;
using System.Data.Entity;

namespace TAILS
{
    class StartUp
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TAILSEntities, Configuration>());
            using (var context = new TAILSEntities())
            {
                var exams = context.Exams.ToList();
            }
        }
    }
}
