using System;

namespace Retro.Dto
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

      return $"To '{ToWho}' with description: '{Description}'";
    }
  }
}