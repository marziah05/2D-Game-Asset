using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;


	public int scoreValue = 100;

	[SerializeField]
	private GameObject screanFader;

	private Animator enemyAnim;
	private Animator UIAnim;


	private EnemyMovement enemyMovement; 
	private EnemyController enemyController;
	private EventScript eventScript;


	[SerializeField]
	private GameObject player;


	[SerializeField]
	private GameObject UI;
	private BoxCollider2D bodyCol;


	[SerializeField]
	private AudioClip PunchCollideClip;
	[SerializeField]
	private AudioClip KickCollideClip;
	[SerializeField]
	private AudioClip DoubleKickCollideClip;
	[SerializeField]
	private AudioClip KneeCollideClip;


	int knifeDamage = 6;
	int punchDamage = 4;
	int kickDamage = 6;
	int doubleKickDamage = 12;
	int KneeDamage = 10;


	void Awake () {
		enemyAnim= GetComponentInChildren<Animator> ();
		UIAnim = UI.GetComponent<Animator> ();
		enemyMovement = GetComponent<EnemyMovement> ();
		enemyController = GetComponentInChildren<EnemyController> ();
		eventScript = GetComponentInChildren<EventScript> ();
		bodyCol = GetComponent<BoxCollider2D> ();
		currentHealth = startingHealth;
	}

	void Update(){
		
	}


	void OnTriggerEnter2D(Collider2D col){
		switch (col.tag) {
		case "playerKnife":
			if (transform.rotation.y != player.transform.rotation.y)
				enemyAnim.SetTrigger ("PunchWeaponReaction");
			else if (transform.rotation.y == player.transform.rotation.y)
				enemyAnim.SetTrigger ("WeaponReactionBack");
			TakeDamage (knifeDamage);
			break;
		case "playerPunch":
			if (transform.rotation.y != player.transform.rotation.y)
				enemyAnim.SetTrigger ("PunchWeaponReaction");
			else if (transform.rotation.y == player.transform.rotation.y)
				enemyAnim.SetTrigger ("PunchReactionBack");
			TakeDamage (punchDamage);
			eventScript.PlayCollide (PunchCollideClip);
			break;
		case "playerKnee":
			Debug.Log ("hoy na keno");
			enemyAnim.SetTrigger ("kneeReaction");
			TakeDamage (KneeDamage);
			eventScript.PlayCollide (KneeCollideClip);
			break;
		case "playerKick":
			if (transform.rotation.y != player.transform.rotation.y)
				enemyAnim.SetTrigger ("KickReaction");
			else if (transform.rotation.y == player.transform.rotation.y)
				enemyAnim.SetTrigger ("KickReactionBack");			
			TakeDamage (kickDamage);
			eventScript.PlayCollide (KickCollideClip);
			break;
		case "playerDoubleKick":
			if (transform.rotation.y != player.transform.rotation.y)
				enemyAnim.SetTrigger ("DoubleKickReaction");
			else if (transform.rotation.y == player.transform.rotation.y)
				enemyAnim.SetTrigger ("DoubleKickReactionBack");
			TakeDamage (doubleKickDamage);
			eventScript.PlayCollide (DoubleKickCollideClip);
			break;

		} 
	}


		
	public void TakeDamage(int amount){
		currentHealth -= amount;
		healthSlider.value = currentHealth;
		if (currentHealth <= 0)
			Death ();
	}

	public void Death(){
		bodyCol.enabled = false;
		enemyAnim.SetTrigger ("Died");
		enemyMovement.enabled = false;
		enemyController.enabled = false;
		ScoreManager.score += scoreValue;
		ScoreManager.gameOverText = "YOU WIN !";
		UIAnim.SetTrigger("GameOver");
	}
}

