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

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            selectedColumns = New ArrayList()

            Dim list = New BindingList(Of Item)()
            For i As Integer = 0 To 49
                list.Add(New Item() With { _
                    .Var1 = i, _
                    .Var2 = i * 10, _
                    .Var3 = i * 100, _
                    .Var4 = "Test" & i, _
                    .Var5 = "Var" & i, _
                    .Var6 = i.ToString() _
                })
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
        Public Property Var1() As Integer
        Public Property Var2() As Integer
        Public Property Var3() As Integer
        Public Property Var4() As String
        Public Property Var5() As String
        Public Property Var6() As String
    End Class
End Namespace