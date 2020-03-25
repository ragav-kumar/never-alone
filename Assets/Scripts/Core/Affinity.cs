using UnityEngine;
using System;

namespace NeverAlone.Core
{
	[Serializable]
	public struct Affinity
	{
		/// <summary>
		/// Massiveness, solidity
		/// </summary>
		[Range(0, 1)] public float mass;
		/// <summary>
		/// High energy (hot, fast) vs Low energy (cold, slow)
		/// </summary>
		[Range(0, 1)] public float energy;
		/// <summary>
		/// Concretness vs abstraction
		/// </summary>
		[Range(0, 1)] public float abstraction;

		public Affinity(float mass, float energy, float abstraction)
		{
			this.mass = mass;
			this.energy = energy;
			this.abstraction = abstraction;
		}
		public string calcType()
		{
			return "Indeterminate";
		}
	}
}
