using UnityEngine;
using System;

namespace NeverAlone.Core
{
	/// <summary>
	/// Species-level statistics.
	/// </summary>
	[Serializable]
	public struct Stats
	{
		/// <summary>
		/// Effect:	Determines max HP; Resistance to mass-based effects.
		/// AI:		Ability to act normally when at high fatigue or low HP.
		/// </summary>
		[Range(0, 999)] public int vitality;
		/// <summary>
		/// Effect:	Determines max fatigue.
		/// AI:		Action frequency.
		/// </summary>
		[Range(0, 999)] public int stamina;
		/// <summary>
		/// Effect:	Skill range, stealth penetration.
		/// AI:		Accuracy; Chance to automatically use an offensive move during window of opportunity.
		/// </summary>
		[Range(0, 999)] public int perception;
		/// <summary>
		/// Effect:	Resistance to abstraction-based effects.
		/// AI:		Evasion; Chance to automatically use a defensive move during window of opportunity.
		/// </summary>
		[Range(0, 999)] public int intuition;
		/// <summary>
		/// Effect:	AoE of area skills and auras; Resistance to energy-based effects.
		/// AI:		Effects enemy AI targeting priority.
		/// </summary>
		[Range(0, 999)] public int presence;
		/// <summary>
		/// Effect:	Damage / Effectiveness of all skills.
		/// AI:		Effects
		/// </summary>
		[Range(0, 999)] public int will;
		
		public Stats(int vitality, int stamina, int perception, int intuition, int presence, int will)
		{
			this.vitality = vitality;
			this.stamina = stamina;
			this.perception = perception;
			this.intuition = intuition;
			this.presence = presence;
			this.will = will;
		}
	}
}