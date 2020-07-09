using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static int score;
	public static string gameOverText;

	Text scoretext;
	Text gameOvertext;
	[SerializeField]
	private GameObject GameOvertext;

	void Awake(){
		gameOvertext = GameOvertext.GetComponent<Text> ();
		scoretext = GetComponent<Text> ();
		scoretext.text = "Score: " + score;
		score = 0;
	}

	void Update () {
		gameOvertext.text = gameOverText;
		scoretext.text = "Score: " + score;
	}
}
