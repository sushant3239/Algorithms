using System;
using Microsoft.Practices.Unity;
using OfflineSync.Core.Repository.Interfaces;
using OfflineSync.Core.Repository.HttpRepository;
using OfflineSync.Core.Repository.SqliteRepository;
using OfflineSync.Core.Service.Interfaces;
using OfflineSync.Core.Service.Implementation;
using OfflineSync.Core.Infrastructure;

namespace OfflineSync.Uwp
{
    public class IocContainer
    {
        private readonly UnityContainer _container;

        public IocContainer()
        {
            _container = new UnityContainer();
            RegisterTypes();
        }

        private void RegisterTypes()
        {
            _container.RegisterType<ISqliteConnetion, SqliteConnection>(new ContainerControlledLifetimeManager());
            _container.RegisterType<INetworkProfile, NetworkProfile>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IHttpService, HttpServiceClient>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IBmsRepository, BmsHttpRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IBmsStorageRepository, BmsSqlRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IBmsService, BmsService>(new ContainerControlledLifetimeManager());

        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
