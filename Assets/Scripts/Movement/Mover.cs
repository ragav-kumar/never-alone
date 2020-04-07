using NeverAlone.Core;
using UnityEngine;
using UnityEngine.AI;

namespace NeverAlone.Movement
{
	[RequireComponent(typeof(NavMeshAgent),typeof(Animate.IController), typeof(ActionScheduler))]
	[RequireComponent(typeof(Animal))]
	public class Mover : MonoBehaviour, IAction
	{

		[SerializeField] Transform target;

		private NavMeshAgent navMeshAgent;
		private Animate.IController animator;
		private ActionScheduler actionScheduler;
		private Animal state;
		
		void Start()
		{
			navMeshAgent = GetComponent<NavMeshAgent>();
			animator = GetComponent<Animate.IController>();
			actionScheduler = GetComponent<ActionScheduler>();
			state = GetComponent<Animal>();
		}
		void Update()
		{
			navMeshAgent.enabled = !state.IsDead();
			UpdateAnimator();
		}
		public void StartMoveAction(Vector3 destination)
		{
			actionScheduler.StartAction(this);
			MoveTo(destination);
		}
		public void MoveTo(Vector3 destination)
		{
			navMeshAgent.destination = destination;
			navMeshAgent.isStopped = false;
		}
		public void Cancel()
		{
			navMeshAgent.isStopped = true;
		}

		private void UpdateAnimator()
		{
			// convert global velocity to local
			var localVelocity = transform.InverseTransformDirection(navMeshAgent.velocity);
			animator.Move(localVelocity.z);
		}
	}
}
