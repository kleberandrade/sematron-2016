using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour 
{
	public float m_Speed;
	public Transform[] m_WayPoints;
	private int m_Index = 0;
	private Transform m_Transform;
	private float m_Error = 0.1f;

	private void Start () 
	{
		m_Transform = GetComponent<Transform> ();
	}

	private void Update () 
	{
		Vector3 direction = m_WayPoints [m_Index].position - m_Transform.position;
		Vector3 movement = direction.normalized * m_Speed * Time.deltaTime;
		m_Transform.Translate (movement, Space.Self);
		float distance = Vector3.Distance (m_WayPoints [m_Index].position, m_Transform.position);
		if (distance <= m_Error) {
			m_Index = (++m_Index) % m_WayPoints.Length;
		}
	}
}
