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

public partial class ViewRequestbyEmp : System.Web.UI.Page
{
    DatabaseLayer objdb = new DatabaseLayer();
    public static string Sql;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if(Session["EmpCode"]==null)
            {
                Response.Redirect("login.aspx"); 
            }
            if (IsPostBack == false)
            {
                objdb.FillDropDownList(ddlreqtype, "select ReqIypeId, ReqType from ReqTypeMaster", "Reqtype", "ReqIypeId");
            }

            string stradmin = "";
            if (Session["EmpDept"] == "Administrator")
            {
                stradmin = " ";
            }
            else
            {
                stradmin = " and ReqByEmpCode='" + Session["EmpCode"].ToString() + "'";
            }


            RefreshGrid("select ReqID, Request, convert(varchar,Req_Date,106) as [Request Date], ReqStatus from RequestMaster where 1=1 " + stradmin);
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnopenshow_Click(object sender, EventArgs e)
    {

        string stradmin = "";
        if (Session["EmpDept"].ToString() == "Administrator")
        {
            stradmin = " ";
        }
        else
        {
            if (Session["EmpDept"].ToString() == "IT")
            {
                stradmin = " and AllotoEmpCode='" + Session["EmpCode"].ToString() + "'";
            }
            else
            {
                stradmin = " and ReqByEmpCode='" + Session["EmpCode"].ToString() + "'";
            }
        }


        RefreshGrid("select ReqID, Request, convert(varchar,ReqDate,106) as [Request Date], ReqStatus from RequestMaster where 1=1 and reqstatus='Open' " + stradmin);


        //RefreshGrid("select Req_ID, Request, convert(varchar,Req_Date,106), Req_Status from Request_Master where req_status='Open' and Req_by='" + Session["EmpCode"].ToString() + "'");
    }

    public void RefreshGrid(string str)
    {
        try
        {
            if (str != "")
            {
                string s = "";
                s = (ddlreqtype.SelectedIndex == 0 ? "" : " and ReqTypeMasterID=" + ddlreqtype.SelectedItem.Value + "");
                str = str + " " + s;
                Sql = str;
                DataSet dstemp = new DataSet();
                dstemp = objdb.GetDataset(str, "GridDs");
                grvRequest.DataSource = dstemp;
                grvRequest.DataBind();
            }
            else
            {
                Sql = str;
                DataSet dstemp = new DataSet();
                dstemp = objdb.GetDataset(Sql, "GridDs");
                grvRequest.DataSource = dstemp;
                grvRequest.DataBind();
            }
        }
        catch (Exception ex) { }
    }
    protected void btnprogress_Click(object sender, EventArgs e)
    {
        string stradmin = "";
        if (Session["EmpDept"].ToString() == "Administrator")
        {
            stradmin = " ";
        }
        else
        {
            if (Session["EmpDept"].ToString() == "IT")
            {
                stradmin = " and AllotoEmpCode='" + Session["EmpCode"].ToString() + "'";
            }
            else
            {
                stradmin = " and ReqByEmpCode='" + Session["EmpCode"].ToString() + "'";
            }
        }


        RefreshGrid("select ReqID, Request, convert(varchar,ReqDate,106) as [Request Date], ReqStatus from RequestMaster where 1=1 and reqstatus='Progress' " + stradmin);

        //RefreshGrid("select Req_ID, Request, convert(varchar,Req_Date,106), Req_Status, Allo_To from Request_Master where req_status='Progress' and Req_by='" + Session["EmpCode"].ToString() + "'");
    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        string stradmin = "";
        if (Session["EmpDept"].ToString() == "Administrator")
        {
            stradmin = " ";
        }

        else
        {
            if (Session["EmpDept"].ToString() == "IT")
            {
                stradmin = " and AllotoEmpCode='" + Session["EmpCode"].ToString() + "'";
            }
            else
            {
                stradmin = " and ReqByEmpCode='" + Session["EmpCode"].ToString() + "'";
            }
        }


        RefreshGrid("select ReqID, Request, convert(varchar,ReqDate,106) as [Request Date], convert(varchar,CloseDate,106) as [Closed Date], ReqStatus from RequestMaster where 1=1 and reqstatus='Closed' " + stradmin);


        //RefreshGrid("select Req_ID, Request, convert(varchar,Req_Date,106) as 'Req. Date', Req_Status, Allo_To 'Closed By',convert(varchar, Close_Date,106) as 'Closed Date' from Request_Master where req_status='Close' and Req_by='" + Session["EmpCode"].ToString() + "'");
    }
    protected void grvRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvRequest.PageIndex = e.NewPageIndex;
        RefreshGrid("");
    }
    protected void grvRequest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
            string s1 = "";
            s1 = "<a href=JavaScript:newPopup('request.aspx?id=" + e.Row.Cells[0].Text + "')>" + e.Row.Cells[0].Text + "</a>";
            e.Row.Cells[0].Text = s1;
        }
    }
}
