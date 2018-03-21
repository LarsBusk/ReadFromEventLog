using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsEventTest
{
  class Program
  {
    static void Main(string[] args)
    {
      string source = "Windows event test";
      string log = "Application";
      string myEvent = "Sample event";

      if (!EventLog.SourceExists(source))
        EventLog.CreateEventSource(source, log);
      
      EventLog.WriteEntry(source, myEvent, EventLogEntryType.Warning, 9117,1234);
    }
  }
}
