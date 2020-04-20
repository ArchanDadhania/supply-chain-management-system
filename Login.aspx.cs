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

public partial class Login : System.Web.UI.Page
{
    DatabaseLayer objDb = new DatabaseLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                Session["EmailID"] = null;
                Session["DisplayName"] = null;
                Session["LastLoginDate"] = null;
                Session["UserID"] = null;
                txtusername.Focus();
            }
        }
        catch (Exception ex) { }
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {

        




        try
        {
            string strUserType = "";
            if (RdCompany.Checked == true)
            {
                strUserType = "Company";
            }
            if (RdDistributor.Checked == true)
            {
                strUserType = "Distributor";
            }
            if (RdStockist.Checked == true)
            {
                strUserType = "Stock Department";
            }
            string strUserTypeId = objDb.ExecuteScaler("select typeid from  usertype where usertype='" + strUserType + "'");


            DataSet dsEmp = new DataSet();
            dsEmp = objDb.GetDataset("select * from usermaster where emailid='" + txtusername.Text + "' and active=1 and TypeId=" + strUserTypeId, "users");
            if (dsEmp != null)
            {
                if (dsEmp.Tables["users"].Rows.Count > 0)
                {
                    if (txtpassword.Text == dsEmp.Tables["users"].Rows[0]["Password"].ToString())
                    {
                        Session["EmailID"] = txtusername.Text;
                        Session["DisplayName"] = Convert.ToString(dsEmp.Tables["users"].Rows[0]["DisplayName"]);
                        Session["LastLoginDate"] = Convert.ToString(dsEmp.Tables["users"].Rows[0]["LastLoginDate"]);
                        Session["UserID"] = Convert.ToString(dsEmp.Tables["users"].Rows[0]["UserID"]);
                        Session["UserTypeID"] = Convert.ToString(dsEmp.Tables["users"].Rows[0]["TypeId"]);

                        Session["UserType"] = objDb.ExecuteScaler("select usertype from  usertype where typeid=" + dsEmp.Tables["users"].Rows[0]["TypeId"].ToString());

                        //update last login
                        string r=objDb.ExecuteInsertUpdate("update usermaster set lastlogindate=getdate() where emailid='" + txtusername.Text + "' ");

                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        lblmsg.Text = "Invalid password.";
                        txtpassword.Focus();
                    }
                }
                else
                {
                    lblmsg.Text = "Invalid Email ID.";
                    txtusername.Text = "";
                    txtusername.Focus();
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error : " + ex.Message.ToString();
        }
    }
    protected void btnregister_Click(object sender, EventArgs e)
    {
        
        if (RdCompany.Checked == true)
        {
            Session["usertype"] = "Company";
        }
        if (RdDistributor.Checked == true)
        {
            Session["usertype"] = "Distributor";
        }
        if (RdStockist.Checked == true)
        {
            Session["usertype"] = "Stock Department";
        }
        Response.Redirect("Registration.aspx");
    }
}
