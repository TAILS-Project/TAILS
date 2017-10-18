using TAILS.Data;
using System.Linq;
using TAILS.Migrations;
using System.Data.Entity;
using Ninject;
using TAILS.Ninject;
using TAILS.Core;

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

            IKernel kernel = new StandardKernel(new TAILSModule());
            IEngine engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}
