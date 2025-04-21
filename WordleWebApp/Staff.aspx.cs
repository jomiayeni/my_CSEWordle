using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WordleLogic;

namespace WordleWebApp
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addWordBtn_Click(object sender, EventArgs e)
        {
            string word = enterWordHereTB.Text;
            try
            {
                if((!Logic.IsValidGuess(Server.MapPath("~/App_Data/words.txt"), word)) && (word.Length == 5))
                {
                    using (StreamWriter sw = new StreamWriter(Server.MapPath("~/App_Data/words.txt"), append: true))
                    {
                        sw.WriteLine(word);
                    }
                    WordAddedLbl.Text = "Word added";
                }
                else if (Logic.IsValidGuess(Server.MapPath("~/App_Data/words.txt"), word))
                {
                    WordAddedLbl.Text = "Word exists!";
                }
                else
                {
                    WordAddedLbl.Text = "Invalid word!";
                }
            }catch (Exception error)
            {
                Console.WriteLine(error);

            }
            
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}