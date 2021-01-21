using System.Collections.Generic;

namespace Retro.Model
{
  internal class Retro
  {
    public ICollection<Kudos> Kudos { get; } = new List<Kudos>();

    public ICollection<PositiveRecord> PositiveExperiences { get; } = new List<PositiveRecord>();

    public ICollection<NegativeRecord> NegativeExperiences { get; } = new List<NegativeRecord>();
  }
}