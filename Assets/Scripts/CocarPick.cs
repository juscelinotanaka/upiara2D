using UnityEngine;
using System.Collections;

public class CocarPick : MonoBehaviour {

	public AudioClip pickupClip;		// som para quando a bomba for criada
	
	/*
	private Animator anim;				// Referencia o componente animator
	
	
	void Awake()
	{
		// Setting up the reference.
		anim = transform.root.GetComponent<Animator>();
	}
	*/

	public GUISkin skin;

	private bool pegou = false;
	private bool resolvendo = false;
	private float boxWidth = 400.0f;
	private float boxHeight = 300.0f;

	private float cntWidth = 100f;
	private float cntHeight = 40f;

	private float offset = 10f;

	private PlayerControl control;
	private TouchController touch;



	void Start () {
		G.rate = Screen.height/480.0f;
		boxWidth = boxWidth * G.rate;
		boxHeight = boxHeight * G.rate;
		cntWidth = cntWidth * G.rate;
		cntHeight = cntHeight * G.rate;
		offset = offset * G.rate;
		skin.button.fontSize = Mathf.RoundToInt(18*G.rate);
		skin.box.fontSize = Mathf.RoundToInt(30*G.rate);
	}

	void OnGUI() {
		if (skin) {


			GUI.skin = skin;
			if (pegou) {
				GUI.Box(new Rect( (Screen.width - boxWidth)/2, (Screen.height - boxHeight)/2, boxWidth, boxHeight ), "");
				if (resolvendo) {
					if (GUI.Button(new Rect((Screen.width - cntWidth)/2, (Screen.height + boxHeight)/2 - offset - cntHeight, cntWidth, cntHeight), "Continuar")) {
						Debug.Log("Ganhou");
						pegou = false;
					}
				} else {
					GUI.Label(new Rect((Screen.width - boxWidth)/2, (Screen.height - boxHeight)/2, boxWidth, boxHeight - offset - cntHeight), "Para ganhar o cocar você deve resolver o problema a seguir que desativará o trator que está destruíndo a floresta.");
					if (GUI.Button(new Rect((Screen.width - cntWidth)/2, (Screen.height + boxHeight)/2 - offset - cntHeight, cntWidth, cntHeight), "Continuar")) {
						Debug.Log("Continue");
						resolvendo = true;
					}
				}
			} 
		}

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		// If the player enters the trigger zone...
		if(!pegou && other.tag == "Player") {
			// ... play the pickup sound effect.
			AudioSource.PlayClipAtPoint(pickupClip, transform.position);
			
			pegou = true;

			touch = GameObject.Find("hero").GetComponent<TouchController>();

			touch.enabled = false;

		}
	}

}
