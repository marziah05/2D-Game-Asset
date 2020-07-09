using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayGroundScript : MonoBehaviour {


	[SerializeField]
	private GameObject bakg;
	public static Sprite bg;
	// = Resources.Load<Sprite> ("jungle") as Sprite

	void Awake () {
		
		//bg = this.gameObject.GetComponent<Image> ().sprite = Settings.background;
	}
	

	void Update () {
		//bg = this.gameObject.GetComponent<Image> ().sprite = Settings.background;
	}
}
