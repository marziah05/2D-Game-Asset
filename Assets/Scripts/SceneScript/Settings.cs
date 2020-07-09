using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;



public class Settings : MonoBehaviour {


	public static Sprite background;

	[SerializeField] private Toggle check1;
	[SerializeField] private Toggle check2;
	[SerializeField] private Toggle check3;
	[SerializeField] private Toggle check4;

	void Start () {
		background = Resources.Load<Sprite> ("moru") as Sprite;
	}

	void Update () {
	}

	public void OnBackButtonClick()
	{
		SceneManager.LoadScene ("MainMenu");
	}
	public void OnToggle1Click()
	{
		if (check1.isOn) {
			Debug.Log ("1");
			background = Resources.Load<Sprite> ("jungle") as Sprite;
		}
	}
	public void OnToggle2Click()
	{
		if (check2.isOn) {
			Debug.Log ("2");
			background = Resources.Load<Sprite> ("moru") as Sprite;
		}
	}
	public void OnToggle3Click()
	{
		if (check3.isOn) {
			Debug.Log ("3");
			background = Resources.Load<Sprite> ("sky") as Sprite;
		}
	}
	public void OnToggle4Click()
	{
		if (check4.isOn) {
			Debug.Log ("4");
			background = Resources.Load<Sprite> ("green") as Sprite;
		}
	}

}
