using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void registerButton_Click(object sender, EventArgs e)
    {
        RegisterFan();
    }

    protected void RegisterFan()
    {
        FanServices.ServiceClient register = new FanServices.ServiceClient();
        string fanName = userTextBox.Text;
        string fanEmail = emailTextBox.Text;
        string fanPassword = passTextBox.Text;

        bool result = register.RegisterFan(fanName, fanEmail, fanPassword);
        if (result)
        {
            Response.Redirect("showExplorer.aspx");
        }
        else
        {
            errorLabel.Text = "Registration Failed";
        }
    }
}