using Capgemini.GreatOutdoors.BusinessLogicLayer;
using Capgemini.GreatOutdoors.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreatOutdoors.Web
{
    public partial class EditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["CurrentProductID"] != null)
                    {
                        Guid CurrentProductID = new Guid(Convert.ToString(Session["CurrentProductID"]));
                        ProductsBL productsBL = new ProductsBL();
                        Product product = productsBL.GetProductByProductID(CurrentProductID);
                        txtProductName.Text = product.ProductName;
                        txtUnitPrice.Text = Convert.ToString(product.UnitPrice);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Guid CurrentProductID = new Guid(Convert.ToString(Session["CurrentProductID"]));
                ProductsBL productsBL = new ProductsBL();
                Product product = productsBL.GetProductByProductID(CurrentProductID);
                product.ProductName = txtProductName.Text;
                product.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
                productsBL.UpdateProduct(product);
                Response.Redirect("~/Products.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        
    }
}


