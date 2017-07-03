using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQbit.PaymentGateway.DataAccess.Contracts;
using OpenQbit.PaymentGateway.DataAccess.DAL;
using OpenQbit.PaymentGateway.BLL.Contracts;
using OpenQbit.PaymentGateway.BLL.Service;
using OpenQbit.PaymentGateway.Common.Utils.Logs;

using Microsoft.Practices.Unity;

namespace OpenQbit.PaymentGateway.Common.IOC
{
    public static class UnityResolver
    {
        private static readonly IUnityContainer Container = new UnityContainer();

        private static void Register()
        {
            Container.RegisterType<IBankManager,BankManager>();
            Container.RegisterType<IMerchantManager,MerchantManager>();
            Container.RegisterType<IRequestManager,RequestManager>();
            Container.RegisterType<IResponceManager,ResponceManager>();
            Container.RegisterType<ITransactionManager,TransactionManager>();
            
            Container.RegisterType<IRepository, Repository>();
            Container.RegisterType<ILogger, Logger>();
        }

        public static T Resolve<T>()
        {
            T defaultT = default(T);
            var resolved = Container.Resolve<T>();
            return (resolved == null) ? defaultT : resolved;
        }

        public static IUnityContainer GetContainer()
        {
            return Container;
        }

    }


}
