using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	Animator playerAnim;

	void Awake(){
		playerAnim = GetComponentInChildren<Animator> ();
	}


	void Update () {
		speed = Input.GetAxis ("Horizontal");
		playerAnim.SetFloat ("Speed", speed);
	
		if(speed > 0.999 || speed < - 0.999)
			speed = speed * 20f;
		else 
			speed = speed * 15f;
		
		if(playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("Walk") || playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("Run") || playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("Idle")){
			if (speed > 0) {
				transform.eulerAngles = new Vector2 (0, 0);
				transform.Translate (Vector2.right * speed  * Time.deltaTime);
			} else if (speed < 0) {
				transform.eulerAngles = new Vector2 (0, 180);
				transform.Translate (Vector2.right * -speed  * Time.deltaTime);
			}
		}






		if(playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("Handspring"))
		{
			transform.Translate(Vector2.right * -10f * Time.deltaTime);
		}
		if(playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("PunchReactionBack"))
		{
			transform.Translate(Vector2.right * 1f * Time.deltaTime);
		}
		if(playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("PunchWeaponReaction"))
		{
			transform.Translate(Vector2.right * -2f * Time.deltaTime);
		}
		if(playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("WeaponReactionBack"))
		{
			transform.Translate(Vector2.right * 1f * Time.deltaTime);
		}
		if(playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("Kick"))
		{
			transform.Translate(Vector2.right * 1f * Time.deltaTime);
		}
		if(playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("KickReaction"))
		{
			transform.Translate(Vector2.right * -4f * Time.deltaTime);
		}
		if(playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("KickReactionBack"))
		{
			transform.Translate(Vector2.right * 4f * Time.deltaTime);
		}
		if(playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("DoubleKickReaction"))
		{
			transform.Translate(Vector2.right * -3f * Time.deltaTime);
		}
		if (playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("DoubleKickReactionBack")) {
			transform.Translate(Vector2.right * 1f * Time.deltaTime);
		}
		if (playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("KneeReaction")) {
			transform.Translate(Vector2.right * 1f * Time.deltaTime);
		}
		if (playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("ForwardThroughReaction")) {
			transform.Translate(Vector2.right * 5f * Time.deltaTime);
		}
	}
}
