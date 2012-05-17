using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;
using System.Net.Mail;
using System.IO;
using System.Text;


namespace DecemberWeb
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        private const string TEXT_SEPARATOR = "*********************************************";

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

            //TODO: Collect Exception Details
            StringBuilder strInfo = new StringBuilder();
            strInfo.Append(DateTime.Now.ToString() + " : " + exc.ToString());

            //Collect Server Variables
            for (int i = 0; i < Request.ServerVariables.Count; i++)
            {
                exc.Data.Add(Request.ServerVariables.GetKey(i), Request.ServerVariables.GetValues(i)[0]);
            }

            //Space between exception and variables
            strInfo.AppendFormat(Environment.NewLine);
            strInfo.AppendFormat(Environment.NewLine);

            #region Record the contents of the exception.Data collection

            // Loop through each exception class in the chain of exception objects.
            Exception curException = exc;	// Temp variable to hold InnerException object during the loop.
            do
            {
                if (curException.Data.Count > 0)
                {
                    strInfo.AppendFormat("{0}General Information {0}{1}{0}Additional Info:", Environment.NewLine, TEXT_SEPARATOR);

                    foreach (DictionaryEntry de in curException.Data)
                    {
                        strInfo.AppendFormat("{0}{1}: {2}", Environment.NewLine, "Key: " + de.Key, "  Value: " + de.Value);
                    }
                }

                // Reset the temp exception object and iterate the counter.
                curException = curException.InnerException;

            } while (curException != null);

            #endregion



            //Append all errors into a file
            using (StreamWriter sw = File.AppendText(Server.MapPath("Data/errors.txt")))
            {

                sw.WriteLine();
                sw.WriteLine();
                sw.WriteLine(strInfo.ToString());

                sw.Close();
                
            }
            //Send Email - did not work
            //MailAddress address = new MailAddress("akiander@hotmail.com");
            //MailMessage message = new MailMessage(address, address);
            //message.Subject = "DecemberWeb Error at " + DateTime.Now.ToString();
            //message.Body = ExceptionDetails;

            //try
            //{
            //    SmtpClient client = new SmtpClient("127.0.0.1");
            //    client.Send(message,);
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("Unable to send email. Error is : " + exc.ToString());
            //    Response.Write("Original Error is: " + ExceptionDetails);
            //    Response.Flush();
            //    Response.End();
            //}

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}