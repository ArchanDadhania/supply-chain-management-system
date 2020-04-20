using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class ChangePassword : System.Web.UI.Page
{
    DatabaseLayer objdb = new DatabaseLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["EmailID"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (IsPostBack == false)
            {
                TxtEmailID.Text = Session["EmailID"].ToString();
                txtoldpassword.Focus();
            }
        }
        catch (Exception ex) { }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void btnchange_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtoldpassword.Text.Trim() == "")
            {
                lblmsg.Text = "Please enter old password."; txtoldpassword.Focus(); return;
            }

            //validate old password
            DataSet dsEmp = new DataSet();
            dsEmp = objdb.GetDataset("select * from usermaster where emailid='" + TxtEmailID.Text + "' and active=1 ", "users");
            if (dsEmp != null)
            {
                if (dsEmp.Tables["users"].Rows.Count > 0)
                {
                    if (txtoldpassword.Text == dsEmp.Tables["users"].Rows[0]["Password"].ToString())
                    {

                        
                    }
                    else
                    {
                        lblmsg.Text = "Invalid old password.";
                        txtoldpassword.Focus();
                        return;
                    }
                }
                else
                {
                    lblmsg.Text = "Invalid Email ID.";
                    return;

                }
            }



            if (txtnewpassword.Text.Trim() == "")
            {
                lblmsg.Text = "Password should not be blank."; txtnewpassword.Focus(); return;
            }
            if (txtnewpassword.Text != txtconfirmpassword.Text)
            {
                lblmsg.Text = "New password and confirm password must be same."; txtconfirmpassword.Focus(); return;
            }

            string strUpdate = "Update usermaster set password='" + txtnewpassword.Text.Replace("'", "''") + "',ChangePasswordDate=getdate() where emailid='" + TxtEmailID.Text + "' ";

            strUpdate = objdb.ExecuteInsertUpdate(strUpdate);
            if (strUpdate == "" || strUpdate == null || strUpdate == "0")
            {
                lblmsg.Text = "Error : " + objdb.returnMsg; return;
            }

            this.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script language=\"javaScript\">" + "alert('Password changes successfully, please relogin!');" + "window.location.href='login.aspx';" + "<" + "/script>");

            //lblmsg.Text = "Password changes successfully, please relogin.";
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error : " + ex.Message.ToString();
        }
    }
}
