using Capgemini.GreatOutdoors.DataAccessLayer;
using Capgemini.GreatOutdoors.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.GreatOutdoors.BusinessLogicLayer
{
    public class ProductsBL
    {
        public (bool, Guid) AddProduct(Product product)
        {
            using (ProductsDAL productsDAL = new ProductsDAL())
            {
                return productsDAL.AddProduct(product);
            }
        }

        public bool UpdateProduct(Product product)
        {
            using (ProductsDAL productsDAL = new ProductsDAL())
            {
                return productsDAL.UpdateProduct(product);
            }
        }

        public bool DeleteProduct(Product product)
        {
            using (ProductsDAL productsDAL = new ProductsDAL())
            {
                return productsDAL.DeleteProduct(product);
            }
        }

        public List<Product> GetProducts()
        {
            using (ProductsDAL productsDAL = new ProductsDAL())
            {
                return productsDAL.GetProducts();
            }
        }


        public Product GetProductByProductID(Guid ProductID)
        {
            using (ProductsDAL productsDAL = new ProductsDAL())
            {
                return productsDAL.GetProductByProductID(ProductID);
            }
        }
    }
}


