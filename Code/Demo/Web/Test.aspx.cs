using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo.Web
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_OK_Click(object sender, EventArgs e)
        {
            Alert.Show("你好 FineUI！", MessageBoxIcon.Warning);
        }
    }
}