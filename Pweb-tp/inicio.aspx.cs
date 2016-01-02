using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;


public partial class inicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*bool nomet = HttpContext.Current.User.Identity.IsAuthenticated;

        if (nomet == true)
        {
            Response.Redirect("~/utilizadores_unitarios/inicio_unitario.aspx");
        }*/
       /* string[] Categorias = {"administrador" };

        foreach (string cat in Categorias)
            if (!Roles.RoleExists(cat))
            {
                Roles.CreateRole(cat);

            }
        string[] Por = { "administrator" };
        Roles.AddUsersToRole(Por, "administrador");*/
    }
}