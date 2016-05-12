using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour 
{
	public float m_Speed;
	private Transform m_Transform;
	private Rigidbody m_Rigidbody;
	private Vector3 m_StartPosition;

	private void Start () {
		m_Transform = GetComponent<Transform> ();
		m_Rigidbody = GetComponent<Rigidbody> ();
		m_StartPosition = m_Transform.position;
	}

	private void OnTriggerEnter(Collider other){
		if (other.CompareTag("Enemy")){
			m_Transform.position = m_StartPosition;
		}

		if (other.CompareTag ("Portal")) {
			SceneManager.LoadScene ("Menu");
		}
	}

	private void Update ()
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		MoveWithPhysics (h, v);
	}

	private void MoveWithPhysics(float x, float z)
	{
		Vector3 movement = new Vector3 (x, 0.0f, z) * m_Speed * Time.deltaTime;
		m_Rigidbody.MovePosition (m_Transform.position + movement);
	}

	private void MoveWithTranslate(float x, float z)
	{
		Vector3 movement = new Vector3 (x, 0.0f, z);
		movement *= m_Speed * Time.deltaTime;
		m_Transform.Translate (movement, Space.Self);
	}
}
