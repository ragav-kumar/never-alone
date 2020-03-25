using UnityEngine;

namespace NeverAlone.Core
{
	/// <summary>
	/// A specific member of a species, including current state and genetics
	/// </summary>
	public class Animal : MonoBehaviour
	{
#pragma warning disable 0649
		[SerializeField] Species species;
#pragma warning restore 0649

		// Public properties
		public DerivedStats derivedStats;

		private void Start()
		{
			derivedStats = new DerivedStats(species);
		}
	}
}