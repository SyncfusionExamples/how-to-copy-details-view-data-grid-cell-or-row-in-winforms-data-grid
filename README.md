# How to copy DetailsViewDataGrid cell or row in WinForms DataGrid (SfDataGrid)?

How to copy DetailsViewDataGrid cell or row in WinForms DataGrid (SfDataGrid)?

# About the sample

In SfDataGrid you can copy the DetailsViewDataGrid data’s based on the contextmenu click events.

```c#
gridViewDefinition.DataGrid.RecordContextMenu = new ContextMenuStrip();
gridViewDefinition.DataGrid.RecordContextMenu.Items.Add("Copy Cell", null, OnCopyCellClicked);
gridViewDefinition.DataGrid.RecordContextMenu.Items.Add("Copy Row", null, OnCopyRowClicked);
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
```
## Requirements to run the demo
 Visual Studio 2015 and above versions
