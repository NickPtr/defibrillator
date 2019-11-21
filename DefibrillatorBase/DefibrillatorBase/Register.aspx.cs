using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DefibrillatorBase
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginForm.Visible = true;
            
        }

        protected void CreateUser_Click(object sender, EventArgs e)
            {
                // Default UserStore constructor uses the default connection string named: DefaultConnection
                var userStore = new UserStore<IdentityUser>();
                var manager = new UserManager<IdentityUser>(userStore);

                var user = new IdentityUser() { UserName = UserName.Text };
                IdentityResult result = manager.Create(user, Password.Text);

                if (result.Succeeded)
                {
                Response.Redirect("~/Home");
                }
                else
                {
                    //StatusMessage.Text = result.Errors.FirstOrDefault();
                }
            }
        }
    }
