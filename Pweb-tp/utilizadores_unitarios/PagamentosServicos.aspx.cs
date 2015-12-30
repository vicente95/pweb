using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class utilizadores_unitarios_PagamentosServicos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ver_pagamento.pagamento(GridView1);
        if (GridView1.Rows.Count == 0)
        {
            Label2.Text = "Não tem registos para pagamentos ainda";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Pesquisa_pagamento_utilizador.Equals(GridView1, TextBox1);

    }
}