using Ninject;
using TAILS.Data;
using TAILS.Core;
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

            IKernel kernel = new StandardKernel(new TAILSModule());
            IEngine engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}
