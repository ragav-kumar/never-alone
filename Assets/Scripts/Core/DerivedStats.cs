using UnityEngine;
using System;

namespace NeverAlone.Core
{
	/// <summary>
	/// Derived stats for this particular animal
	/// </summary>
	[Serializable]
	public readonly struct DerivedStats
	{
		/// <summary>
		/// [10, 99,999]. 0 HP = dead
		/// </summary>
		public int MaxHp { get; }
		/// <summary>
		/// [10, 99,999].
		/// Depletes over time automatically. Using skills increases fatigue. When fatigue is maxed, skill cooldown is doubled (at minimum).
		/// </summary>
		public int MaxFatigue { get; }
		/// <summary>
		/// Descriptive name for this affinity
		/// </summary>
		public string Type { get; }

		public DerivedStats(Species species)
		{
			// Naive, linear calculation. f: [0,999] -> [10,99999]
			this.MaxHp      = 10 + species.GetStats().vitality * 99989 / 999;
			this.MaxFatigue = 10 + species.GetStats().stamina * 99989 / 999;
			this.Type       = species.GetAffinity().calcType();
		}
	}
}