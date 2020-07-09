using UnityEngine;
using System.Collections;

public class EnemyTryForward : MonoBehaviour {

	private Animator playerAnim;
	private Animator enemyAnim;

	int forwardThroughDamge = 12;

	[SerializeField]
	private GameObject player;


	void Awake () {
		enemyAnim= GetComponentInParent<Animator> ();
		playerAnim = player.GetComponentInChildren<Animator> ();
	}


	void OnTriggerEnter2D(Collider2D col){
		switch(col.tag){
		case "playerForwardThroughReaction":
			playerAnim.SetTrigger ("ForwardThroughReaction");
			enemyAnim.SetTrigger ("ForwardThrough");
			break;
		case "floor":
			GetComponentInParent<EnemyHealth> ().TakeDamage(forwardThroughDamge);
			break;
		}
	}
}
