using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NeverAlone.Animate
{
	public class BlendTreeController : MonoBehaviour,IController
	{
		private const string TriggerDie = "die";
		private const string TriggerSpeed = "forwardSpeed";
		private const string TriggerAttack = "attack";
		private const string TriggerStopAttack = "stopAttack";

		private Animator animator;

		void Start()
		{
			animator = GetComponent<Animator>();
		}

		void IController.Attack()
		{
			animator.ResetTrigger(TriggerStopAttack);
			animator.SetTrigger(TriggerAttack); // Trigger Hit() event
		}

		void IController.StopAttack()
		{
			animator.ResetTrigger(TriggerAttack);
			animator.SetTrigger(TriggerStopAttack);
		}

		void IController.Damage()
		{
			throw new System.NotImplementedException();
		}

		void IController.Die()
		{
			throw new System.NotImplementedException();
		}

		void IController.Move(float speed)
		{
			animator.SetFloat(TriggerSpeed, speed);
		}
	}
}
