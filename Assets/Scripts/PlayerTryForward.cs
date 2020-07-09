 using UnityEngine;
using System.Collections;

public class PlayerTryForward : MonoBehaviour {
	private Animator playerAnim;
	private Animator enemyAnim;

	int forwardThroughDamge = 12;


	[SerializeField]
	private GameObject enemy;


	void Awake () {
		enemyAnim= enemy.GetComponentInChildren<Animator> ();
		playerAnim = GetComponentInParent<Animator> ();
	}


	void OnTriggerEnter2D(Collider2D col){
		switch(col.tag){
		case "enemyForwardThroughReaction":
			playerAnim.SetTrigger ("ForwardThrough");
			enemyAnim.SetTrigger ("ForwardThroughReaction");
			enemy.transform.Translate(Vector2.right * 100f * Time.deltaTime);
			Debug.Log ("ken hoitesena");
			break;
		case "floor":
			GetComponentInParent<PlayerHealth> ().TakeDamage(forwardThroughDamge);
			break;
		}
	}
}
