using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {
	[SerializeField] private Transform LoadingBar;
	[SerializeField] private Transform TextIndecator;
	[SerializeField] private Transform TextLoading;
	[SerializeField] private float currentAmount;
	[SerializeField] private float speed = 20;



	void Update () {
		if(currentAmount<100)
		{
			currentAmount += speed * Time.deltaTime;
			TextIndecator.GetComponent<Text>().text=((int)currentAmount).ToString()+"%";
			TextLoading.gameObject.SetActive(true);
		}
		else
		{
			TextIndecator.gameObject.SetActive(false);
			TextLoading.GetComponent<Text>().text="START!";
			SceneManager.LoadScene ("MainMenu");

		}
		LoadingBar.GetComponent<Image> ().fillAmount = currentAmount/100;
	}
}
