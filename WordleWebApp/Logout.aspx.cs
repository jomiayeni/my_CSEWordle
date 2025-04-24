using System;
using System.Web;

namespace WordleWebApp
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get logout time
            string logoutTime = DateTime.Now.ToString("f"); // e.g., "Thursday, April 17, 2025 4:32 PM"
            lblLogoutTime.Text = logoutTime;

            // Clear session
            Session.Clear();
            Session.Abandon();

          

        
        }
    }
}
