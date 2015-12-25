﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool nomet = HttpContext.Current.User.Identity.IsAuthenticated;

        if (nomet == true)
        {
            Response.Redirect("~/utilizadores_unitarios/inicio_unitario.aspx");
        }
    }
}