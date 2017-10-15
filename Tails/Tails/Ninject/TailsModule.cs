using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tails.Core.Factories;
using Tails.Core.Providers;
using Tails.Data;

namespace Tails.Ninject
{
    public class TailsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ITailsContext>().To<TailsContext>();

            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<ICommandParser>().To<CommandParser>();

            this.Bind<ITailsFactory>().To<TailsFactory>();
            this.Bind<ICommandFactory>().To<CommandFactory>();

            this.Bind<IDatabase>().To<Database>();

        }
    }
}
