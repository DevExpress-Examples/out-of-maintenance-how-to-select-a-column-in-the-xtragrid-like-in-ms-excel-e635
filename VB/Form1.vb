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
			selectedColumns = New ArrayList()

			Dim list = New BindingList(Of Item)()
			For i As Integer = 0 To 49
				list.Add(New Item() With {.Var1 = i, .Var2 = i * 10, .Var3 = i * 100, .Var4 = "Test" & i, .Var5 = "Var" & i, .Var6 = i.ToString()})
			Next i
			gridControl1.DataSource = list
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
	Public Class Item
		Private privateVar1 As Integer
		Public Property Var1() As Integer
			Get
				Return privateVar1
			End Get
			Set(ByVal value As Integer)
				privateVar1 = value
			End Set
		End Property
		Private privateVar2 As Integer
		Public Property Var2() As Integer
			Get
				Return privateVar2
			End Get
			Set(ByVal value As Integer)
				privateVar2 = value
			End Set
		End Property
		Private privateVar3 As Integer
		Public Property Var3() As Integer
			Get
				Return privateVar3
			End Get
			Set(ByVal value As Integer)
				privateVar3 = value
			End Set
		End Property
		Private privateVar4 As String
		Public Property Var4() As String
			Get
				Return privateVar4
			End Get
			Set(ByVal value As String)
				privateVar4 = value
			End Set
		End Property
		Private privateVar5 As String
		Public Property Var5() As String
			Get
				Return privateVar5
			End Get
			Set(ByVal value As String)
				privateVar5 = value
			End Set
		End Property
		Private privateVar6 As String
		Public Property Var6() As String
			Get
				Return privateVar6
			End Get
			Set(ByVal value As String)
				privateVar6 = value
			End Set
		End Property
	End Class
End Namespace