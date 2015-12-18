using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class utilizadores_unitarios_inicio_unitario : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        utilizadores.BindGrid(GridView1);

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}