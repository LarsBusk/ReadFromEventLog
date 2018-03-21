using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFromEventLog
{
  class LicenseLogEntry
  {
    const string SerialNumberIdentifier = "Instrument serial number:";

    const string UserIdentifier = "By user:";

    const string CustomerIdentifier = "Customer:";

    public DateTime EntryWrittenDateTime { get; private set; }

    public DateTime LicenseWrittenDate { get; private  set; }

    public string SerialNumber { get; private set; }

    public string User { get; private  set; }

    public string Customer { get; private set; }

    public string Partnumbers { get; private set; }

    public string Message { get; set; }

    public LicenseLogEntry(EventLogEntry entry)
    {
      this.Message = entry.Message;

      this.EntryWrittenDateTime = entry.TimeWritten;

      GetMessageParts(this.Message);
    }

    private void GetMessageParts(string message)
    {
      string[] messageParts = message.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

      foreach (string messagePart in  messageParts)
      {
        if (messagePart.StartsWith(SerialNumberIdentifier))
        {
          this.SerialNumber = messagePart.Substring(SerialNumberIdentifier.Length);
        }

        if (messagePart.StartsWith(UserIdentifier))
        {
          this.User = messagePart.Substring(UserIdentifier.Length);
        }

        if (messagePart.StartsWith(CustomerIdentifier))
        {
          this.Customer = messagePart.Substring(CustomerIdentifier.Length);
        }

        if (messagePart.StartsWith(" - "))
        {
          this.Partnumbers += $"{messagePart}" ;
        }
      }
    }

    public override string ToString()
    {
      return this.Message;
    }
  }
}
