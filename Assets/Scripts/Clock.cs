using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Clock : MonoBehaviour 
{
	private Text m_ClockText;
	private Text m_BestClockTime;
	private float m_StartTime;
	private float m_ElapsedTime;

	private void Start () {
		m_ClockText = transform.GetChild (0).GetComponent<Text> ();
		m_BestClockTime = transform.GetChild (1).GetComponent<Text> ();

		m_StartTime = Time.time;
		m_ElapsedTime = 0.0f;
		if (PlayerPrefs.HasKey ("BestTime"))
			m_BestClockTime.text = PlayerPrefs.GetFloat ("BestTime").ToString ("0000.0");
		else
			m_BestClockTime.text = "Undefined";
	}

	private void Update () {
		m_ElapsedTime = Time.time - m_StartTime;
		m_ClockText.text = m_ElapsedTime.ToString ("0000.0");
	}

	private void SaveBestTime(){
		if (PlayerPrefs.HasKey ("BestTime")) {
			float time = PlayerPrefs.GetFloat ("BestTime");
			if (m_ElapsedTime < time) {
				PlayerPrefs.SetFloat ("BestTime", m_ElapsedTime);
			}
		} else {
			PlayerPrefs.SetFloat ("BestTime", m_ElapsedTime);
		}

		PlayerPrefs.Save ();
	}

	private void OnDestroy(){
		SaveBestTime ();
	}
}
