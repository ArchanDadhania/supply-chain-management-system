using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductMasterViewEdit : System.Web.UI.Page
{
    DatabaseLayer objDb = new DatabaseLayer();
    ValidationFunctions objValidation = new ValidationFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["EmailID"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (IsPostBack == true)
            {
                return;
            }
            //fill category
            objDb.FillDropDownList(DdlCategory, "select CatName,CatID from ProductCategory where CatCompanyID=" + Convert.ToString(Session["UserID"]) + " ", "CatName", "CatID");

            btnDelete.Enabled = false; 
            if (Request.QueryString.Count > 0)
            {
                btnDelete.Enabled =true ;
                DataSet dsEmp = new DataSet();
                dsEmp = objDb.GetDataset("select * from ProductMaster, ProductCategory where CatID=ProductCatId and ProductID=" + Convert.ToString(Request.QueryString["id"]) + "", "ProductMaster");
                if (dsEmp != null)
                {
                    if (dsEmp.Tables["ProductMaster"].Rows.Count > 0)
                    {
                        DataRow r = dsEmp.Tables["ProductMaster"].Rows[0];

                        TxtProdID.Text = Convert.ToString(r["ProductID"]);
                        TxtProductName.Text = Convert.ToString(r["ProductName"]);
                        DdlCategory.Text  = Convert.ToString(r["Catid"]);
                        TxtDescription.Text = Convert.ToString(r["ProductDescription"]);
                        TxtPrice.Text = Convert.ToString(r["Price"]);

                   }
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error : " + ex.Message.ToString();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //validation
            if (TxtProductName.Text.Length <= 0)
            {
                lblmsg.Text = "Enter product name. "; return;
            }
            string strcount = objDb.ExecuteScaler("select count(*) from ProductMaster where ProductName='" + TxtProductName.Text + "' and ProductCompanyID=" + Convert.ToString(Session["UserID"]));

            if (DdlCategory.Text =="-1")
            {
                lblmsg.Text = "Select category. "; return;
            }

            if (objValidation.IsNumeric(TxtPrice.Text) == false)
            {
                lblmsg.Text = "Enter product price. "; return;
            }


            string strqr = "";
            if (Request.QueryString.Count > 0)
            {

                if (int.Parse(strcount) > 1)
                {
                    lblmsg.Text = "Duplicate product name are not allowed.";

                    TxtProductName.Focus();
                    return;
                }

                strqr = "update ProductMaster set ProductName='" + TxtProductName.Text.Replace("'", "''") + "',ProductDescription='" + TxtDescription.Text.Replace("'", "''") + "', ProductCatId=" + DdlCategory.SelectedItem.Value + ", Price=" + TxtPrice.Text + " where ProductID=" + Convert.ToString(Request.QueryString["id"]);
            }
            else
            {

                if (int.Parse(strcount) >= 1)
                {
                    lblmsg.Text = "Duplicate product name are not allowed.";

                    TxtProductName.Focus();
                    return;
                }
                 
                strqr = "insert into ProductMaster (ProductName,ProductDescription,ProductCatId,ProductCompanyID,Price) values ('" + TxtProductName.Text.Replace("'", "''") + "','" +  TxtDescription.Text.Replace("'", "''") + "'," + DdlCategory.SelectedItem.Value + "," +  Convert.ToString(Session["UserID"]) + "," + TxtPrice.Text  + ")";

            }
            string ret = objDb.ExecuteInsertUpdate(strqr);
            if (ret == "" || ret == null || ret == "0")
            {
                lblmsg.Text = "Error : " + objDb.returnMsg; return;
            }
            this.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script language=\"javaScript\">" + "alert('Record saved successfully!');" + "window.location.href='ProductMaster.aspx';" + "<" + "/script>");

            //Response.Redirect("ProductMaster.aspx");
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error : " + ex.Message.ToString();
        }

    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("productmaster.aspx");
    }
    protected void btnreset0_Click(object sender, EventArgs e)
    {
        //
        //Validate
        if (Request.QueryString.Count > 0)
        {
            //check for product already used


            //delete
            string strqr = "delete from  ProductMaster where ProductID=" + Convert.ToString(Request.QueryString["id"]);
            string ret = objDb.ExecuteInsertUpdate(strqr);
            if (ret == "" || ret == null || ret == "0")
            {
                lblmsg.Text = "Error : " + objDb.returnMsg; return;
            }
            Response.Redirect("ProductMaster.aspx");

        }

    }
}
