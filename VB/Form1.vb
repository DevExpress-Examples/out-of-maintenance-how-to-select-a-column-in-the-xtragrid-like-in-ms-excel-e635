Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System.Collections

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private selectedColumns As ArrayList

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' TODO: This line of code loads data into the 'nwindDataSet.Products' table. You can move, or remove it, as needed.
			Me.productsTableAdapter.Fill(Me.nwindDataSet.Products)
			selectedColumns = New ArrayList()

		End Sub

		Private Sub gridView1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles gridView1.MouseDown
			Dim view As GridView = TryCast(sender, GridView)
			Dim info As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
			If info.InColumn Then
				If selectedColumns.IndexOf(info.Column.Name, 0, selectedColumns.Count) = -1 Then
					info.Column.AppearanceCell.BackColor = Color.Gold
					selectedColumns.Add(info.Column.Name)
				Else
					selectedColumns.Remove(info.Column.Name)
					info.Column.AppearanceCell.BackColor = Color.Transparent
				End If
			End If
		End Sub
	End Class
End Namespace