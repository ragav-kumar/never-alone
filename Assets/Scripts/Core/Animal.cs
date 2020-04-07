using UnityEngine;

namespace NeverAlone.Core
{
	[RequireComponent(typeof(Animate.IController), typeof(ActionScheduler))]
	public class Animal : MonoBehaviour
	{
		#region Serializable
#pragma warning disable 0649
		[SerializeField] Species species;
#pragma warning restore 0649
		#endregion

		#region State

		private int health;
		private bool isDead = false;

		#endregion

		private void Start() {
			if (!species) // If not overriden, then get species from same object
			{
				species = GetComponent<Species>();
			}
			health = species.GetDerivedStats().MaxHp;
		}

		public bool IsDead()
		{
			return isDead;
		}

		public void TakeDamage(int damage)
		{
			health = Mathf.Max(health-damage, 0);
			if (health <= 0)
			{
				Die();
			}
		}
		private void Die()
		{
			if (isDead) return;
			isDead = true;
			GetComponent<Animate.IController>().Die();
			GetComponent<ActionScheduler>().CancelCurrentAction();
		}
	}
}