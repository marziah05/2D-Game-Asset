using UnityEngine;
using System.Collections;

public class EventScript : MonoBehaviour {

	public AudioSource effectSource;                   
	public AudioSource collideSource;     			
	public AudioSource damageSource;      	      


	public void PlayEffect(AudioClip clip)
	{
		effectSource.clip = clip;
		effectSource.Play ();
	}
	public void PlayCollide(AudioClip clip)
	{
		collideSource.clip = clip;
		collideSource.Play ();
	}

	public void PlayDamage(AudioClip clip)
	{
		damageSource.clip = clip;
		damageSource.Play ();
	}

}
