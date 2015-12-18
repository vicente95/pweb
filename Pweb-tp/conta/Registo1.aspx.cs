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

public partial class conta_Registo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       /* string[] Piratas = { "vitor" };
        string[] Grumetes = { "andre" };

        CriarCategorias(sender, e);

        Roles.AddUsersToRole(Piratas, "unitario");
        Roles.AddUsersToRole(Grumetes, "coletivo");
    }
    
    protected void CriarCategorias(object sender, EventArgs e)
    {
        string[] Categorias = { "unitario", "coletivo" };
      
        foreach (string cat in Categorias)
            if (!Roles.RoleExists(cat))
            {
                Roles.CreateRole(cat);
             
            }
        return;*/
    }

    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {


        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        TextBox nome = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("UserName");
        TextBox email = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Email");

        String command = "INSERT INTO [Utilizador] ([nome], [Email]) VALUES (@nome, @email)";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(command, con);
        cmd.Parameters.AddWithValue("@nome", nome.Text);
        cmd.Parameters.AddWithValue("@email", email.Text);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

}
   

}