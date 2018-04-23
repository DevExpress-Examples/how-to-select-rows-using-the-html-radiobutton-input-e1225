using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxGridView;

namespace WebApplication9
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ASPxGridView1_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            ((ASPxGridView)sender).Selection.UnselectAll();

            string[] pars = e.Parameters.Split(';');
            int index = Convert.ToInt32(pars[0]);
            bool isSelected = Convert.ToBoolean(pars[1]);

            if (isSelected)
            {
                ((ASPxGridView)sender).Selection.SelectRow(index);
            }


        }
        protected void ASPxGridView1_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType == GridViewRowType.Data)
            {

                GridViewDataColumn col = ((ASPxGridView)sender).Columns["Description"] as GridViewDataColumn;
                HtmlInputRadioButton btn = ((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, col, "group1") as HtmlInputRadioButton;
                btn.Checked = ((ASPxGridView)sender).Selection.IsRowSelected(e.VisibleIndex);
                btn.Attributes.Add("onclick", "grid.PerformCallback(" + e.VisibleIndex.ToString() + "+';'+this.checked)");
            }
        }
    }
}
