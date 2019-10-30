using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capgemini.GreatOutdoors.BusinessLogicLayer;
using Capgemini.GreatOutdoors.Entities;

namespace GreatOutdoors.Web
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ProductsBL productsBL = new ProductsBL();
                List<Product> products = productsBL.GetProducts();
                GridViewProducts.DataSource = products;
                GridViewProducts.DataBind();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Session["CurrentProductID"] = btn.CommandArgument;
            Response.Redirect("EditProduct.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Session["CurrentProductID"] = btn.CommandArgument;
            Response.Redirect("DeleteProduct.aspx");
        }
    }
}


