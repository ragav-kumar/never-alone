using UnityEngine;
using System;

namespace NeverAlone.Core
{
	/// <summary>
	/// Defines the "type" of this species, as a three-tuple
	/// </summary>
	[Serializable]
	public struct Affinity
	{
		[Tooltip("Massiveness, solidity")]
		[Range(0, 1)] public float mass;
		
		[Tooltip("High energy (hot, fast) vs Low energy (cold, slow)")]
		[Range(0, 1)] public float energy;
		
		[Tooltip("Concreteness vs abstraction")]
		[Range(0, 1)] public float abstraction;

		[Tooltip("Shorthand name for this affinity")]
		public string type;

		public Vector3 AsVector()
		{
			return new Vector3(mass, energy, abstraction);
		}
	}
}
