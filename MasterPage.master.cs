using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class MasterPage : System.Web.UI.MasterPage
{
    DatabaseLayer objdb = new DatabaseLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //if (Session["EmailID"] == null)
            //{
            //    Response.Redirect("login.aspx");
            //}
            if (IsPostBack == false)
            {
                sp_lbl.InnerHtml = "Welcome : " + Session["DisplayName"].ToString() + " - [<strong>" + Session["UserType"].ToString() + "</strong>], Last Login Date : " + Convert.ToString(Session["LastLoginDate"]);
                CreateMenuBar();

                sp_img_src.InnerHtml = "<img src ='images/" + Convert.ToString(Session["UserTypeID"]) + ".gif' />";
            }
        }
        catch (Exception ex) { }
    }

    public void CreateMenuBar()
    {
        string dept = (Session["UserType"].ToString() == "0" ? "0" : objdb.ExecuteScaler("select TypeID from UserType where UserType='" + Session["UserType"].ToString() + "'"));
        string str = "Select MenuID,MenuHead, PageLiink  from MenuMaster where activeStatus=1 and MenuID in (select MenuMsterId from RightsMaster where UserTypeID=" + dept + ")  order by menuposition";
        DataSet dst = new DataSet();
        dst = objdb.GetDataset(str, "MnuMst");
        MenuItem mnuitem = new MenuItem();
        if (dst != null)
        {
            if (dst.Tables.Count > 0)
            {
                for (int i = 0; i < dst.Tables[0].Rows.Count; i++)
                {
                    mnuitem = new MenuItem();
                    mnuitem.Value = dst.Tables[0].Rows[i][0].ToString();
                    mnuitem.Text = dst.Tables[0].Rows[i][1].ToString();
                    mnuitem.NavigateUrl = dst.Tables[0].Rows[i][2].ToString();

                    mnuMenu.Items.Add(mnuitem);
                }
            }
        }
    }

    protected void lbtnlogout_Click(object sender, EventArgs e)
    {

    }
}
