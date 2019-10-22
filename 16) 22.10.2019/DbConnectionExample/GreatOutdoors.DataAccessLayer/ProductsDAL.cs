using Capgemini.GreatOutdoors.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.GreatOutdoors.DataAccessLayer
{
    public class ProductsDAL : IDisposable
    {
        public (bool, Guid) AddProduct(Product product)
        {
            //New Guid
            product.ProductID = Guid.NewGuid();

            //Create factory
            DbProviderFactory factory = DbProviderFactories.GetFactory(System.Configuration.ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ProviderName);

            //Create connection
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;

            //Create command
            DbCommand command = connection.CreateCommand();
            command.CommandText = "dbo.usp_CreateProduct";
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            //Create parameters
            DbParameter p1 = command.CreateParameter();
            p1.ParameterName = "@ProductID";
            p1.Value = product.ProductID;
            p1.DbType = System.Data.DbType.Guid;
            command.Parameters.Add(p1);

            DbParameter p2 = command.CreateParameter();
            p2.ParameterName = "@ProductName";
            p2.Value = product.ProductName;
            command.Parameters.Add(p2);

            DbParameter p3 = command.CreateParameter();
            p3.ParameterName = "@UnitPrice";
            p3.Value = product.UnitPrice;
            command.Parameters.Add(p3);

            //Execute
            connection.Open();
            int n = command.ExecuteNonQuery();
            connection.Close();
            if (n >= 1)
                return (true, product.ProductID);
            else
                return (false, product.ProductID);
        }

        public bool UpdateProduct(Product product)
        {
            //Create factory
            DbProviderFactory factory = DbProviderFactories.GetFactory(System.Configuration.ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ProviderName);

            //Create connection
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;

            //Create command
            DbCommand command = connection.CreateCommand();
            command.CommandText = "dbo.usp_UpdateProduct";
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            //Create parameters
            DbParameter p1 = command.CreateParameter();
            p1.ParameterName = "@ProductID";
            p1.Value = product.ProductID;
            p1.DbType = System.Data.DbType.Guid;
            command.Parameters.Add(p1);

            DbParameter p2 = command.CreateParameter();
            p2.ParameterName = "@ProductName";
            p2.Value = product.ProductName;
            command.Parameters.Add(p2);

            DbParameter p3 = command.CreateParameter();
            p3.ParameterName = "@UnitPrice";
            p3.Value = product.UnitPrice;
            command.Parameters.Add(p3);

            //Execute
            connection.Open();
            int n = command.ExecuteNonQuery();
            connection.Close();
            if (n >= 1)
                return true;
            else
                return false;
        }

        public bool DeleteProduct(Product product)
        {
            //Create factory
            DbProviderFactory factory = DbProviderFactories.GetFactory(System.Configuration.ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ProviderName);

            //Create connection
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;

            //Create command
            DbCommand command = connection.CreateCommand();
            command.CommandText = "dbo.usp_DeleteProduct";
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            //Create parameters
            DbParameter p1 = command.CreateParameter();
            p1.ParameterName = "@ProductID";
            p1.Value = product.ProductID;
            p1.DbType = System.Data.DbType.Guid;
            command.Parameters.Add(p1);

            DbParameter p2 = command.CreateParameter();
            p2.ParameterName = "@ProductName";
            p2.Value = product.ProductName;
            command.Parameters.Add(p2);

            DbParameter p3 = command.CreateParameter();
            p3.ParameterName = "@UnitPrice";
            p3.Value = product.UnitPrice;
            command.Parameters.Add(p3);

            //Execute
            connection.Open();
            int n = command.ExecuteNonQuery();
            connection.Close();
            if (n >= 1)
                return true;
            else
                return false;
        }

        public List<Product> GetProducts()
        {
            //Create factory
            DbProviderFactory factory = DbProviderFactories.GetFactory(System.Configuration.ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ProviderName);

            //Create connection
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;

            //Create command
            DbCommand command = connection.CreateCommand();
            command.CommandText = "dbo.usp_GetProducts";
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
            List<Product> products = ds.Tables[0]
                .AsEnumerable()
                .Select(p => new Product()
                {
                    ProductID = p.Field<Guid>("ProductID"),
                    ProductName = p.Field<string>("ProductName"),
                    UnitPrice = p.Field<decimal>("UnitPrice")
                })
                .ToList();

            return products;
        }


        public Product GetProductByProductID(Guid ProductID)
        {
            //Create factory
            DbProviderFactory factory = DbProviderFactories.GetFactory(System.Configuration.ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ProviderName);

            //Create connection
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;

            //Create command
            DbCommand command = connection.CreateCommand();
            command.CommandText = "dbo.usp_GetProductByProductID";
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            //Create parameters
            DbParameter p1 = command.CreateParameter();
            p1.ParameterName = "@ProductID";
            p1.Value = ProductID;
            p1.DbType = System.Data.DbType.Guid;
            command.Parameters.Add(p1);

            //Create adapter
            DbDataAdapter adapter = factory.CreateDataAdapter();
            adapter.SelectCommand = command;

            //Create dataset
            DataSet ds = new DataSet();

            //Execute
            adapter.Fill(ds);

            //Convert datatable to collection
            Product product = ds.Tables[0]
                .AsEnumerable()
                .Select(p => new Product()
                {
                    ProductID = p.Field<Guid>("ProductID"),
                    ProductName = p.Field<string>("ProductName"),
                    UnitPrice = p.Field<decimal>("UnitPrice")
                })
                .FirstOrDefault();

            return product;
        }

        public void Dispose()
        {
        }
    }
}


