using UnityEngine;
using System.Collections;

public class TucumaPick : MonoBehaviour {

	public AudioClip pickupClip;		// som para quando a bomba for criada
	
	/*
	private Animator anim;				// Referencia o componente animator
	
	
	void Awake()
	{
		// Setting up the reference.
		anim = transform.root.GetComponent<Animator>();
	}
	*/
	
	
	void OnTriggerEnter2D (Collider2D other)
	{
		// If the player enters the trigger zone...
		if(other.tag == "Player") {
			// ... play the pickup sound effect.
			AudioSource.PlayClipAtPoint(pickupClip, transform.position);
			
			// Increase the number of bombs the player has.
			if (G.Tucumas < G.maxTucumas) {
				G.Tucumas++;
			}
			
			// Destroy the crate.
			Destroy(transform.root.gameObject);
		}
	}
}
