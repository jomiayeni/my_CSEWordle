using Microsoft.Ajax.Utilities;
using System;
using System.Web;
using System.Net;
using WordleWebApp.AuthServiceReference;
using Security;
namespace WordleWebApp
{

    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["myCookieId"];

            if ((myCookies == null) || myCookies["username"] == "")
            {
                // new user or user didn't save username
            }
            else
            {
                txtUsername.Text = myCookies["username"];
            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsernameRegister.Text;
            string password = txtPasswordRegister.Text;
            string confirmPassword = txtPasswordConfirm.Text;

            if (password != confirmPassword)
            {
                lblRegisterError.Text = "Passwords don't match";
                return;
            }

            //create cookie object
            HttpCookie myCookies = new HttpCookie("myCookieId");

            string hashed = PasswordHasher.HashPassword(password);
            Service1Client authClient = new Service1Client();

            // Todo: Handle this better. Maybe return an object with an error message prop
            // instead of just checking the string
            string success = authClient.Register(username, hashed, Server.MapPath("~/App_Data/Users.xml"));
            if (success == "Registration successful.")
            {
                if(saveUsernameCB.Checked)
                {
                    //Storing username and hashed password as cookies if the checkbox is checked written by Alex 4/12
                    myCookies["username"] = username;
                    myCookies["hashedPassword"] = hashed; 
                    myCookies.Expires = DateTime.Now.AddMonths(6);
                    Response.Cookies.Add(myCookies);
                }

                // Store the username so we can display it on Default
                Session["Username"] = username;
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblRegisterError.Text = success;
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string hashed = PasswordHasher.HashPassword(password);
            bool bruh = PasswordHasher.VerifyPassword(password, hashed);

            Service1Client authClient = new Service1Client();

            // Todo: Handle this better. Maybe return an object with an error message prop
            // instead of just checking the string
            string success = authClient.Login(username, hashed, Server.MapPath("~/App_Data/Users.xml"));
            if (success == "Login successful.")
            {
                // Store the username so we can display it on Default
                Session["Username"] = username;
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblError.Text = success;
            }
        }
    }
}
