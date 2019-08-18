using System;
using System.Reflection;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using VinylStore.Catalog.Domain.Commands.Item;
using VinylStore.Catalog.Domain.Commands.Item.Validators;

namespace VinylStore.Catalog.Domain.Infrastructure.Extensions
{
    public static class DomainExtensions
    {
        public static IServiceCollection AddDomainComponents(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services
                .AddTransient<IValidator<EditItemCommand>, EditItemCommandValidator>()
                .AddTransient<IValidator<AddItemCommand>, AddItemCommandValidator>();

            return services;
        }
    }
}