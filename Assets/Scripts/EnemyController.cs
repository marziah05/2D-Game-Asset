using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
	private Animator playerAnim;
	private Animator enemyAnim;

	[SerializeField]
	private GameObject player;
	[SerializeField]
	private BoxCollider2D forwardThroughReactionCol;
	[SerializeField]
	private GameObject[] weapons = new GameObject[5];
	[SerializeField]
	private GameObject[] weaponsBack = new GameObject[5];


	float sniperDistance = 20f;
	float bazookaDistance = 15f;
	float rifleDistance = 10f;
	float pistolDistance = 10f;
	float knifeDistance = 5f;
	float punchDistance = 4f;
	float kickDistance = 10f;
	float doubleKickDistance = 7f;
	float kneeDistance = 2f;
	float tryForwardThroughDistance = 3f;
	//float crouchDistance = 18f;
	//float handspringDistance = 150f;
	//float jumpDistance = 18f;


	bool weapon = true;
	private int weaponNumber = 0;
	private int currentWeaponNumber = 0; 
	private int[] weaponBullet = {3, 3, 3, 3, 3};
	private int[] weaponDamege = { 6, 6, 10, 16, 20 };

	// -1-none , 0-knife, 1-pistol, 2-rifle, 3-bazuka, 4-sniper, 5-crouch, 6-jump, 7-punch, 8-kick, 9-handspring, 10-doubleKick, 11-Knee, 12-tryForwardThrough, 13-jumpKick


	 void Awake () {
		playerAnim = player.GetComponentInChildren<Animator> ();
		enemyAnim = GetComponent<Animator> ();
	}

	void Update(){
		if (transform.rotation.y == player.transform.rotation.y)
			forwardThroughReactionCol.enabled = true;
		else
			forwardThroughReactionCol.enabled = false;
	}
		



	public void Behaviors(float playerDistance, RaycastHit2D hit)
	{	
		if (EnemyMovement.attackTimer >= EnemyMovement.timeBetweenAttack) {	
			weapon = false;
			currentWeaponNumber = weaponNumber;
			if(playerDistance>= sniperDistance && weaponBullet [4] > 0)
			{
				weaponNumber = 4;
				weapon = true;
			}
			else if(playerDistance>= bazookaDistance && weaponBullet [3] > 0)
			{
				weaponNumber = 3;
				weapon = true;
			}
			else if(playerDistance>= rifleDistance && weaponBullet [2] > 0)
			{
				weaponNumber = 2;
				weapon = true;
			}
			else if(playerDistance>= pistolDistance && weaponBullet [1] > 0)
			{
				weaponNumber = 1;
				weapon = true;
			}
			else if(playerDistance<= knifeDistance && playerDistance>=2 && weaponBullet [0] > 0)
			{
				weaponNumber = 0;
				weapon = true;
			}
			else if(playerDistance<= tryForwardThroughDistance)
			{
				weaponNumber = 12;
				weapon = true;
			}
			else if(playerDistance<= punchDistance && playerDistance>=3)
			{
				weaponNumber = 7;
				weapon = true;
			}
			else if(playerDistance<= kickDistance && playerDistance>=8)
			{
				weaponNumber = 8;
				weapon = true;
			}
			else if(playerDistance<= doubleKickDistance && playerDistance>=4)
			{
				weaponNumber = 10;
				weapon = true;
			}
			else if(playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("Sniper")||playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("Bazooka")||playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("Rifle")||playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("Pistol")||playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("Knife")||(playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("DoubleKick")&& playerDistance<= doubleKickDistance)){
				weaponNumber = 5;
				weapon = true;
			}
			else if (playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("Punch") && playerDistance <= punchDistance) {
				weaponNumber = 6;
				weapon = true;
			}
			else if (playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("Kick") && playerDistance <= kickDistance) {
				weaponNumber = 9;
				weapon = true;
			}
			else if(playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("DoubleKickReaction") && playerDistance<= kneeDistance)
			{
				weaponNumber = 11;
				weapon = true;
			}
			else if(playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("Punch") && playerDistance<= punchDistance){
				weaponNumber = 12;	
				weapon = true;
			}
			if (weapon == true) {
				EnemyMovement.attackTimer = 0.0f;
				enemyAnim.SetInteger ("WeaponNumber", weaponNumber);
				if (weaponNumber < 5 && currentWeaponNumber < 5) {
					weaponsBack [weaponNumber].SetActive (false);
					weapons [currentWeaponNumber].SetActive (false);
					weapons [weaponNumber].SetActive (true);
					if ((currentWeaponNumber != weaponNumber) && weaponNumber != 0 && weaponNumber != 3) {
						enemyAnim.SetTrigger ("Reload");
					}
					currentWeaponNumber = weaponNumber;
				} else if (weaponNumber > 6 && currentWeaponNumber < 5) {
					weapons [currentWeaponNumber].SetActive (false);
					weaponsBack [currentWeaponNumber].SetActive (true);
				}
				enemyAnim.SetTrigger ("Weapon");
				if (weaponNumber < 5) {
					if (weaponNumber > 0) {
						if (hit) {
							StartCoroutine (ShotEffect (hit));
						}
					}
					weaponBullet [weaponNumber]--;
					if (weaponBullet [weaponNumber] < 1)
						weapons [weaponNumber].SetActive (false);
				}
				EnemyMovement.waitTimer = 0.0f;
				EnemyMovement.restTimer = 0.0f;
			}
			}
		}
	private IEnumerator ShotEffect(RaycastHit2D hit){
		yield return new WaitForSeconds(0.25f);
		hit.collider.GetComponent<PlayerHealth> ().TakeDamage (weaponDamege [weaponNumber]);
		if (transform.rotation.y != player.transform.rotation.y)
			playerAnim.SetTrigger ("PunchWeaponReaction");
		else if (transform.rotation.y == player.transform.rotation.y)
			playerAnim.SetTrigger ("WeaponReactionBack");
	}
}