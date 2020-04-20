using System;
using System.Data ;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserProfiles : System.Web.UI.Page
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
        //display profile data based on login
            DataSet dsEmp = new DataSet();
            dsEmp = objDb.GetDataset("select * from usermaster where emailid='" + Convert.ToString(Session["EmailID"]) + "' and active=1 ", "users");
            if (dsEmp != null)
            {
                if (dsEmp.Tables["users"].Rows.Count > 0)
                {
                    DataRow r = dsEmp.Tables["users"].Rows[0];
                    TxtEmailID.Text = Convert.ToString(r["emailid"]);
                    TxtDisplayName.Text = Convert.ToString(r["displayname"]);
                    TxtMobile.Text = Convert.ToString(r["mobileno"]); 
                    TxtOfficeNo.Text = Convert.ToString(r["officeno"]);
                    TxtExt.Text = Convert.ToString(r["Extension"]);
                    TxtAddress.Text = Convert.ToString(r["address"]);
                    TxtWebsite.Text = Convert.ToString(r["website"]); 
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
        //validate data
        try
        {



            if (TxtDisplayName.Text.Trim() == "")
            {
                lblmsg.Text = "Please enter name."; return;
            }
            if (objValidation.IsValideCharacter(TxtDisplayName.Text) == false)
            {
                lblmsg.Text = "Special characters not allowed in name."; return;

            }
            if (TxtMobile.Text.Trim() == "")
            {
                lblmsg.Text = "Please enter mobile no."; return;
            }
            if (objValidation.IsNumeric(TxtMobile.Text) == false)
            {
                lblmsg.Text = "Only enter numbers in mobile no."; return;
            }

            if (TxtWebsite.Text.Length > 0)
            {
                if (Uri.IsWellFormedUriString(TxtWebsite.Text, UriKind.Absolute) == false)
                {
                    lblmsg.Text = "Invalid web site url."; return;
                }
            }
            //update user profile
            string strqry = "";
            strqry = "update usermaster set displayname='" + TxtDisplayName.Text.Replace("'", "''") + "', mobileno='" + TxtMobile.Text + "',officeno='" + TxtOfficeNo.Text.Replace("'", "''") + "', Extension='" + TxtExt.Text.Replace("'", "''") + "', Address='" + TxtAddress.Text.Replace("'", "''") + "',website='" + TxtWebsite.Text.Replace("'", "''") + "' where emailid = '" + Convert.ToString(Session["EmailID"]) + "'";
            string ret = objDb.ExecuteInsertUpdate(strqry);
            if (ret == "" || ret == null || ret == "0")
            {
                lblmsg.Text = "Error : " + objDb.returnMsg; return;
            }
            lblmsg.Text = "User profile updated successfully!.";
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
}
