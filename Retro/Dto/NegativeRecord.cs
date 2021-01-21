using System;

namespace Retro.Dto
{
  internal class NegativeRecord : Record
  {
    public NegativeRecord(string description, DateTime date) : base(description, date)
    {
    }
  }
}