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

public partial class Allocation : System.Web.UI.Page
{
    DatabaseLayer objdb = new DatabaseLayer();
    ValidationFunctions objfun = new ValidationFunctions();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["EmpCode"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (IsPostBack == false)
            {
                objdb.FillDropDownList(ddlreqtype, "select ReqIypeId, ReqType from ReqTypeMaster", "ReqType", "ReqType");
                objdb.FillDropDownList(ddlallocateto, "select EmpCode, Empname from EmpMaster where DepartmentMasterID =2", "Empname", "Empcode");
                txtdatefrom.Text = System.DateTime.Today.ToString("dd-MM-yyyy");
                txttodate.Text = System.DateTime.Today.ToString("dd-MM-yyyy");

                ShowRequestGrid();
            }
        }
        catch (Exception ex) { }

    }
    public void ShowRequestGrid()
    {
        try
        {
            lblmsg.Text = "";
            string datefltr = "";
            string reqtypefltr = "";
            string FromDate = "", Todate = "";
            if (txtdatefrom.Text != "" && txttodate.Text != "")
            {
                FromDate = objfun.ConvertMyDateFormat(txtdatefrom.Text);
                Todate = objfun.ConvertMyDateFormat(txttodate.Text);
            }
            if (FromDate != "" && Todate != "")
            {
                datefltr = " and ReqDate between convert(smalldatetime,'" + FromDate + " 00:01:01') and convert(smalldatetime,'" + Todate + " 23:59:59') ";
            }
            if (ddlreqtype.SelectedValue =="--Select--" || ddlreqtype.SelectedValue =="-1")
            {
                reqtypefltr = " ";
            }
            else
            {
                reqtypefltr = " and ReqTypeMasterID=" + objdb.ExecuteScaler ("select ReqIypeId from ReqTypeMaster where ReqType = '" + ddlreqtype.SelectedItem.Value + "'");
            }

            DataSet dsReq = new DataSet();
            string str = "Select ReqID, ReqType , convert(varchar, ReqDate,106) as [Request Date],ReqStatus as [Status],Request from RequestMaster, ReqTypeMaster where reqstatus='Open' and ReqTypeMasterID=ReqIypeId " + datefltr + " " + reqtypefltr + "  order by ReqID";

            dsReq = objdb.GetDataset(str, "Req_Mst");
            grvRequest.DataSource = dsReq;
            grvRequest.DataBind();

        }
        catch (Exception ex) { lblmsg.Text = "Error in Display request : " + ex.Message.ToString(); }
    }
    protected void btnshow_Click(object sender, EventArgs e)
    {
        ShowRequestGrid();
    }
    protected void grvRequest_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            lblReqID.Text = grvRequest.Rows[e.NewSelectedIndex].Cells[1].Text;
            tblAllocateto.Visible = true;
            ddlallocateto.Focus();
        }
        catch (Exception ex) { lblmsg.Text = "Error : " + ex.Message.ToString(); }
    }
    protected void btnallocate_Click(object sender, EventArgs e)
    {
        try
        {
            if (grvRequest.SelectedIndex < 0)
            {
                lblmsg.Text = "Please select request to allocate."; return;
            }
            if (ddlallocateto.SelectedIndex == 0)
            {
                lblmsg.Text = "Please select Allocate To."; ddlallocateto.Focus(); return;
            }

            string strUpdateReq = "Update RequestMaster set AlloToEmpCode='" + ddlallocateto.SelectedItem.Value + "',AlloDate=getdate(),AlloByEmpCode='" + Session["EmpCode"].ToString() + "',ReqStatus='Progress' where reqID=" + lblReqID.Text;
            strUpdateReq = objdb.ExecuteInsertUpdate(strUpdateReq);
            if (strUpdateReq != "" && strUpdateReq != null && strUpdateReq != "0")
            {
                lblmsg.Text = "Request allocated."; tblAllocateto.Visible = false;

                //send email
                if (ConfigurationManager.AppSettings["sendemail"] == "Y")
                {

                    //get request details
                    DataSet ds = new DataSet();
                    ds = new DataSet();
                    ds = objdb.GetDataset("select * from RequestMaster where  reqID=" + lblReqID.Text, "RequestMaster");
                    DataRow rrm;
                    rrm = ds.Tables["RequestMaster"].Rows[0];


                    //get req by employee details
                    ds = new DataSet();
                    ds = objdb.GetDataset("select * from empmaster where empcode='" + rrm["reqbyempcode"].ToString() + "'", "empmaster");
                    DataRow remp;
                    remp = ds.Tables["empmaster"].Rows[0];

                    //get allocate emp details
                    ds = new DataSet();
                    ds = objdb.GetDataset("select * from empmaster where empcode='" + rrm["AlloToEmpCode"].ToString() + "'", "empmaster");
                    DataRow raemp;
                    raemp = ds.Tables["empmaster"].Rows[0];


                    //get request tat
                    ds = new DataSet();
                    ds = objdb.GetDataset("select * from ReqTypeMaster where ReqIypeId=" + rrm["ReqTypeMasterID"].ToString() + "", "ReqTypeMaster");
                    DataRow r;
                    r = ds.Tables["ReqTypeMaster"].Rows[0];

                    int tat;
                    tat = int.Parse(r["ReqTat"].ToString());

                    string dt = DateTime.Now.AddDays(tat).ToString("dd-MMM-yy hh:mm");

                    //send email

                    string strbody = "Dear " + remp["empname"].ToString() + ",<br><br> Your request no " + lblReqID.Text + " is allocated to " + raemp["empname"].ToString() + ". Your request will be completed on or before " + dt.ToString() + "<br><hr>" +
                        "<b>Request Id : </b>" + lblReqID.Text + "<br>" +
                        "<b>Request Date : </b>" + DateTime.Parse(rrm["ReqDate"].ToString()).ToString("dd-MMM-yy hh:mm") +"<br>" +
                        "<b>Request Type : </b>" + r["reqtype"].ToString() + "<br>" +
                        "<b>Request :</b> " + rrm["request"].ToString() + "<hr>" +

                        "<br><br>Regards<br>RMS Team.";
                    string tomail;
                    tomail = remp["email"].ToString() + "," + raemp["email"].ToString();
                    String Ans = ClassEmail.SendMail(tomail, tomail, "RMS - Request No " + lblReqID.Text + " Allocated", strbody);
                    if (Ans == "OK")
                    {

                    }
                }




                ShowRequestGrid();
            }
            else
            {
                lblmsg.Text = "Error :" + objdb.returnMsg;
            }
        }
        catch (Exception ex) { lblmsg.Text = "Error : " + ex.Message.ToString(); }
    }
    protected void grvRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvRequest.PageIndex = e.NewPageIndex;
        ShowRequestGrid();
    }
    protected void grvRequest_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grvRequest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
            string s1 = "";
            s1 = "<a href=JavaScript:newPopup('request.aspx?id=" + e.Row.Cells[1].Text + "')>" + e.Row.Cells[5].Text + "</a>";
            e.Row.Cells[5].Text = s1;
        }
    }
}
