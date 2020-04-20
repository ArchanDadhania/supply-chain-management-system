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


public partial class EmployeeRegistration : System.Web.UI.Page
{
    DatabaseLayer objDb = new DatabaseLayer();
    ValidationFunctions objValidation = new ValidationFunctions();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (IsPostBack == false)
            {
                //btnsubmit.Enabled = false;
                //fill user type
                objDb.FillDropDownList(ddlUserType, "select usertype,typeid from usertype", "usertype", "typeid");


                if (Convert.ToString(Session["usertype"]).Length >0)
                {
                    ddlUserType.Text = Convert.ToString(Session["usertype"]);
                }
            }
        }
        catch (Exception ex) { }
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        
        TxtMobile.Text = "";
        TxtOfficeNo.Text = "";
         
        TxtPassword1.Text = "";
        TxtPassword.Text = "";
        
        TxtDisplayName.Text = "";
        TxtEmailID.Text = "";
        TxtWebsite.Text = "";
        TxtExt.Text = "";
        TxtAddress.Text = "";
        btnsubmit.Enabled = false;
        TxtEmailID.Focus();
    }
    protected void txtloginname_TextChanged(object sender, EventArgs e)
    {
        //lblmsg.Text = "";
        //btnsubmit.Enabled = false;
        //if (TxtEmailID.Text.Trim() != "")
        //{
        //    string str = objDb.ExecuteScaler("select count(*) from usermaster where emailid='" + TxtEmailID.Text + "'");
        //    if (str != "" && str != null && str != "0")
        //    {
        //        lblmsg.Text = "Email id already registered, please enter other email id.";
        //        TxtEmailID.Text = "";
        //        TxtEmailID.Focus();
        //    }
        //    else
        //    {
        //        btnsubmit.Enabled = true;
        //        TxtPassword.Focus();
        //    }
        //}
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        try
        {
            // Validation Area
            if (TxtEmailID.Text.Trim() == "")
            {
                lblmsg.Text = "Please enter email id."; return;
            }
            if (objValidation.IsEmail (TxtEmailID.Text) == false)
            {
                lblmsg.Text = "Email id you have entered not in correct format."; return;
                 
            }

            if (TxtEmailID.Text.Trim() != "")
            {
                string str = objDb.ExecuteScaler("select count(*) from usermaster where emailid='" + TxtEmailID.Text + "'");
                if (str != "" && str != null && str != "0")
                {
                    lblmsg.Text = "Email id already registered, please enter other email id.";
                    TxtEmailID.Text = "";
                    TxtEmailID.Focus();
                }
            }

            if (TxtPassword.Text.Trim() == "")
            {
                lblmsg.Text = "Please enter password."; return;
            }
            if (TxtPassword.Text != TxtPassword1.Text)
            {
                lblmsg.Text = "Passwords are not matched, please check."; return;
            }
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
            if (objValidation.IsNumeric(TxtMobile.Text )==false )
            {
                lblmsg.Text = "Only enter numbers in mobile no."; return;
            }
            if (TxtWebsite.Text.Length > 0)
            {
                if (Uri.IsWellFormedUriString(TxtWebsite.Text, UriKind.RelativeOrAbsolute) == false)
                {
                    lblmsg.Text = "Invalid web site url."; return;
                }
            }
            //------------------




            string strInsert = "Insert into usermaster (EmailID, TypeID,DisplayName,Password,MobileNo,OfficeNo,Extension,Address,Website,JoinDate,LastLoginDate,ChangePasswordDate,Active) " +
                "values ('" + TxtEmailID.Text + "'," + ddlUserType.SelectedItem.Value  + ",'" + TxtDisplayName.Text.Replace("'", "''") + "','" + TxtPassword.Text + "','" + TxtMobile.Text.Replace("'", "''") + "','" + TxtOfficeNo.Text.Replace("'", "''") + "','" + TxtExt.Text.Replace("'", "''") +
                "','" + TxtAddress.Text.Replace("'", "''") + "','" + TxtWebsite.Text.Replace("'", "''") +"',getdate(),null,null,1)";

            strInsert = objDb.ExecuteInsertUpdate(strInsert);
            if (strInsert == "" || strInsert == null || strInsert == "0")
            {
                lblmsg.Text = "Error : " + objDb.returnMsg; return;
            }
            this.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script language=\"javaScript\">" + "alert('User registration done successfully!, please login!');" + "window.location.href='login.aspx';" + "<" + "/script>");


            //lblmsg.Text = "User registration done successfully!.";
            //btnreset_Click(null, null);
           
        }
        catch (Exception ex) {
            lblmsg.Text = "Error in Submit : " + ex.Message.ToString();
        }
    }
}
