using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;

namespace Acme.StockExchange.Bootstrap.Unity
{
    public abstract class UnityBootstrapper : IBootstrapper
    {
        private readonly string _bootstrapperName;
        protected readonly Type BootstrapperType;
        protected readonly IUnityContainer Container;

        protected UnityBootstrapper(IUnityContainer unityContainer)
        {
            if (unityContainer == null)
                throw new ArgumentNullException(nameof(unityContainer));

            Container = unityContainer;
            BootstrapperType = typeof(IBootstrapper);
            _bootstrapperName = BootstrapperType.Assembly.GetName()
                .Name.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Last();
        }

        public object Initialize(Type type) => Container.Resolve(type);

        public abstract void RegisterComponents();

        protected IEnumerable<Type> ApplicationAssemblies() =>
            //if (HostingEnvironment.IsHosted) // determines whether the application is web hosted or not
            AllClasses.FromAssemblies(BuildManager.GetReferencedAssemblies().Cast<Assembly>()).Where(TypeIsFromApplication).ToList();

        protected IUnityContainer RegisterBaseComponents() =>
            Container.RegisterTypes(ApplicationAssemblies(), ApplicationTypes);

        protected IEnumerable<Type> ApplicationTypes(Type assembly) =>
            WithMappings.FromAllInterfaces(assembly).Where(TypeIsFromApplication).ToList();

        protected virtual bool TypeIsFromApplication(Type type) =>
            // ReSharper disable once PossibleNullReferenceException
            type != BootstrapperType
                && type.Namespace.StartsWith(GetApplicationNamespace(), StringComparison.InvariantCultureIgnoreCase);

        protected virtual string GetApplicationNamespace()
        {
            var name = Assembly.GetExecutingAssembly().GetName().Name;
            return name.Substring(0, name.IndexOf(_bootstrapperName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}