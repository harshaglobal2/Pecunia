using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Inventory.WcfService
{
    public class PersonsService : IPersonsService
    {
        public List<PersonDataContract> GetPersons()
        {
            //Create factory
            DbProviderFactory factory = DbProviderFactories.GetFactory(System.Configuration.ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ProviderName);

            //Create connection
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;

            //Create command
            DbCommand command = connection.CreateCommand();
            command.CommandText = "dbo.usp_GetPersons";
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            //Create adapter
            DbDataAdapter adapter = factory.CreateDataAdapter();
            adapter.SelectCommand = command;

            //Create dataset
            DataSet ds = new DataSet();

            //Execute
            adapter.Fill(ds);

            //Convert datatable to collection
            List<PersonDataContract> persons = ds.Tables[0]
                .AsEnumerable()
                .Select(p => new PersonDataContract()
                {
                    PersonID = p.Field<Guid>("PersonID"),
                    PersonName = p.Field<string>("PersonName"),
                    Password = p.Field<string>("Password"),
                    Email = p.Field<string>("Email")
                })
                .ToList();

            return persons;
        }
    }
}


