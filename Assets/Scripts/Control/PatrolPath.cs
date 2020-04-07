using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NeverAlone.Control
{
	public class PatrolPath : MonoBehaviour
	{
		const float waypointRadius = .1f;

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.gray;
			DrawPath();
		}
		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.white;
			DrawPath();
		}

		private void DrawPath()
		{
			for (int i = 0; i < transform.childCount; i++)
			{
				Gizmos.DrawSphere(GetWaypoint(i), waypointRadius);
				Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(GetNextIndex(i)));
			}
		}
		public int GetNextIndex(int i)
		{
			return (i + 1) % transform.childCount;
		}
		public Vector3 GetWaypoint(int i)
		{
			return transform.GetChild(i).position;
		}
		public int WaypointCount()
		{
			return transform.childCount;
		}
	}

}
