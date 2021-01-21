using System;

namespace Retro.Model
{
  internal abstract class Record
  {
    public string Description { get; set; }

    public DateTime Date { get; set; }

    protected Record(string description, DateTime date)
    {
      Description = description;
      Date = date;
    }

    public override string ToString()
    {
      return $"{Date:dd.MM.yyyy HH:mm} -> {Description}";
    }
  }
}