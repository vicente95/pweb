using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.Configuration;

/// <summary>
/// Summary description for utilizadores
/// </summary>
public class utilizadores
{
    public static void BindGrid(GridView ddl)
    {
        ddl.SelectedIndex = -1;
        string nome = HttpContext.Current.User.Identity.Name.ToString();
        string constring = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT [Nome], [Email], [N_contribuinte], [Tipo_utilizador] FROM [Utilizador] WHERE [nome] = @status", con))
            {

                cmd.Parameters.AddWithValue("@status", nome);

                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        ddl.DataSource = dt;
                        ddl.DataBind();
                    }
                }
            }
        }
    }
    
}