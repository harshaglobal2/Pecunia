using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;

namespace Capgemini.Inventory.DataAccessLayer
{
    public class ProductsDAL : IDisposable
    {
        public (bool, Guid) AddProduct(Product product)
        {
            //New Guid
            product.ProductID = Guid.NewGuid();

            //Invoke stored procedure
            using (companyEntities db = new companyEntities())
            {
                int affectedRowsCount = db.usp_CreateProduct(product.ProductID, product.ProductName, product.UnitPrice);

                //return no. of rows effected
                if (affectedRowsCount >= 1)
                {
                    return (true, product.ProductID);
                }
                else
                {
                    return (false, product.ProductID);
                }
            }
        }

        public bool UpdateProduct(Product product)
        {
            //Invoke stored procedure
            using (companyEntities db = new companyEntities())
            {
                int affectedRowsCount = db.usp_UpdateProduct(product.ProductID, product.ProductName, product.UnitPrice);

                //return no. of rows effected
                if (affectedRowsCount >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteProduct(Product product)
        {
            //Invoke stored procedure
            using (companyEntities db = new companyEntities())
            {
                int affectedRowsCount = db.usp_DeleteProduct(product.ProductID);

                //return no. of rows effected
                if (affectedRowsCount >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<Product> GetProducts()
        {
            //Invoke stored procedure
            using (companyEntities db = new companyEntities())
            {
                List<Product> products = db.usp_GetProducts().ToList();
                return products;
            }
        }


        public Product GetProductByProductID(Guid ProductID)
        {
            //Invoke stored procedure
            using (companyEntities db = new companyEntities())
            {
                Product product = db.usp_GetProductByProductID(ProductID).FirstOrDefault();
                return product;
            }
        }

        public void Dispose()
        {
        }
    }
}



