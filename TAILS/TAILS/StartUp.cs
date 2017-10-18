using Ninject;
using TAILS.Data;
using TAILS.Core;
using System.Linq;
using TAILS.Ninject;
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

            IKernel kernel = new StandardKernel(new TAILSModule());
            IEngine engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}
