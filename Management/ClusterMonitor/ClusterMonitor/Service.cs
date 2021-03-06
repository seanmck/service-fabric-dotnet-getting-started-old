﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace ClusterMonitor
{
    using System.Fabric.Description;
    using Microsoft.ServiceFabric.Services;
    using System.Collections.Generic;
    using Microsoft.ServiceFabric.Services.Runtime;
    using Microsoft.ServiceFabric.Services.Communication.Runtime;
    public class Service : StatelessService
    {
        public const string ServiceTypeName = "ClusterMonitorType";

        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            ConfigurationSettings configSettings =
                this.ServiceInitializationParameters.CodePackageActivationContext.GetConfigurationPackageObject("Config").Settings;

            return new[]
            {
                new ServiceInstanceListener(initParams => new OwinCommunicationListener("cluster", new Startup(configSettings), initParams))
            };                
        }
    }
}