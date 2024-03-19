using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;

namespace EmpresaZ.Dynamics365.Plugins.Repository
{
    public static class AccountRepository
    {
        public static EntityCollection GetByCNPJ(string cnpj, IOrganizationService service)
        {
            QueryExpression query = new QueryExpression("account");
            query.ColumnSet.AddColumns("accountid", "name");
            query.Criteria.AddCondition("alf_cnpj", ConditionOperator.Equal, cnpj);
            EntityCollection accountCollection = service.RetrieveMultiple(query);
            return accountCollection;
        }
    }
}
