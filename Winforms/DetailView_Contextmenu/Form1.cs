using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DetailView_Contextmenu
{
    public partial class Form1 : Form
    {
        SfDataGrid sfDataGrid1;
        OrderInfoRepository infoRepository;
        GridViewDefinition gridViewDefinition;
        public Form1()
        {
            InitializeComponent();
            sfDataGrid1 = new SfDataGrid();
            infoRepository = new OrderInfoRepository();
            sfDataGrid1.Dock = DockStyle.Fill;
            this.Controls.Add(sfDataGrid1);
            sfDataGrid1.AutoGenerateRelations = false;
            sfDataGrid1.SelectionUnit = SelectionUnit.Row;
            gridViewDefinition = new GridViewDefinition();
            gridViewDefinition.RelationalColumn = "OrderDetails";
            gridViewDefinition.DataGrid = new SfDataGrid() { Name = "FirstLevelNestedGrid", AutoGenerateColumns = true };
            gridViewDefinition.DataGrid.RecordContextMenu = new ContextMenuStrip();
            gridViewDefinition.DataGrid.RecordContextMenu.Items.Add("Copy Cell", null, OnCopyCellClicked);
            gridViewDefinition.DataGrid.RecordContextMenu.Items.Add("Copy Row", null, OnCopyRowClicked);
            sfDataGrid1.DetailsViewDefinitions.Add(gridViewDefinition);
            sfDataGrid1.DataSource = infoRepository.GetOrdersDetails(50);
        }
        private void OnCopyCellClicked(Object sender, EventArgs e)
        {
            var rowindex= this.sfDataGrid1.SelectedDetailsViewGrid.CurrentCell.RowIndex;
            var column = this.sfDataGrid1.SelectedDetailsViewGrid.CurrentCell.ColumnIndex;
            gridViewDefinition.DataGrid.SelectionUnit = Syncfusion.WinForms.DataGrid.Enums.SelectionUnit.Cell;
            sfDataGrid1.SelectedDetailsViewGrid.MoveToCurrentCell(new Syncfusion.WinForms.GridCommon.ScrollAxis.RowColumnIndex(rowindex, column));
            sfDataGrid1.SelectedDetailsViewGrid.ClipboardController.Copy();
        }
        private void OnCopyRowClicked(Object sender, EventArgs e)
        {
            var rowindex = this.sfDataGrid1.SelectedDetailsViewGrid.CurrentCell.RowIndex;
            var column = this.sfDataGrid1.SelectedDetailsViewGrid.CurrentCell.ColumnIndex;
            gridViewDefinition.DataGrid.SelectionUnit = Syncfusion.WinForms.DataGrid.Enums.SelectionUnit.Row;
            sfDataGrid1.SelectedDetailsViewGrid.MoveToCurrentCell(new Syncfusion.WinForms.GridCommon.ScrollAxis.RowColumnIndex(rowindex, column));
            sfDataGrid1.SelectedDetailsViewGrid.ClipboardController.Copy();
        }
    }
}
