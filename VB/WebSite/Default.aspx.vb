Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxGridView

Namespace WebApplication9
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

		End Sub
		Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
			CType(sender, ASPxGridView).Selection.UnselectAll()

			Dim pars() As String = e.Parameters.Split(";"c)
			Dim index As Integer = Convert.ToInt32(pars(0))
			Dim isSelected As Boolean = Convert.ToBoolean(pars(1))

			If isSelected Then
				CType(sender, ASPxGridView).Selection.SelectRow(index)
			End If


		End Sub
		Protected Sub ASPxGridView1_HtmlRowCreated(ByVal sender As Object, ByVal e As ASPxGridViewTableRowEventArgs)
			If e.RowType = GridViewRowType.Data Then

				Dim col As GridViewDataColumn = TryCast((CType(sender, ASPxGridView)).Columns("Description"), GridViewDataColumn)
				Dim btn As HtmlInputRadioButton = TryCast((CType(sender, ASPxGridView)).FindRowCellTemplateControl(e.VisibleIndex, col, "group1"), HtmlInputRadioButton)
				btn.Checked = (CType(sender, ASPxGridView)).Selection.IsRowSelected(e.VisibleIndex)
				btn.Attributes.Add("onclick", "grid.PerformCallback(" & e.VisibleIndex.ToString() & "+';'+this.checked)")
			End If
		End Sub
	End Class
End Namespace
