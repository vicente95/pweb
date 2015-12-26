using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ver_id_parque_carro
/// </summary>
public class ver_id_parque_carro
{
    
    public static int ver_id_carro(string selecione)
    {
        int id_carro;
        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        //
        // TODO: Add constructor logic here
        //
        //ir buscar o id carro selecionado na dropbox para mudar na tabela requesição carro

        String command3 = "SELECT [Id_carro] FROM [Carro] WHERE [matricula] = @s";
        SqlConnection c = new SqlConnection(connectionString);
        SqlCommand cmd3 = new SqlCommand(command3, c);
        cmd3.Parameters.AddWithValue("@s", selecione);

        c.Open();
        id_carro = (int)cmd3.ExecuteScalar();
        c.Close();



        return id_carro;
    }
    public static int ver_id_parque(string nome)
    {
        int id_parque;
        //
        // TODO: Add constructor logic here
        //ir buscar o id do parque mediante o nome
        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        String com = "SELECT Id_parque FROM Parque WHERE nome=@n1";
        SqlConnection coo = new SqlConnection(connectionString);
        SqlCommand cmd7 = new SqlCommand(com, coo);
        cmd7.Parameters.AddWithValue("@n1", nome);

        coo.Open();
        id_parque = (int)cmd7.ExecuteScalar();
        coo.Close();


        return id_parque;
    }
}