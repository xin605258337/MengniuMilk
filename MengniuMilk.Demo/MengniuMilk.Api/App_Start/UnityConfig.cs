using System;

using Unity;

namespace MengniuMilk.Api
{
    using MengniuMilk.IService;
    using MengniuMilk.Service;
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IQCPlanServices, QCPlanServices>();
            container.RegisterType<IPermissionServices, PermissionServices>();
            container.RegisterType<IDataGatherServices, DataGatherServices>();
            container.RegisterType<ISampleServices, SampleServices>();
            container.RegisterType<IQCtaskServices, QCtaskServices>();
            container.RegisterType<IRolesServices, RolesServices>();
            container.RegisterType<IUsersServices, UsersServices>();
            container.RegisterType<ITargetServices, TargetServices>();
            container.RegisterType<IRawMilkServices, RawMilkServices>();
            container.RegisterType<IPackServices, PackServices>();
            container.RegisterType<ITargetTypeServices, TargetTypeServices>();
            container.RegisterType<IUnqualifiedServices, UnqualifiedServices>();
            container.RegisterType<IQCResultListServices, QCResultListServices>();
            container.RegisterType<IResultEenterServices, ResultEenterServices>();

        }
    }
}