using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour {
	string name;
	string serial;
	string score;
	[SerializeField]
	GameObject [] names =new GameObject[5];
	int [] scores = new int[5];

	// Use this for initialization
	void Awake () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnSaveButtonClick()
	{
		
	}
	public void OnInputFieldTextChange(string newText)
	{
		name = newText;
	}
	public void OnBackButtonClick()
	{
		SceneManager.LoadScene ("MainMenu");
	}
}
