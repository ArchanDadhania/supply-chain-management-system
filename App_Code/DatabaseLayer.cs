using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DatabaseLayer
/// </summary>
public class DatabaseLayer
{
    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["strConString"].ToString());
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    public string returnMsg;

	public DatabaseLayer()
	{
		//
		// TODO: Add constructor logic here
		//
        returnMsg = "";
	}
    public DataSet GetDataset(string strsql, string strtblname)
    {

        try
        {
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            //  ds.Clear();
            ds = new DataSet();
            da = new SqlDataAdapter(strsql, sqlCon);
            da.Fill(ds, strtblname);
            returnMsg = "";
            return ds;
        }
        catch (SqlException oleex)
        {
            returnMsg = oleex.Message;
            return null;
        }
        catch (System.Exception exp)
        {
            returnMsg = exp.Message;
            return null;
        }
    }
    public string ExecuteScaler(string strsql)
    {

        try
        {
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            cmd = new SqlCommand(strsql, sqlCon);
            returnMsg = "";
            return Convert.ToString(cmd.ExecuteScalar());
        }
        catch (SqlException oleex)
        {
            returnMsg = oleex.Message;
            return null;
        }
        catch (System.Exception exp)
        {
            returnMsg = exp.Message;
            return null;
        }
    }

    public string ExecuteInsertUpdate(string strsql)
    {

        try
        {
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            cmd = new SqlCommand(strsql, sqlCon);
            returnMsg = "";
            return Convert.ToString(cmd.ExecuteNonQuery());
        }
        catch (SqlException oleex)
        {
            returnMsg = oleex.Message;
            return "";
        }
        catch (System.Exception exp)
        {
            returnMsg = exp.Message;
            return "";
        }
    }

    public SqlDataReader ExecuteDataReader(string strsql)
    {
        try
        {
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            cmd = new SqlCommand(strsql, sqlCon);
            returnMsg = "";
            return cmd.ExecuteReader();
        }
        catch (SqlException oleex)
        {
            returnMsg = oleex.Message;
            return null;
        }
        catch (System.Exception exp)
        {
            returnMsg = exp.Message;
            return null;
        }
    }

    public void FillDropDownList(DropDownList ddlSample, string sqlQuery, string TextField, string ValueField)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = GetDataset(sqlQuery, "FillDLL");
            if (ds != null)
            {
                ddlSample.DataSource = ds;
                ddlSample.DataTextField = TextField;
                ddlSample.DataValueField = ValueField;
                ddlSample.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
        ddlSample.Items.Insert(0, new ListItem("--Select--", "-1"));
    }

}
