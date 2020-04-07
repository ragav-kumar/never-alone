using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NeverAlone.Animate
{
	interface IController
	{
		void Move(float speed);
		void Attack();
		void StopAttack();
		void Damage();
		void Die();
	}
}