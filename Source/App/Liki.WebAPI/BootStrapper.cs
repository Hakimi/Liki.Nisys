using Liki.App.Service;
using Liki.Domain.Core.Aggregates.CustomerAgg;
using Liki.Domain.Seedwork;
using Liki.Infrastructure.Data.Core.Repositories;
using Liki.Infrastructure.Data.Seedwork;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Liki.WebAPI
{
    public class BootStrapper
    {
        #region Method
        public static void ConfigureDependencies()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<ControllerRegistry>();

            });
        }

        public class ControllerRegistry : Registry
        {

            public ControllerRegistry()
            {

                // Repositories                
                For<ICustomerService>().Use<CustomerService>();
                For<ICustomerRepository>().Use<CustomerRepository>();
                For<IUnitOfWork>().Use<UnitOfWork>();
                For<IAuthenticationService>().Use<AuthenticationService>();
            }
        }
        #endregion
    }
}

