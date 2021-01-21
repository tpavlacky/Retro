using System;

namespace Retro.Model
{
  internal class Kudos : Record
  {
    public string ToWho { get; }

    public Kudos(string toWho, string desription, DateTime date) : base(desription, date)
    {
      ToWho = toWho;
    }

    public override string ToString()
    {
      return $"{Date:dd.MM.yyyy HH:mm} -> {GetString()}";
    }

    private string GetString()
    {
      if (string.IsNullOrEmpty(ToWho))
      {
        return Description;
      }

      return $"'{ToWho}' -> '{Description}'";
    }
  }
}