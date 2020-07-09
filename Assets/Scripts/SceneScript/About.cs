using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class About : MonoBehaviour {

	[SerializeField] private Transform ScrollBar;
	[SerializeField] private Transform Handle;
	[SerializeField] private Transform TextLoading;
	[SerializeField] private float currentAmount;
	[SerializeField] private float speed = 1;

	void Start () {
	}

	void Update () {
		if((Input.GetKeyDown(KeyCode.Mouse2)))
			{
				currentAmount += speed * Time.deltaTime;
				ScrollBar.GetComponent<Scrollbar> ().value = currentAmount;
			}			
	}
		
	public void OnBackButtonClick()
	{
		SceneManager.LoadScene ("MainMenu");
	}
}
