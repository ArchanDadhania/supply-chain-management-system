using System;
using System.Data ;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WarehouseMasterViewEdit : System.Web.UI.Page
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

            btnDelete.Enabled = false;
            if (Request.QueryString.Count > 0)
            {
                btnDelete.Enabled = true;
                DataSet dsEmp = new DataSet();
                dsEmp = objDb.GetDataset("select * from WarehouseMaster where WarehouseID=" + Convert.ToString(Request.QueryString["id"]) + "", "WarehouseMaster");
                if (dsEmp != null)
                {
                    if (dsEmp.Tables["WarehouseMaster"].Rows.Count > 0)
                    {
                        DataRow r = dsEmp.Tables["WarehouseMaster"].Rows[0];

                        TxtID.Text = Convert.ToString(r["WarehouseID"]);
                        TxtName.Text = Convert.ToString(r["WarehouseName"]);
                        TxtCity.Text = Convert.ToString(r["WarehouseCity"]);
                        TxtAddress.Text = Convert.ToString(r["WarehouseAddress"]);

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
            if (TxtName.Text.Length <= 0)
            {
                lblmsg.Text = "Enter warehouse name. "; return;
            }
            string strcount = objDb.ExecuteScaler("select count(*) from WarehouseMaster where WarehouseName='" + TxtName.Text + "' and WarehouseStokistID=" + Convert.ToString(Session["UserID"]));

            if (TxtCity.Text.Length <= 0)
            {
                lblmsg.Text = "Enter city name. "; return;
            }


            string strqr = "";
            if (Request.QueryString.Count > 0)
            {

                if (int.Parse(strcount) > 1)
                {
                    lblmsg.Text = "Duplicate warehouse name are not allowed.";

                    TxtName.Focus();
                    return;
                }

                strqr = "update WarehouseMaster set WarehouseName='" + TxtName.Text.Replace("'", "''") + "',WarehouseCity='" + TxtCity.Text.Replace("'", "''") + "', WarehouseAddress='" + TxtAddress.Text.Replace("'", "''") + "' where WarehouseID=" + Convert.ToString(Request.QueryString["id"]);
            }
            else
            {

                if (int.Parse(strcount) >= 1)
                {
                    lblmsg.Text = "Duplicate warehouse name are not allowed.";

                    TxtName.Focus();
                    return;
                }

                strqr = "insert into WarehouseMaster (WarehouseName,WarehouseCity,WarehouseAddress,WarehouseStokistID) values ('" + TxtName.Text.Replace("'", "''") + "','" + TxtCity.Text.Replace("'", "''") + "','" + TxtAddress.Text.Replace("'", "''") + "'," + Convert.ToString(Session["UserID"]) + ")";

            }
            string ret = objDb.ExecuteInsertUpdate(strqr);
            if (ret == "" || ret == null || ret == "0")
            {
                lblmsg.Text = "Error : " + objDb.returnMsg; return;
            }
            this.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script language=\"javaScript\">" + "alert('Record saved successfully!');" + "window.location.href='Warehouse.aspx';" + "<" + "/script>");

            //Response.Redirect("Warehouse.aspx");
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error : " + ex.Message.ToString();
        }

    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Warehouse.aspx");
    }
    protected void btnreset0_Click(object sender, EventArgs e)
    {
        //
        //Validate
        if (Request.QueryString.Count > 0)
        {
            //check for Warehouse already used


            //delete
            string strqr = "delete from  WarehouseMaster where WarehouseID=" + Convert.ToString(Request.QueryString["id"]);
            string ret = objDb.ExecuteInsertUpdate(strqr);
            if (ret == "" || ret == null || ret == "0")
            {
                lblmsg.Text = "Error : " + objDb.returnMsg; return;
            }
            Response.Redirect("Warehouse.aspx");

        }

    }
}
