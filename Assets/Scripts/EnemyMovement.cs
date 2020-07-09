using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	
	public static float speed = 0f;

	public static float waitTimer = 1f;
	public static float restTimer = 2f;
	public static float turnTimer = 0.0f;
	public static float attackTimer = 0.0f;
	public static float waitEndTime =1f;
	public static float restEndTime = 2f;
	public static float timeBetweenTurn = 4f;
	public static float timeBetweenAttack = 3f;

	bool foundPlayer = false;

	RaycastHit2D hit;
	RaycastHit2D[] hits ;

	Animator enemyAnim;
	EnemyController enemyController;

	public static int k = 180;
	public static int j = 0;

	float brickDistance= 2f;
	float playerDistance = 0f;
	float  runDistance = 150f;
	float minimumDistance = 2f;

			
	void Awake(){
		enemyController = GetComponentInChildren<EnemyController> ();
		enemyAnim = GetComponentInChildren<Animator> ();
	}

	void Update(){
		waitTimer += Time.deltaTime;
		attackTimer += Time.deltaTime;
		turnTimer += Time.deltaTime;
		restTimer += Time.deltaTime; 

		playerDistance = Mathf.Infinity;

		hit = new RaycastHit2D ();
		hits = Physics2D.RaycastAll (transform.position, transform.right);
		int n = hits.Length;

		for (int i = 0; i <n; i++) {
			if (hits [i].transform.tag == "player" && hits [i].distance < playerDistance) {
				playerDistance = hits[i].distance;  
				hit = hits [i];
				foundPlayer = true;
			}
		}
			
		if (hit) {
			enemyController.Behaviors (playerDistance, hit);
		} 

		else if(!hit && turnTimer > timeBetweenTurn && restTimer > restEndTime && waitTimer > waitEndTime){			
			playerDistance = Mathf.Infinity;

			hit = new RaycastHit2D ();
			hits = Physics2D.RaycastAll (transform.position, -transform.right);
			n = hits.Length;

			for (int i = 0; i < n; i++) {
				if (hits [i].transform.tag == "player" && hits [i].distance < playerDistance) {
					playerDistance = hits[i].distance;
					hit = hits [i];
					foundPlayer = true;
				}
			}
			if (hit) {
				turnTimer = 0.0f;
				j = j + k;
				k = k * -1;
				speed = 1f;
			}
		}

		if (waitTimer < waitEndTime) {
			speed = 0f;
		} else if (restTimer < restEndTime) {
			speed = 1f;
		} else 
			speed = 0f;








		enemyAnim.SetFloat ("Speed", speed);

		if (enemyAnim.GetCurrentAnimatorStateInfo (0).IsName ("Run"))
			speed = speed * 20f;
		else
			speed = speed * 10f;
		
		
		if (enemyAnim.GetCurrentAnimatorStateInfo (0).IsName ("Walk") || enemyAnim.GetCurrentAnimatorStateInfo (0).IsName ("Run") || enemyAnim.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) {
			if (j == 0) {
				transform.eulerAngles = new Vector2 (0, 0);
			} else if (j == 180) {
				transform.eulerAngles = new Vector2 (0, 180);
			}
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		}



		if(enemyAnim.GetCurrentAnimatorStateInfo (0).IsName ("Handspring"))
		{
			transform.Translate(Vector2.right * -10f * Time.deltaTime);
		}
		if(enemyAnim.GetCurrentAnimatorStateInfo (0).IsName ("PunchReactionBack"))
		{
			transform.Translate(Vector2.right * 1f * Time.deltaTime);
		}
		if(enemyAnim.GetCurrentAnimatorStateInfo (0).IsName ("PunchWeaponReaction"))
		{
			transform.Translate(Vector2.right * -2f * Time.deltaTime);
		}
		if(enemyAnim.GetCurrentAnimatorStateInfo (0).IsName ("WeaponReactionBack"))
		{
			transform.Translate(Vector2.right * 1f * Time.deltaTime);
		}
		if(enemyAnim.GetCurrentAnimatorStateInfo (0).IsName ("Kick"))
		{
			transform.Translate(Vector2.right * 1f * Time.deltaTime);
		}
		if(enemyAnim.GetCurrentAnimatorStateInfo (0).IsName ("KickReaction"))
		{
			transform.Translate(Vector2.right * -4f * Time.deltaTime);
		}
		if(enemyAnim.GetCurrentAnimatorStateInfo (0).IsName ("KickReactionBack"))
		{
			transform.Translate(Vector2.right * 4f * Time.deltaTime);
		}
		if(enemyAnim.GetCurrentAnimatorStateInfo (0).IsName ("DoubleKickReaction"))
		{
			transform.Translate(Vector2.right * -3f * Time.deltaTime);
		}
		if (enemyAnim.GetCurrentAnimatorStateInfo (0).IsName ("DoubleKickReactionBack")) {
			transform.Translate(Vector2.right * 1f * Time.deltaTime);
		}
		if (enemyAnim.GetCurrentAnimatorStateInfo (0).IsName ("KneeReaction")) {
			transform.Translate(Vector2.right * 1f * Time.deltaTime);
		}
		if (enemyAnim.GetCurrentAnimatorStateInfo (0).IsName ("ForwardThroughReaction")) {
			transform.Translate(Vector2.right * 5f * Time.deltaTime);
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if (enemyAnim.GetCurrentAnimatorStateInfo (0).IsName ("Walk") || enemyAnim.GetCurrentAnimatorStateInfo (0).IsName ("Run")) {
			switch (col.tag) {
			case "leftWall":
				Debug.Log ("L");
				speed = 0f;
				enemyAnim.SetFloat ("Speed", speed);
				transform.eulerAngles = new Vector2 (0, 0);
				break;
			case "rightWall":
				Debug.Log ("R");
				speed = 0f;
				enemyAnim.SetFloat ("Speed", speed);
				transform.eulerAngles = new Vector2 (0, 180);
				break;
			}
		}
	}
}
