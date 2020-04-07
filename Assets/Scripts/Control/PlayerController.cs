using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NeverAlone.Movement;
using NeverAlone.Combat;
using System;
using NeverAlone.Core;

namespace NeverAlone.Control
{
	[RequireComponent(typeof(Mover), typeof(Fighter), typeof(Animal))]
	public class PlayerController : MonoBehaviour
	{
		// Cached Refs
		private Mover mover;
		private Fighter fighter;
		private Animal health;
		// Start is called before the first frame update
		void Start()
		{
			mover   = GetComponent<Mover>();
			fighter = GetComponent<Fighter>();
			health  = GetComponent<Animal>();
		}

		// Update is called once per frame
		void Update()
		{
			if (health.IsDead()) return;

			if (InteractWithCombat()) return;
			if (InteractWithMovement()) return;
			// No action possible
		}

		private bool InteractWithCombat()
		{
			RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
			foreach (var hit in hits)
			{
				var target = hit.transform.GetComponent<CombatTarget>();
				if (!target) continue;
				
				if (!fighter.CanAttack(target.gameObject)) continue;
				
				if (Input.GetMouseButton(0))
				{
					fighter.Attack(target.gameObject);
				}
				return true;
			}
			return false;
		}

		private bool InteractWithMovement()
		{
			RaycastHit hit;
			bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
			if (hasHit)
			{
				if (Input.GetMouseButton(0))
				{
					mover.StartMoveAction(hit.point);
				}
				return true;
			}
			return false;
		}

		private static Ray GetMouseRay()
		{
			return Camera.main.ScreenPointToRay(Input.mousePosition);
		}
	}
}