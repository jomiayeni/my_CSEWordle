using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WordleWebApp
{
    public partial class HashPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnHash_Click(object sender, EventArgs e)
        {
            lblOutput.Text = Security.PasswordHasher.HashPassword(txtInput.Text);
        }
    }
}