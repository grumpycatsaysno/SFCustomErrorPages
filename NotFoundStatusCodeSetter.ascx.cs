using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SitefinityWebApp
{
    public partial class NotFoundStatusCodeSetter : System.Web.UI.UserControl
    {
        protected override void Render(HtmlTextWriter writer)
        {
            if (!this.IsDesignMode())
            {
                base.Render(writer);
                Response.Status = "404 Not Found";
                Response.StatusCode = 404;
            }
            else
            {
                lblMessage.Text = "Sets the response status code to 404 explicitly on the front-end";
            }
        }
    }
}