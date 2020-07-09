using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int startingHealth = 100; 
	public int currentHealth;
	public Slider healthSlider;

	private Animator playerAnim;
	private Animator UIAnim;

	private PlayerMovement playerMovement; 
	private PlayerController playerController;
	private EventScript eventScript;

	[SerializeField]
	private GameObject enemy;
	[SerializeField]
	private GameObject UI;
	[SerializeField]
	private GameObject screanFader;
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
		playerAnim = GetComponentInChildren<Animator> ();
		UIAnim = UI.GetComponent<Animator> ();
		playerMovement = GetComponent<PlayerMovement> ();
		playerController = GetComponentInChildren<PlayerController> ();
		eventScript = GetComponentInChildren<EventScript> ();
		bodyCol = GetComponent<BoxCollider2D> ();
		currentHealth = startingHealth;	
	}

	void Update(){
		
	}


	void OnTriggerEnter2D(Collider2D col){
		switch(col.tag){
		case "enemyKnife":
			if (transform.rotation.y != enemy.transform.rotation.y)
				playerAnim.SetTrigger ("PunchWeaponReaction");
			else if (transform.rotation.y == enemy.transform.rotation.y)
				playerAnim.SetTrigger ("WeaponReactionBack");
			TakeDamage (knifeDamage);
			break;
		case "enemyPunch":
			if (transform.rotation.y != enemy.transform.rotation.y)
				playerAnim.SetTrigger ("PunchWeaponReaction");
			else if (transform.rotation.y == enemy.transform.rotation.y)
				playerAnim.SetTrigger ("PunchReactionBack");
			TakeDamage (punchDamage);
			eventScript.PlayCollide (PunchCollideClip);
			break;
		case "enemyKnee":
			if (transform.rotation.y != enemy.transform.rotation.y)
				playerAnim.SetTrigger ("kneeReaction");
			else if (transform.rotation.y == enemy.transform.rotation.y)
				playerAnim.SetTrigger ("kneeReactionBack");
			TakeDamage (KneeDamage);
			eventScript.PlayCollide (KneeCollideClip);
			break;
		case "enemyKick":
			if (transform.rotation.y != enemy.transform.rotation.y)
				playerAnim.SetTrigger ("KickReaction");
			else if (transform.rotation.y == enemy.transform.rotation.y)
				playerAnim.SetTrigger ("KickReactionBack");			
			TakeDamage (kickDamage);
			eventScript.PlayCollide (KickCollideClip);
			break;
		case "enemyDoubleKick":
			if (transform.rotation.y != enemy.transform.rotation.y)
				playerAnim.SetTrigger ("DoubleKickReaction");
			else if (transform.rotation.y == enemy.transform.rotation.y)
				playerAnim.SetTrigger ("DoubleKickReactionBack");
			TakeDamage (doubleKickDamage);
			eventScript.PlayCollide (KickCollideClip);
			break;
		} 
	}



	public void TakeDamage(int amount ){
		currentHealth -= amount;
		healthSlider.value = currentHealth;
		if (currentHealth <= 0) {
			Death ();
		}
	}

	void Death(){
		bodyCol.enabled = false;
		playerAnim.SetTrigger ("Died");
		Debug.Log ("Death");
		playerMovement.enabled = false;
		playerController.enabled = false;
		//playerAnim.enabled = false;
		ScoreManager.gameOverText = "GAME OVER !";
		UIAnim.SetTrigger("GameOver");
	}
}
