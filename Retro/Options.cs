using CommandLine;

namespace Retro
{
  [Verb("add", HelpText = "Records retro point")]
  public class Options
  {
    [Option('n', "Negative", SetName = "Negative", HelpText = "Positive experience")]
    public bool Negative { get; set; }

    [Option('p', "Positive", SetName = "Positive", HelpText = "Negative experience")]
    public bool Positive { get; set; }

    [Option('k', "Kudos", SetName = "Kudos", HelpText = "Kudos")]
    public bool Kudos { get; set; }

    [Option('t', "To", HelpText = "Kudos to who?")]
    public string KudosTarget { get; set; }

    [Option('d', "Description", HelpText = "Description", Required = true)]
    public string Description { get; set; }
  }

  [Verb("dump", HelpText = "Writes recorded retro points")]
  class DumpOptions
  {
  }

  [Verb("clear", HelpText = "Removes all recorded retro points")]
  class ClearOptions
  {
  }
}