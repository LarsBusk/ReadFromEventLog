using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFromEventLog
{
  class LicenseLogEntry
  {
#region Constants

    const string DateTimeIdentifier = "License issued at:";

    const string SerialNumberIdentifier = "Instrument serial number:";

    const string UserIdentifier = "By user:";

#endregion

#region Public properties

    public DateTime EntryDateTime { get; set; }

    public string SerialNumber { get; set; }

    public string User { get; set; }

    public string Message { get; set; }

#endregion

#region Public methods

    public LicenseLogEntry(string message)
    {
      this.Message = message;

      GetMessageParts(message);
    }

#endregion

    private void GetMessageParts(string message)
    {
      string[] messageParts = message.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

      foreach (string messagePart in  messageParts)
      {
        if (messagePart.StartsWith(DateTimeIdentifier))
        {
          string dateString = messagePart.Substring(DateTimeIdentifier.Length);
          this.EntryDateTime = DateTime.Parse(dateString, new CultureInfo("da-DK"));
        }

        if (messagePart.StartsWith(SerialNumberIdentifier))
        {
          this.SerialNumber = messagePart.Substring(SerialNumberIdentifier.Length);
        }

        if (messagePart.StartsWith(UserIdentifier))
        {
          this.User = messagePart.Substring(UserIdentifier.Length);
        }
      }
    }

    public override string ToString()
    {
      return string.Format("Serialnumber: {0} Date: {1}", this.SerialNumber, this.EntryDateTime);
    }
  }
}
