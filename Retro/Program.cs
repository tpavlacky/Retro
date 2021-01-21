using System;
using System.Collections.Generic;
using System.IO;
using CommandLine;
using Newtonsoft.Json;
using Retro.Model;

namespace Retro
{
  internal class Program
  {
    private static Options _options = new Options();
    private static readonly string _retroFileFullName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "retro.json");

    private static int Main(string[] args)
    {
      return Parser.Default.ParseArguments<Options, DumpOptions, ClearOptions>(args)
        .MapResult(
          (Options opts) => RunAddAndReturnExitCode(opts),
          (DumpOptions opts) => RunDumpAndReturnExitCode(),
          (ClearOptions opts) => RunClearAndReturnExitCode(),
          errs => 1);
    }

    private static int RunAddAndReturnExitCode(Options opts)
    {
      _options = opts;

      var retro = LoadRetroObject();
      AddNewRecord(retro);
      SaveRetroObject(retro);

      return 0;
    }

    private static int RunDumpAndReturnExitCode()
    {
      var retro = LoadRetroObject();

      Console.WriteLine("================== Retro points ==================");
      Console.WriteLine("Positive points:");
      DumpRecords(retro.PositiveExperiences);
      Console.WriteLine();

      Console.WriteLine("Negative points:");
      DumpRecords(retro.NegativeExperiences);
      Console.WriteLine();

      Console.WriteLine("Kudos:");
      DumpRecords(retro.Kudos);

      return 0;
    }

    private static void DumpRecords(IEnumerable<Record> records)
    {
      foreach (var @record in records)
      {
        Console.WriteLine(record.ToString());
      }
    }

    private static int RunClearAndReturnExitCode()
    {
      if (File.Exists(_retroFileFullName))
      {
        File.Delete(_retroFileFullName);
      }

      return 0;
    }

    private static Model.Retro LoadRetroObject()
    {
      if (File.Exists(_retroFileFullName))
      {
        return JsonConvert.DeserializeObject<Model.Retro>(File.ReadAllText(_retroFileFullName));
      }

      return new Model.Retro();
    }

    private static void AddNewRecord(Model.Retro retro)
    {
      var description = _options.Description;
      var date = DateTime.Now;

      if (_options.Positive)
      {
        retro.PositiveExperiences.Add(new PositiveRecord(description, date));
        return;
      }

      if (_options.Negative)
      {
        retro.NegativeExperiences.Add(new NegativeRecord(description, date));
        return;
      }

      if (_options.Kudos)
      {
        retro.Kudos.Add(new Kudos(_options.KudosTarget, description, date));
        return;
      }

      throw new ArgumentOutOfRangeException("Unknown record type");
    }

    private static void SaveRetroObject(Model.Retro retro)
    {
      var serializedObject = JsonConvert.SerializeObject(retro, Formatting.Indented);
      File.WriteAllText(_retroFileFullName, serializedObject);
    }
  }
}
