using Autofac;
using Autofac.Core;
using Autofac.Features.Variance;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Customers.Queries;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Services;
using SCG.DIST.WEBCOMPLAINT.INFRASTRUCTURE.EFCore;
using SCG.DIST.WEBCOMPLAINT.INFRASTRUCTURE.Repositories;
using SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Validators;
using System.Reflection;

namespace CleanArch.Api
{
    public class DependencyConfig : Autofac.Module
    {

        public class RegisterServiceModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {

                builder.RegisterGeneric(typeof(GenericRepository<>))
                .AsImplementedInterfaces();
                builder.Register<ServiceFactory>(ctx =>
                {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => c.Resolve(t);
                });

                builder.RegisterAssemblyTypes(typeof(UnitOfWork).Assembly)
                     .AsImplementedInterfaces().InstancePerDependency();

                builder.RegisterAssemblyTypes(typeof(CustomerRepository).Assembly)
                     .AsImplementedInterfaces().InstancePerDependency();

                builder.RegisterAssemblyTypes(typeof(ProductService).Assembly)
                      .AsImplementedInterfaces().InstancePerDependency();
            }
        }


        public class MediatorModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterSource(new ScopedContravariantRegistrationSource(
                    typeof(IRequestHandler<,>),
                    typeof(INotificationHandler<>),
                    typeof(IValidator<>)
                ));

                builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

                var mediatrOpenTypes = new[]
                {
            typeof(IRequestHandler<,>),
            //typeof(INotificationHandler<>),
            typeof(IValidator<>),
        };

                foreach (var mediatrOpenType in mediatrOpenTypes)
                {
                    builder
                        .RegisterAssemblyTypes(typeof(GetAllCustomerTableQuery).GetTypeInfo().Assembly)
                        .AsClosedTypesOf(mediatrOpenType)
                        .AsImplementedInterfaces();
                }

                builder.RegisterGeneric(typeof(RequestPostProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
                builder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));

                builder.Register<ServiceFactory>(ctx =>
                {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => c.Resolve(t);
                });

                builder.RegisterGeneric(typeof(CommandValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            }


        }
        public class ScopedContravariantRegistrationSource : IRegistrationSource
        {
            private readonly IRegistrationSource _source = new ContravariantRegistrationSource();
            private readonly List<Type> _types = new List<Type>();

            public ScopedContravariantRegistrationSource(params Type[] types)
            {
                if (types == null)
                    throw new ArgumentNullException(nameof(types));
                if (!types.All(x => x.IsGenericTypeDefinition))
                    throw new ArgumentException("Supplied types should be generic type definitions");
                _types.AddRange(types);
            }


            public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<ServiceRegistration>> registrationAccessor)
            {
                var components = _source.RegistrationsFor(service, registrationAccessor);
                foreach (var c in components)
                {
                    var defs = c.Target.Services
                        .OfType<TypedService>()
                        .Select(x => x.ServiceType.GetGenericTypeDefinition());

                    if (defs.Any(_types.Contains))
                        yield return c;
                }
            }

            public bool IsAdapterForIndividualComponents => _source.IsAdapterForIndividualComponents;
        }
    }
}
