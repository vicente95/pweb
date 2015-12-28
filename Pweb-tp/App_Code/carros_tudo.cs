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
/// Summary description for carros
/// </summary>
public class carros_tudo
{
    public static void carro(GridView ddl)
    {
        //griedview da página dadoscarros
        // TODO: Add constructor logic here
        //
        string constring = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        int n_cont = 0;
        n_cont = id_utilizador.id_utiliza(n_cont);

        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT [modelo], [marca], [matricula] FROM [Carro] WHERE [id_utilizador] = @status", con))
            {

                cmd.Parameters.AddWithValue("@status", n_cont);

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