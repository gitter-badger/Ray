﻿using System;
using Microsoft.Extensions.Options;
using Ray.Core.Storage;
using Ray.Storage.SQLCore.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ray.Storage.MySQL
{
    public class MySQLConfigureBuilder<PrimaryKey, Grain> : SQLConfigureBuilder<StorageFactory, PrimaryKey, Grain>
    {
        public MySQLConfigureBuilder(Func<IServiceProvider, PrimaryKey, DefaultConfigParameter, StorageOptions> generator, bool singleton = true) :
            base((provider, id, parameter) =>
            {
                var result = generator(provider, id, parameter);
                result.Connection = provider.GetService<IOptions<MySQLConnections>>().Value.ConnectionDict[result.ConnectionKey];
                result.CreateConnectionFunc = connection => MySQLFactory.CreateConnection(connection);
                result.BuildRepository = new MySQLBuildService(result);
                return result;
            }, singleton)
        {
        }
    }
}
