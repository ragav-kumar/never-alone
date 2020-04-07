using NeverAlone.Animate;
using NeverAlone.Core;
using NeverAlone.Movement;
using UnityEngine;

namespace NeverAlone.Combat
{
	[RequireComponent(typeof(Mover), typeof(ActionScheduler), typeof(IController))]
	[RequireComponent(typeof(Animal))]
	public class Fighter : MonoBehaviour, IAction
	{
		[SerializeField] float weaponRange = 2f;
		[SerializeField] float attackCooldownTime = 1f;
		[SerializeField] int weaponDamage = 10;

		// State
		private Animal target;
		private bool attackQueued = false;
		private float timeSinceLastAttack = Mathf.Infinity; // First attack is instant

		// Cached refs
		private Mover mover;
		private ActionScheduler actionScheduler;
		private IController animationController;
		private Animal state;

		private void Start()
		{
			mover = GetComponent<Mover>();
			actionScheduler = GetComponent<ActionScheduler>();
			animationController = GetComponent<IController>();
			state = GetComponent<Animal>();
		}
		private void Update()
		{
			// Always track time since last attack
			timeSinceLastAttack += Time.deltaTime;
			
			if (target == null || target.IsDead()) return;

			if (!GetIsInRange())
			{
				mover.MoveTo(target.transform.position);
			}
			else
			{
				mover.Cancel();
				AttackBehaviour();
			}

		}

		private void AttackBehaviour()
		{
			if (timeSinceLastAttack > attackCooldownTime)
			{
				if (attackQueued || true)
				{
					transform.LookAt(target.transform);
					animationController.Attack();
					timeSinceLastAttack = 0;
					attackQueued = false;
				}
			}
		}

		// Animation Event
		void Hit()
		{
			if (!target) return;

			// weapon range check; target can dodge out during attack!
			if (GetIsInRange())
			{
				target.TakeDamage(weaponDamage);
			}
		}

		private bool GetIsInRange()
		{
			return Vector3.Distance(transform.position, target.transform.position) < weaponRange;
		}

		public void Attack(GameObject combatTarget)
		{
			target = combatTarget.GetComponent<Animal>();
			if (target)
			{
				actionScheduler.StartAction(this);
				attackQueued = true;
			}
		}

		public void Cancel()
		{
			animationController.StopAttack();
			target = null;
		}


		public bool CanAttack(GameObject combatTarget)
		{
			if (!combatTarget) return false;
			var targetHealth = combatTarget.GetComponent<Animal>();
			return targetHealth && !targetHealth.IsDead();
		}

		// Called by Unity
		private void OnDrawGizmos()
		{
			if (!state || !state.IsDead())
			{
				Gizmos.color = Color.red;
				Gizmos.DrawWireSphere(transform.position, weaponRange);
			}
		}
	}
}
