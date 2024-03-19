using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using EmpresaZ.Dynamics365.Plugins.Repository;
using Microsoft.Xrm.Sdk;

namespace EmpresaZ.Dynamics365.Plugins.Management
{
    public class AccountManagement
    {
        private IOrganizationService Service { get; set; }

        public AccountManagement(IOrganizationService service)
        {
            Service = service;
        }

        public void CNPJValidation(Entity account)
        {
            if (account.Contains("alf_cnpj"))
            {
                string cnpj = account["alf_cnpj"].ToString();
                var accounts = AccountRepository.GetByCNPJ(cnpj, Service);

                if (accounts.Entities.Count() > 0)
                {
                    throw new InvalidPluginExecutionException($"CNPJ já cadastrado na conta de nome {accounts.Entities.First()["name"]}");
                }
            }
        }
    }
}
