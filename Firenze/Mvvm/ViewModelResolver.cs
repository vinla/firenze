using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Autofac;

using Firenze.ViewModels;

namespace Firenze.Mvvm
{
    public class ViewModelResolver : IViewModelResolver
    {
        private readonly ContainerBuilder _containerBuilder;
        private IContainer _container;

        public ViewModelResolver(ContainerBuilder containerBuilder)
        {
            if (containerBuilder == null)
                throw new ArgumentNullException(nameof(containerBuilder));

            _containerBuilder = containerBuilder;
        }

        public void RegisterViewModels()
        {
            var assemblyTypes = Assembly.GetCallingAssembly().GetTypes();

            var targets =
                assemblyTypes
                    .Where(t => CustomAttributeExtensions.GetCustomAttributes((MemberInfo) t, typeof(AutofacRegisterAttribute)).Any())
                    .Select(t => new
                    {
                        Attrs = t.GetCustomAttributes(typeof(AutofacRegisterAttribute)).Cast<AutofacRegisterAttribute>().Select(attr =>
                            new
                            {
                                Type = t,
                                Attr = attr
                            })
                    })
                    .SelectMany(a => a.Attrs);

            foreach (var target in targets)
            {
                if (target.Attr.CustomRegistrationType != null)
                {
                    var registrationClass = Activator.CreateInstance(target.Attr.CustomRegistrationType) as IAutofacRegisterationClass;
                    registrationClass?.Register(_containerBuilder);
                }
                else
                {
                    _containerBuilder.RegisterType(target.Type).AsSelf();
                }
            }
        }

        public TViewModel Resolve<TViewModel>(Object knownParameters)
        {
            if (_container == null)
                _container = _containerBuilder.Build();

            var parameters = new List<NamedParameter>();
            if (knownParameters != null)
            {
                foreach (var property in knownParameters.GetType().GetRuntimeProperties())
                {
                    parameters.Add(new NamedParameter(property.Name, property.GetValue(knownParameters)));
                }
            }

            return _container.Resolve<TViewModel>(parameters);
        }
    }
}