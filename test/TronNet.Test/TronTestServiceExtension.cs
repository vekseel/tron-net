﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace TronNet.Test
{
    public record TronTestRecord(IServiceProvider ServiceProvider, ITronClient TronClient, IOptions<TronNetOptions> Options);
    public static class TronTestServiceExtension
    {
        public static IServiceProvider AddTronNet()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTronNet(x =>
            {
                x.Network = TronNetwork.MainNet;
                x.Channel = new GrpcChannelOption { Host = "grpc.shasta.trongrid.io", Port = 50051 };
                x.SolidityChannel = new GrpcChannelOption { Host = "grpc.shasta.trongrid.io", Port = 50052 };
                x.ApiKey = "5b0b0475-cafd-49f6-8da5-3b9dfa4cb46a";
            });
            services.AddLogging();
            return services.BuildServiceProvider();
        }

        public static TronTestRecord GetTestRecord()
        {
            var provider = TronTestServiceExtension.AddTronNet();
            var client = provider.GetService<ITronClient>();
            var options = provider.GetService<IOptions<TronNetOptions>>();

            return new TronTestRecord(provider, client, options);
        }
    }

}
