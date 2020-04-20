using System;
using System.Data ;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StockIssue : System.Web.UI.Page
{
    DatabaseLayer objDb = new DatabaseLayer();
    ValidationFunctions objValidation = new ValidationFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmailID"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (IsPostBack == true)
        {
            return;
        }
        objDb.FillDropDownList(DdlProduct, "select ProductID, ProductName from ProductMaster order by ProductName", "ProductName", "ProductID");

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //validation
            if (DdlProduct.Text=="-1")
            {
                lblmsg.Text = "Select product name"; return;
            }

            if (lblmsg3.Text == "0")
            {
                lblmsg.Text = "Product is not available for issue"; return;
            }
            if (TxtQty.Text.Length <=0)
            {
                lblmsg.Text = "Enter issue quanity"; return;
            }

            if (objValidation.IsNumeric(TxtQty.Text) == false)
            {
                lblmsg.Text = "Enter issue quanity"; return;
            }
            if (int.Parse(TxtQty.Text) > int.Parse(lblmsg3.Text ))
            {
                lblmsg.Text = "Issue quanity can not be more than available qty."; return;
            }

            if (TxtTo.Text.Length <= 0)
            {
                lblmsg.Text = "Enter issue to"; return;
            }
            

            string strqr = "insert into IssueStock (IssueDate,IssueProductID,IssueQuantity,IssueTo,IssueBy) values (getdate()," + DdlProduct.Text + "," + TxtQty.Text + ",'" + TxtTo.Text.Replace("'","''") + "'," + Convert.ToString(Session["UserID"]) + ")";

             
            string ret = objDb.ExecuteInsertUpdate(strqr);
            if (ret == "" || ret == null || ret == "0")
            {
                lblmsg.Text = "Error : " + objDb.returnMsg; return;
            }

            this.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script language=\"javaScript\">" + "alert('Stock Issued');" + "window.location.href='default.aspx';" + "<" + "/script>");


        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error : " + ex.Message.ToString();
        }
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }
    protected void DdlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get product details
        if (DdlProduct.Text != "-1")
        {
            string str = "Select * from productmaster,ProductCategory,UserMaster,OrderDetails,WarehouseMaster where WarehouseID = OrderWarehouseID and OrderProductId=productid and  ProductCatId=CatID and ProductCompanyID=UserID and ProductID=" + DdlProduct.Text + " and WarehouseStokistID = " + Convert.ToString(Session["UserID"]) ;
            DataSet dsP = new DataSet();
            dsP = objDb.GetDataset(str, "productmaster");
            if (dsP.Tables["productmaster"].Rows.Count > 0)
            {
                DataRow r;
                r = dsP.Tables["productmaster"].Rows[0];
                sp_product.InnerHtml = "Product Id : " + Convert.ToString(r["ProductID"]) + "</br>Product Category : " + Convert.ToString(r["CatName"]) + "</br>Company : " + Convert.ToString(r["DisplayName"]) + "</br>Price : " + Convert.ToString(r["price"]);

                //get avilable quantity in warehouse
            
            }
            str = "Select isnull(sum(OrderQty),0) from productmaster,ProductCategory,UserMaster,OrderDetails,WarehouseMaster where WarehouseID = OrderWarehouseID and OrderProductId=productid and  ProductCatId=CatID and ProductCompanyID=UserID and ProductID=" + DdlProduct.Text + " and OrderStatus='InStock' and WarehouseStokistID = " + Convert.ToString(Session["UserID"]);
            int instock = int.Parse( objDb.ExecuteScaler(str));
            str = "Select isnull(sum(IssueQuantity),0)  from  IssueStock where issueproductID=" + DdlProduct.Text + " and IssueBy = " + Convert.ToString(Session["UserID"]);
            int outstock = int.Parse(objDb.ExecuteScaler(str));
            int diff = instock - outstock;
            lblmsg3.Text = diff.ToString();
        }
        else
        {
            sp_product.InnerHtml = "";
            lblmsg3.Text = "0";
        }
    }
}
