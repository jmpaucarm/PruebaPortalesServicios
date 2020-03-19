using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Core.Logging;
using Core.Metrics;
using System.Threading;
using Winton.Extensions.Configuration.Consul;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using Core.Mvc;

namespace Security
{
    public class Program : BaseProgram<Startup>
    {
        public static void Main(string[] args)
        {
            Initialize(args);
        }
    }
}