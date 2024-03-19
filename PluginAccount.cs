using EmpresaZ.Dynamics365.Plugins.Management;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Linq;

namespace EmpresaZ.Dynamics365.Plugins
{
    public class PluginAccount : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
            ITracingService trace = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            Entity account = (Entity)context.InputParameters["Target"];

            AccountManagement accountManagement = new AccountManagement(service);
            accountManagement.CNPJValidation(account);
        }
    }
}