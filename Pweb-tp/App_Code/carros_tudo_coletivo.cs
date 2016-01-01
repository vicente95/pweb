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
/// Summary description for carros_tudo_coletivo
/// </summary>
public class carros_tudo_coletivo
{
    public static void carro(GridView ddl, TextBox proc)
    {
        //griedview da página dadoscarros
        // TODO: Add constructor logic here
        //
        //ddl.SelectedIndex = -1;
        ddl.DataSource = null;
        ddl.DataBind();
        string constring = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        int n_cont = 0;
        n_cont = id_utilizador.id_utiliza(n_cont);

        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT [modelo], [marca], [matricula], [condutor], [estado] FROM [Carro] WHERE [id_utilizador] = @status AND (Carro.condutor LIKE '%' + @cond + '%')", con))
            {
                cmd.Parameters.AddWithValue("@status", n_cont);
                cmd.Parameters.AddWithValue("@cond", proc.Text);

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