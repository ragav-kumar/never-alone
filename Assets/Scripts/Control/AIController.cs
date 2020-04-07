using UnityEngine;

using NeverAlone.Combat;
using NeverAlone.Core;
using NeverAlone.Movement;
using System;

namespace NeverAlone.Control
{
	[RequireComponent(typeof(Fighter), typeof(Mover), typeof(ActionScheduler))]
	[RequireComponent(typeof(Animal))]
	public class AIController : MonoBehaviour
	{
		[Header("Chase Behaviour")]
		[SerializeField] float chaseDistance = 5f;
		[SerializeField] float suspicionTime = 3f;
		[Header("Patrol Behaviour")]
#pragma warning disable 0649
		[SerializeField] PatrolPath patrolPath;
#pragma warning restore 0649
		[SerializeField] float waypointTolerance = 1f;
		[SerializeField] float dwellTime = 2f;

		// State
		private Vector3 guardPosition;
		private int waypointIndex = 0;
		private float timeSinceLastSawPlayer = Mathf.Infinity;
		private float timeAtWaypoint = Mathf.Infinity;

		// Cached refs
		private Fighter fighter;
		private Mover mover;
		private ActionScheduler actionScheduler;
		private GameObject player;
		private Animal health;

		private void Start()
		{
			fighter         = GetComponent<Fighter>();
			mover           = GetComponent<Mover>();
			actionScheduler = GetComponent<ActionScheduler>();
			health          = GetComponent<Animal>();
			player          = GameObject.FindWithTag("Player");
			
			guardPosition = transform.position;
		}

		private void Update()
		{
			if (health.IsDead()) return;
			if (IsPlayerInRange() && fighter.CanAttack(player))
			{
				AttackBehaviour();
			}
			else if (timeSinceLastSawPlayer < suspicionTime)
			{
				SuspicionBehaviour();
			}
			else
			{
				PatrolBehaviour();
			}
			UpdateTimers();
		}

		private void UpdateTimers()
		{
			timeSinceLastSawPlayer += Time.deltaTime;
			timeAtWaypoint += Time.deltaTime;
		}

		private void PatrolBehaviour()
		{
			var nextPos = guardPosition;
			if (patrolPath)
			{
				if (AtWaypoint())
				{
					timeAtWaypoint = 0;
					CycleWaypoint();
				}
				nextPos = GetCurrentWaypoint();
			}
			if (timeAtWaypoint > dwellTime)
			{
				mover.StartMoveAction(nextPos);
			}
		}

		private Vector3 GetCurrentWaypoint()
		{
			return patrolPath.GetWaypoint(waypointIndex);
		}

		private void CycleWaypoint()
		{
			waypointIndex = patrolPath.GetNextIndex(waypointIndex);
		}

		private bool AtWaypoint()
		{
			var distance = Vector3.Distance(GetCurrentWaypoint(), transform.position);
			return distance <= waypointTolerance;
		}

		private void SuspicionBehaviour()
		{
			actionScheduler.CancelCurrentAction();
		}

		private void AttackBehaviour()
		{
			timeSinceLastSawPlayer = 0;
			fighter.Attack(player);
		}

		private bool IsPlayerInRange()
		{
			float distance = Vector3.Distance(transform.position, player.transform.position);
			return distance <= chaseDistance;
		}
		// Called by Unity
		private void OnDrawGizmos()
		{
			if (!health || !health.IsDead())
			{
				Gizmos.color = Color.blue;
				Gizmos.DrawWireSphere(transform.position, chaseDistance);
			}
		}
	}
}