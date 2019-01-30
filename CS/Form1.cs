using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Collections;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ArrayList selectedColumns;

        private void Form1_Load(object sender, EventArgs e)
        {
            selectedColumns = new ArrayList();

            var list = new BindingList<Item>();
            for (int i = 0; i < 50; i++)
                list.Add(new Item() { Var1 = i, Var2 = i * 10, Var3 = i * 100, Var4 = "Test" + i, Var5 = "Var" + i, Var6 = i.ToString() });
            gridControl1.DataSource = list;
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(new Point(e.X, e.Y));
            if (info.InColumn)
            {
                if (selectedColumns.IndexOf(info.Column.Name, 0, selectedColumns.Count) == -1)
                {
                    info.Column.AppearanceCell.BackColor = Color.Gold;
                    selectedColumns.Add(info.Column.Name);
                }
                else
                {
                    selectedColumns.Remove(info.Column.Name);
                    info.Column.AppearanceCell.BackColor = Color.Transparent;
                }
            }
        }
    }
    public class Item
    {
        public int Var1 { get; set; }
        public int Var2 { get; set; }
        public int Var3 { get; set; }
        public string Var4 { get; set; }
        public string Var5 { get; set; }
        public string Var6 { get; set; }
    }
}