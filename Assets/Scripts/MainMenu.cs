using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour 
{
	public bool m_ResetPrefs = false;

	private void Start()
	{
		if (m_ResetPrefs) {
			PlayerPrefs.DeleteAll ();
		}

		Button playButton = transform.GetChild (0).GetComponent<Button> ();
		playButton.onClick.AddListener (delegate { PlayGame (); });
		Button exitButton = transform.GetChild (1).GetComponent<Button> ();
		exitButton.onClick.AddListener (delegate { Exit (); });
	}

	public void PlayGame()
	{
		SceneManager.LoadScene ("Level_1");
	}

	public void Exit()
	{
		Application.Quit ();
	}
}
