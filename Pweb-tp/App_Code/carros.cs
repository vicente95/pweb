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
public class carros
{
    public static void carro(GridView ddl)
    {
        //
        // TODO: Add constructor logic here
        //
        string nome = HttpContext.Current.User.Identity.Name.ToString();
        string constring = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        string n_cont="";
        String command = "SELECT [N_contribuinte] FROM [Utilizador] WHERE [Nome] = @st";
        SqlConnection conn = new SqlConnection(constring);
        SqlCommand Cm = new SqlCommand(command, conn);
        Cm.Parameters.AddWithValue("@st", nome);
        conn.Open();
        try
        {
            n_cont = (string)Cm.ExecuteScalar();
        }
        catch
        {
            
        }
        conn.Close();

        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT [matricula], [marca], [modelo] FROM [Carro] WHERE [id_utilizador] = @status", con))
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