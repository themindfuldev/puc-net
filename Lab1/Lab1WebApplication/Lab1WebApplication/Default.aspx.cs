using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1WebApplication
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            localhost.Service1 ws = new localhost.Service1();
            ResultLabel.Text = ws.SayHello(NameTextBox.Text);
        }

        protected void ComplexMethodButton_Click(object sender, EventArgs e)
        {
            localhost.Service1 ws = new localhost.Service1();
            GridView1.DataSource = ws.ComplexMethod();
            GridView1.DataBind();
        }

       
    }
}