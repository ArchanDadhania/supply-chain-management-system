using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductCategoryViewEdit : System.Web.UI.Page
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
             

            if (Request.QueryString.Count > 0)
            {
                DataSet dsEmp = new DataSet();
                dsEmp = objDb.GetDataset("select * from ProductCategory where CatID=" + Convert.ToString(Request.QueryString["id"]) + "", "ProductCategory");
                if (dsEmp != null)
                {
                    if (dsEmp.Tables["ProductCategory"].Rows.Count > 0)
                    {
                        DataRow r = dsEmp.Tables["ProductCategory"].Rows[0];
                        TxtCatID.Text = Convert.ToString(r["CatID"]);
                        TxtCategoryName.Text = Convert.ToString(r["CatName"]);
                        if (Convert.ToString(r["CatActive"]) == "1")
                        {
                            ChkActive.Checked = true;
                        }
                        else
                        {
                            ChkActive.Checked = false;
                        }

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
            if (TxtCategoryName.Text.Length <= 0)
            {
                lblmsg.Text = "Enter category name"; return;
            }

            string strCount = objDb.ExecuteScaler("select count(*) from ProductCategory where CatName='" + TxtCategoryName.Text + "' and CatCompanyID=" + Convert.ToString(Session["UserID"]));


           string stractive = "0";
            if (ChkActive.Checked == true)
            {
                stractive = "1";
            }
            else
            {
                stractive = "0";
            }

            string strqr = "";
            if (Request.QueryString.Count > 0)
            {
                if (int.Parse(strCount) > 1)
                {
                    lblmsg.Text = "Duplicate product category name are not allowed.";

                    TxtCategoryName.Focus();
                    return;
                }

                strqr = "update ProductCategory set CatName='" + TxtCategoryName.Text.Replace("'", "''") + "', CatActive= " + stractive + " where CatID=" + Convert.ToString(Request.QueryString["id"]);
            }
            else
            {
                if (int.Parse(strCount) >= 1)
                {
                    lblmsg.Text = "Duplicate product category name are not allowed.";

                    TxtCategoryName.Focus();
                    return;
                }

                strqr = "insert into ProductCategory (CatName,CatCompanyID,CatActive) values ('" + TxtCategoryName.Text.Replace("'", "''") + "'," + Convert.ToString(Session["UserID"]) + "," + stractive + ")";

            }
            string ret = objDb.ExecuteInsertUpdate(strqr);
            if (ret == "" || ret == null || ret == "0")
            {
                lblmsg.Text = "Error : " + objDb.returnMsg; return;
            }
            //Response.Redirect("ProductCategory.aspx");

            this.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script language=\"javaScript\">" + "alert('Record Saved');" + "window.location.href='ProductCategory.aspx';" + "<" + "/script>");

        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error : " + ex.Message.ToString();
        }

    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("productcategory.aspx");
    }
}
