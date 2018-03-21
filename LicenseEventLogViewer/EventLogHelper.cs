using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFromEventLog
{
  class EventLogHelper
  {
    public List<LicenseLogEntry> LicenseLogEntries { get; set; } 

    //private const string 
    private readonly EventLog licenseEventLog;

    public EventLogHelper()
    {
      licenseEventLog = EventLog.GetEventLogs("foss6060.foss.net").First(e => e.LogDisplayName.Equals("FOSS License"));
      LicenseLogEntries = new List<LicenseLogEntry>();
      ReadFromLog();
    }

    private void ReadFromLog()
    {
      foreach (EventLogEntry entry in licenseEventLog.Entries)
      {
        LicenseLogEntries.Add(new LicenseLogEntry(entry.Message));
      }
    }
  }
}
