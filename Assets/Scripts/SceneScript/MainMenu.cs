using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPlayButtonClick()
	{
		SceneManager.LoadScene ("army all animation in one");
	}
	public void OnScoreBoardButtonClick()
	{
		SceneManager.LoadScene ("HighScore");
	}
	public void OnSettingsButtonClick()
	{
		SceneManager.LoadScene ("Settings");
	}
	public void OnAboutButtonClick()
	{
		SceneManager.LoadScene ("About");
	}
	public void OnExitButtonClick()
	{
        Application.Quit();
	}
}
