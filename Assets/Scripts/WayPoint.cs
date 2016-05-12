using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour
{
	private void OnDrawGizmos() 
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawSphere(transform.position, 0.5f);
	}
}
