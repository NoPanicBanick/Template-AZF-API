﻿using API.Class1;
using API.Class1.AutoMapper;
using API.Class1.v1.Services;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using DataAccess.Class1.v1.DataEntities;
using DataAccess.Class1.v1.Repositories;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PoorMan;
using System;

[assembly: FunctionsStartup(typeof(Startup))]
namespace API.Class1
{
    public class Startup : FunctionsStartup
    {
        /// <summary>
        /// Setup Configuration
        /// </summary>
        /// <param name="builder"></param>
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            builder.ConfigurationBuilder
               .SetBasePath(Environment.CurrentDirectory)
               .AddEnvironmentVariables();
            var configReader = builder.ConfigurationBuilder.Build();
            var kvClient = new SecretClient(new Uri(configReader["keyvaulturl"]), new DefaultAzureCredential());
            builder.ConfigurationBuilder.AddAzureKeyVault(kvClient, new KeyVaultSecretManager());
        }

        /// <summary>
        /// Configure Services Container
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = builder.GetContext().Configuration;
            var mapperConfig = new AutoMapperConfiguration(new MapperProfile());
            builder.Services
                .AddScoped<ITable<Class1TableEntity>>((services) => new AzureTable<Class1TableEntity>(
                    new Uri(config["tableStorageUri"]),
                    config["storageAccountName"],
                    config["rocketClass1s:storage:key"]
                    )
                )
                .AddScoped<IClass1Repository, Class1Repository>()
                .AddScoped<IClass1Service, Class1Service>()
                .AddSingleton(mapperConfig.GetMapper()); // IMapper

        }
    }
}
