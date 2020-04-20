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
using System.Globalization;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for ValidationFunctions
/// </summary>
public class ValidationFunctions
{
    public string returnMsg;
    public static string[] SpecialCharacter = { "`", "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "=", "+", "|", "\\", "}", "{", "[", "]", "/", ">", ".", "<", "," };
    
    public const string MatchEmailPattern = 
			@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
     + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";



	public ValidationFunctions()
	{
		//
		// TODO: Add constructor logic here
		//
        returnMsg = "";
	}

    public string ConvertMyDateFormat(string str)
    {
        try
        {
            if (str == "")
            {
                return "";
            }
            if (str.Length < 6)
            {
                returnMsg = "Invalide Date";
                return "";
            }
            if (str.Length > 11)
            {
                returnMsg = "Invalide Date";
                return "";
            }
            string s = "";
            s = str.Replace("/", "-");
            s = str.Replace(".", "-");

            string[] s1 = s.Split('-');

            if (s1.Length == 3)
            {
                try
                {
                    if (s1[1].Length == 3)
                    {
                        return str;
                    }
                    DateTime d2 = Convert.ToDateTime(s1[2].ToString() + "-" + s1[1].ToString() + "-" + s1[0].ToString());
                    return d2.ToString("dd-MMM-yyyy");
                }
                catch (Exception ex2)
                {
                    returnMsg = ex2.Message.ToString();
                    return "";
                }
            }
            else
            {
                returnMsg = "Invalide Date";
                return "";
            }

        }
        catch (Exception ex)
        {
            string s = ex.Message.ToString();
            returnMsg = "Invalide Date";
            return "";
        }
    }
    public Boolean IsValideCharacter(string str)
    {
        try
        {
            string s = "";
            for (int i = 0; i < SpecialCharacter.Length; i++)
            {
                s = SpecialCharacter[i];
                if (str.Contains(s) == true)
                {
                    returnMsg = "Special symbols not allowed.";
                    return false;
                }
            }
            returnMsg = "";
            return true;
        }
        catch (Exception ex)
        {
            returnMsg = ex.Message.ToString();
            return false;
        }
    }
    public Boolean IsNumeric(string str1)
    {
        try
        {
            char[] str = str1.ToCharArray();
            returnMsg = "";
            string s = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] < 48 || str[i] > 57)
                {
                    return false;
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            returnMsg = ex.Message.ToString();
            return false;
        }
    }

    public Boolean IsEmail(string email)
      {
         if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
         else return false;
      }
}


