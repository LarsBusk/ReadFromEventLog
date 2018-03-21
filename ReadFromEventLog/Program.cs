using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using ReadFromEventLog.Properties;

namespace ReadFromEventLog
{
  internal class Program
  {
    private static readonly string csvFileName = Settings.Default.CsvFileName;

    private static void Main(string[] args)
    {
      var appEventLog =
        EventLog.GetEventLogs(Settings.Default.LicenseServer).First(e => e.LogDisplayName.Equals("FOSS License"));

      var licenseLogEntries = new List<LicenseLogEntry>();

      foreach (EventLogEntry entry in appEventLog.Entries)
      {
        licenseLogEntries.Add(new LicenseLogEntry(entry));
      }

      foreach (var entry in licenseLogEntries)
      {
        AddToCsv(entry);
      }

     // Console.Read();
    }

    private static void AddToCsv(LicenseLogEntry entry)
    {
      if (!File.Exists(csvFileName))
      {
        CreateLogFile(csvFileName);
      }

      DateTime lastEntryTime = GetLastEntryTime();

      if (entry.EntryWrittenDateTime > lastEntryTime)
      {
        var builder = new StringBuilder();
        builder.Append($"{entry.SerialNumber};");
        builder.Append($"{entry.User};");
        builder.Append($"{entry.Customer};");
        builder.Append($"{entry.EntryWrittenDateTime};");
        builder.Append($"{entry.Partnumbers}\n");

        File.AppendAllText(csvFileName, builder.ToString());
      }
    }

    private static void CreateLogFile(string csvFile)
    {
      Console.WriteLine("Creating file: {0}", csvFile);
      var firstLine = "Serialnumber;IssuedBy;Customer;DateTime;PartNumbers\n";
      File.WriteAllText(csvFile, firstLine);
    }

    private static DateTime GetLastEntryTime()
    {
      DateTime lastEntryDateTime = DateTime.MinValue;
      string[] lines = File.ReadAllLines(csvFileName);
      string[] lastLine = lines[lines.Length - 1].Split(';');
      
      DateTime.TryParse(lastLine[3], out lastEntryDateTime);

      return lastEntryDateTime;
    }
  }
}