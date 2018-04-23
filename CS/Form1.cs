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
            // TODO: This line of code loads data into the 'nwindDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.nwindDataSet.Products);
            selectedColumns = new ArrayList();

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
}