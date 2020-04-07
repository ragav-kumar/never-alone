using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NeverAlone.Animate
{
	[RequireComponent(typeof(Animation))]
	public class LegacyController : MonoBehaviour, IController
	{
		private const string AnimIdle   = "Anim_Idle";
		private const string AnimRun    = "Anim_Run";
		private const string AnimAttack = "Anim_Attack";
		private const string AnimDamage = "Anim_Damage";
		private const string AnimDie    = "Anim_Death";

		private Animation anim;

		void Start()
		{
			anim = GetComponent<Animation>();
			if (!anim)
			{
				anim = GetComponentInChildren<Animation>();
			}
		}

		void IController.Attack()
		{
			anim.CrossFade(AnimAttack);
		}

		void IController.Damage()
		{
			anim.CrossFade(AnimDamage);
		}

		void IController.Die()
		{
			anim.CrossFade(AnimDie);
		}

		void IController.Move(float speed)
		{
			anim.CrossFade(speed > 0.0f ? AnimRun : AnimIdle);
		}

		void IController.StopAttack()
		{
			anim.CrossFade(AnimIdle);
		}
	}

}
