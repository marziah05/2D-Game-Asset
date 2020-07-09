using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour{
	
	float timer = 0.0f;
	float timeBetweenAttack = 1f;
	KeyCode key ;

	private Animator playerAnim;
	private Animator enemyAnim;
	 
	[SerializeField]
	private GameObject enemy;
	[SerializeField]
	private BoxCollider2D forwardThroughReactionCol;
	[SerializeField]
	private GameObject[] weapons = new GameObject[5];
	[SerializeField]
	private GameObject[] weaponsBack = new GameObject[5];

	bool weapon = false;
	int[] maxRange = {500, 500, 500, 500, 500};
	int[] minRange = {0, 5, 10, 10, 20};
	private int weaponNumber = 0;
	private int currentWeaponNumber = 0; 
	private int[] weaponBullet = {10, 10, 10, 10, 10};
	private int[] weaponDamege = { 6, 6, 10, 16, 20 };
	int i = 0;

	void Awake () 
	{
		enemyAnim = enemy.GetComponentInChildren<Animator> ();
		playerAnim = GetComponent<Animator> ();

	} 

	void Update ()
	{
		timer += Time.deltaTime;
		weapon = false;
		if (playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("Idle")|| playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("Walk")|| playerAnim.GetCurrentAnimatorStateInfo (0).IsName ("Run")) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				playerAnim.SetTrigger ("Jump");
			}
			else if (Input.GetKeyDown (KeyCode.Q)) {
				playerAnim.SetTrigger ("Crouch");
			}
			else if (Input.GetKeyDown (KeyCode.E)) {
				playerAnim.SetTrigger ("Handspring");
				weapons [weaponNumber].SetActive (false);
				weaponsBack [weaponNumber].SetActive (true);
			}
			else if (Input.GetKeyDown (KeyCode.P)) {
				playerAnim.SetTrigger ("Punch");
				weapons [weaponNumber].SetActive (false);
				weaponsBack [weaponNumber].SetActive (true);
			}
			else if (Input.GetKeyDown (KeyCode.K)) {
				playerAnim.SetTrigger ("Kick");
				weapons [weaponNumber].SetActive (false);
				weaponsBack [weaponNumber].SetActive (true);
			}
			else if (Input.GetKeyDown (KeyCode.J)) {
				playerAnim.SetTrigger ("DoubleKick");
				weapons [weaponNumber].SetActive (false);
				weaponsBack [weaponNumber].SetActive (true);
			}
			else if (Input.GetKeyDown (KeyCode.O)) {
				playerAnim.SetTrigger ("Knee");
				weapons [weaponNumber].SetActive (false);
				weaponsBack [weaponNumber].SetActive (true);
			}
			else if (Input.GetKeyDown (KeyCode.U)) {
				playerAnim.SetTrigger ("TryForward");
				weapons [weaponNumber].SetActive (false);
				weaponsBack [weaponNumber].SetActive (true);
			}
			else if (Input.GetKeyDown (KeyCode.Mouse1)) {       // for changing weapon ignoring weapons that don't have bullet
				weaponsBack [weaponNumber].SetActive (false);
				for (i = 0; i < 5; i++) {
					weaponNumber++;
					if (weaponNumber == 5)
						weaponNumber = 0;
					if (weaponBullet [weaponNumber] > 0) {
						weapons [currentWeaponNumber].SetActive (false);
						playerAnim.SetInteger ("WeaponNumber", weaponNumber);
						weapons [weaponNumber].SetActive (true);
						currentWeaponNumber = weaponNumber;
						if(weaponNumber!= 0 && weaponNumber!= 3) 
						playerAnim.SetTrigger ("Reload");
						break;
					}
				}
				if (i == 5)
					Debug.Log ("No Weapon !!!!!!!!!!");
			}
			else if (Input.GetKeyDown (KeyCode.Mouse0) && timer >= timeBetweenAttack) {  
				timer = 0f;
				weaponsBack [weaponNumber].SetActive (false);
				if (weaponBullet [weaponNumber] < 1) {
					for (i = 0; i < 5; i++) {
						weaponNumber++;
						if (weaponNumber == 5)
							weaponNumber = 0;
						if (weaponBullet [weaponNumber] > 0) {
							playerAnim.SetInteger ("WeaponNumber", weaponNumber);
							currentWeaponNumber = weaponNumber;
							if(weaponNumber!= 0 && weaponNumber!= 3) 
							playerAnim.SetTrigger ("Reload");
							weapon = true;
							break;
						}
					}
					if (i == 5)
						Debug.Log ("No Weapon !!!!!!!!!!");
				} else
					weapon = true;
				if (weapon == true) {
					playerAnim.SetInteger ("WeaponNumber", weaponNumber);
					weapons [weaponNumber].SetActive (true);
					playerAnim.SetTrigger ("Weapon");
					if (weaponNumber > 0) {
						StartCoroutine (ShotEffect ());
					}
					weaponBullet [weaponNumber]--;
					if (weaponBullet [weaponNumber] < 1)
						weapons [weaponNumber].SetActive (false);
				}
			}
		}
		if (transform.rotation.y == enemy.transform.rotation.y)
			forwardThroughReactionCol.enabled = true;
		else
			forwardThroughReactionCol.enabled = false;
	}

	private IEnumerator ShotEffect(){
		RaycastHit2D[] hits;
		RaycastHit2D hit = new RaycastHit2D ();
		hits = Physics2D.RaycastAll (transform.position, transform.right);
		float shortestDistance = maxRange [weaponNumber];
		for (int j = 0; j < hits.Length; j++) {
			if (hits [j].transform.tag == "enemy" && hits [j].distance > minRange [weaponNumber] && hits [j].distance <= shortestDistance) {
				hit = hits [j];
				shortestDistance = hits [j].distance;
			}
		}
		if (hit) {
			yield return new WaitForSeconds (0.25f);
			hit.collider.GetComponent<EnemyHealth> ().TakeDamage (weaponDamege [weaponNumber]);
			if (transform.rotation.y != enemy.transform.rotation.y)
				enemyAnim.SetTrigger ("PunchWeaponReaction");
			else if (transform.rotation.y == enemy.transform.rotation.y)
				enemyAnim.SetTrigger ("WeaponReactionBack");
		}	
	}
}