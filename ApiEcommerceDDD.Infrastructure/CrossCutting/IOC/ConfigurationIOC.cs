using Autofac;
using AutoMapper;
using ApiEcommerceDDD.Application;
using ApiEcommerceDDD.Application.Interfaces;
using ApiEcommerceDDD.Application.Mappers;
using ApiEcommerceDDD.Domain.Core.Interfaces.Repositories;
using ApiEcommerceDDD.Domain.Core.Interfaces.Services;
using ApiEcommerceDDD.Domain.Services;
using ApiEcommerceDDD.Infrastructure.Data.Repositories;

namespace ApiEcommerceDDD.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<ApplicationServicePedido>().As<IApplicationServicePedido>();
            builder.RegisterType<ServicePedido>().As<IServicePedido>();
            builder.RegisterType<RepositoryPedido>().As<IRepositoryPedido>();

            builder.RegisterType<ApplicationServiceFrota>().As<IApplicationServiceFrota>();
            builder.RegisterType<ServiceFrota>().As<IServiceFrota>();
            builder.RegisterType<RepositoryFrota>().As<IRepositoryFrota>();

            builder.RegisterType<ApplicationServiceEndereco>().As<IApplicationServiceEndereco>();
            builder.RegisterType<ServiceEndereco>().As<IServiceEndereco>();
            builder.RegisterType<RepositoryEndereco>().As<IRepositoryEndereco>();

            builder.RegisterType<ApplicationServiceProduto>().As<IApplicationServiceProduto>();
            builder.RegisterType<ServiceProduto>().As<IServiceProduto>();
            builder.RegisterType<RepositoryProduto>().As<IRepositoryProduto>();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelMappingFrota());
                cfg.AddProfile(new ModelToDtoMappingFrota());
                cfg.AddProfile(new DtoToModelMappingPedido());
                cfg.AddProfile(new ModelToDtoMappingPedido());
                cfg.AddProfile(new DtoToModelMappingEndereco());
                cfg.AddProfile(new ModelToDtoMappingEndereco());
                cfg.AddProfile(new DtoToModelMappingProduto());
                cfg.AddProfile(new ModelToDtoMappingProduto());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }

        #endregion IOC
    }

}