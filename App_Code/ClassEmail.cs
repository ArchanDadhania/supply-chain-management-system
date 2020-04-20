using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
/// <summary>
/// Summary description for ClassEmail
/// </summary>
public class ClassEmail
{
	public ClassEmail()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string SendMail(String FromId, String ToId, String Sub, String Body)
    {
        try
        {
            MailMessage MailMsg = new MailMessage(new MailAddress("a.epmo@yahoo.com"), new MailAddress("xyz@abc.com"));
            MailMsg.To.Clear();
            String a = ",";
            char mc = a[0];
            String[] mTo = ToId.ToString().Split(mc);
            for (int i = 0; i <= mTo.Length - 1; i++)
            {
                if (mTo[i].ToString() != "")
                    MailMsg.To.Add(mTo[i]);
            }

            MailMsg.Subject = Sub;
            MailMsg.Body = Body;
            MailMsg.Priority = MailPriority.Normal;
            MailMsg.IsBodyHtml = true;

            //'Smtpclient to send the mail message
            SmtpClient SmtpMail = new SmtpClient();
            SmtpMail.Host = "smtp.mail.yahoo.com";
            SmtpMail.Port = 25;
            SmtpMail.Credentials = new System.Net.NetworkCredential("a.epmo@yahoo.com", "abcd123");
            SmtpMail.Send(MailMsg);
            return "OK";
        }
        catch (Exception ex)
        {
            return "ERR";
        }
    }
}
