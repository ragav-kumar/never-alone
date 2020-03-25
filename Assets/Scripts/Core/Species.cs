using UnityEngine;


namespace NeverAlone.Core
{
	/// <summary>
	/// Species-level data
	/// </summary>
	public class Species : MonoBehaviour
	{
		// Serialized fields
#pragma warning disable 0649
		[SerializeField] Affinity affinity;
		[SerializeField] Stats stats;
#pragma warning restore 0649
		public Affinity GetAffinity() { return affinity; }
		public Stats GetStats() { return stats; }
	}
}
