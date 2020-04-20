using System;
using System.Data ;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TransferStoockCompnay : System.Web.UI.Page
{
    DatabaseLayer objDb = new DatabaseLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        //
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
            TxtOrderNo.Text = "";
            TxtProductCode.Text = "";

            if (Request.QueryString.Count > 0)
            {
                string str = "update orderdetails set OrderSent='Sent' where OrderDetailId=" + Convert.ToString(Request.QueryString["id"]);
                string s1 = objDb.ExecuteInsertUpdate(str);
            }


            DisplayGrid();
            DisplayGridDone();
        }
        catch (Exception ex)
        {
            //lblmsg.Text = "Error : " + ex.Message.ToString();
        }
    }

    public void DisplayGrid()
    {
        try
        {
            string strReqType = "";
            string strCode = "";
            string strName = "";
            if (TxtOrderNo.Text.Length > 0)
            {
                strCode = " and OrderID = " + TxtOrderNo.Text + " ";
            }
            if (TxtProductCode.Text.Length > 0)
            {
                strName = " and OrderProductId  =" + TxtProductCode.Text + " ";
            }



            string str = "select OrderID as [Order ID], OrderDate as [Order Date],  OrderDistributorID as [Distributor], ProductName as [Product], OrderQty as [Quantity], OrderDetailId as [ ] from ordermaster,orderdetails,ProductMaster,WarehouseMaster where WarehouseID =  OrderWarehouseID and OrderProductId=ProductID and  orderid=OrderMasterId and ProductCompanyID = " + Convert.ToString(Session["UserID"]) + " and OrderSent='Pending' " + strCode + strName + " order by OrderID ";
            DataSet dsGrid = new DataSet();
            dsGrid = objDb.GetDataset(str, "griddata");
            ViewState["griddata"] = dsGrid;
            grv1.DataSource = dsGrid;
            grv1.DataBind();

            lblmsg1.Text = dsGrid.Tables["griddata"].Rows.Count.ToString() + " Pending Records found";
        }
        catch (Exception ex)
        { //lblmsg.Text = "Error : " + ex.Message.ToString(); 
        }
    }

    public void DisplayGridDone()
    {
        try
        {
            string strReqType = "";
            string strCode = "";
            string strName = "";
            if (TxtOrderNo.Text.Length > 0)
            {
                strCode = " and OrderID = " + TxtOrderNo.Text + " ";
            }
            if (TxtProductCode.Text.Length > 0)
            {
                strName = " and OrderProductId = " + TxtProductCode.Text + " ";
            }



            string str = "select OrderID as [Order ID], OrderDate as [Order Date],  OrderDistributorID as [Distributor], ProductName as [Product], OrderQty as [Quantity]  from ordermaster,orderdetails,ProductMaster,WarehouseMaster where WarehouseID =  OrderWarehouseID and OrderProductId=ProductID and  orderid=OrderMasterId and ProductCompanyID = " + Convert.ToString(Session["UserID"]) + " and Ordersent='Sent' " + strCode + strName + " order by OrderID ";
            DataSet dsGrid = new DataSet();
            dsGrid = objDb.GetDataset(str, "griddatadone");
            ViewState["griddatadone"] = dsGrid;
            grv2.DataSource = dsGrid;
            grv2.DataBind();

            lblmsg2.Text = dsGrid.Tables["griddatadone"].Rows.Count.ToString() + " Done Records found";
        }
        catch (Exception ex)
        { //lblmsg.Text = "Error : " + ex.Message.ToString(); 
        }
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Warehousemaster.aspx");
    }

    protected void grv1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
            string s1 = "";
            s1 = "<a href=TransferStoockCompnay.aspx?id=" + e.Row.Cells[5].Text + ">Sent It</a>";
            e.Row.Cells[5].Text = s1;
        }
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        DisplayGrid();
        DisplayGridDone();
    }

    protected void grv1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataSet dsGrid = new DataSet();

        dsGrid = (DataSet)ViewState["griddata"];
        grv1.DataSource = dsGrid;
        grv1.DataBind();
        grv1.PageIndex = e.NewPageIndex;
    }
}
