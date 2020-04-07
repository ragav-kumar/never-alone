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
		[Tooltip(
			"Effect: Determines max HP; Resistance to mass-based effects.\n" +
			"AI: Ability to act normally when at high fatigue or low HP."
			)]
		[Range(0, 999)] public int vitality;

		[Tooltip(
			"Effect: Determines max fatigue. Resistance to neutral effects.\n" +
			"AI: Action frequency."
			)]
		[Range(0, 999)] public int stamina;

		[Tooltip(
			"Effect: Skill range, stealth penetration.\n" +
			"AI: Accuracy; Chance to automatically use an offensive move during window of opportunity."
			)]
		[Range(0, 999)] public int perception;

		[Tooltip(
			"Effect: Resistance to abstraction-based effects.\n" +
			"AI: Evasion; Chance to automatically use a defensive move during window of opportunity."
			)]
		[Range(0, 999)] public int intuition;

		[Tooltip(
			"Effect: AoE of area skills and effects; Resistance to energy-based effects.\n" +
			"AI: Effects enemy AI targeting priority."
			)]
		[Range(0, 999)] public int presence;

		[Tooltip(
			"Effect: Damage / Effectiveness of all skills.\n" +
			"AI: ???"
			)]
		[Range(0, 999)] public int will;
	}
}