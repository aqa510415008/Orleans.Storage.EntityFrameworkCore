﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Orleans.Storage.EntityFrameworkCore
{
    public interface IStorageBuilder
    {
        IServiceCollection Service { get; }

        IStorageBuilder Configure(Action<OrleansStorageOptions> config);

        IStorageBuilder AddDbContextFactory<TDbContext, TDbContextFactory>()
                 where TDbContext : DbContext
                 where TDbContextFactory : class, IDbContextFactory, IDbContextFactory<TDbContext>;

        IStorageBuilder AddRepository<TRepository, TEntity, TPrimaryKey>(bool isAutoUpdate = true, bool isAutoDelete = true, bool isAutoInsert = true)
        where TRepository : class, IRepository
        where TEntity : class, IStorageEntity;
    }
}
