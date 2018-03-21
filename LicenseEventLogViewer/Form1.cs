using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadFromEventLog
{
  public partial class Form1 : Form
  {
    private EventLogHelper helper;

    public Form1()
    {
      InitializeComponent();
      helper = new EventLogHelper();
      PopulateView();
    }

    private void PopulateView()
    {
      LicenseListView.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));

      // Set the view to show details.
      LicenseListView.View = View.Details;
      // Allow the user to edit item text.
      LicenseListView.LabelEdit = true;
      // Allow the user to rearrange columns.
      LicenseListView.AllowColumnReorder = false;
      // Display check boxes.
      //LicenseListView.CheckBoxes = true;
      // Select the item and subitems when selection is made.
      LicenseListView.FullRowSelect = true;
      // Display grid lines.
      LicenseListView.GridLines = true;
      // Sort the items in the list in ascending order.
      LicenseListView.Sorting = SortOrder.Ascending;

      LicenseListView.ColumnClick += LicenseListView_ColumnClick;

      LicenseListView.Columns.Add("No", -2, HorizontalAlignment.Left);
      LicenseListView.Columns.Add("Serialnumber", -2, HorizontalAlignment.Left);
      LicenseListView.Columns.Add("Date", -2, HorizontalAlignment.Left);

      foreach (var licenseLogEntry in helper.LicenseLogEntries)
      {
        ListViewItem item = new ListViewItem("1", 0);
        item.SubItems.Add(licenseLogEntry.SerialNumber);
        item.SubItems.Add(licenseLogEntry.EntryDateTime.ToString("F"));
        item.Tag = licenseLogEntry;
        LicenseListView.Items.Add(item);
      }
    }

    void LicenseListView_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      LicenseListView.ListViewItemSorter=new ListViewComparer(e.Column);
    }

    private void CloseButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
