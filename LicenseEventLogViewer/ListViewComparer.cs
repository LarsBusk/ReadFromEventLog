using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadFromEventLog
{
  public class ListViewComparer : IComparer
  {
    private int col;

    public ListViewComparer(int column)
    {
      col = column;
    }

    public int Compare(object x, object y)
    {
      DateTime date;
      if (!DateTime.TryParse(((ListViewItem)x).SubItems[col].Text, out date))
      {
        return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
      }

      return DateTime.Compare(
        DateTime.Parse(((ListViewItem) x).SubItems[col].Text),
        DateTime.Parse(((ListViewItem) y).SubItems[col].Text));
    }
  }
}
