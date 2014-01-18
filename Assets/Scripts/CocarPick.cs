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
	public bool fimDaFase = false; 
	public string nextLevel;

	private bool pegou = false;
	private bool pegado = false;
	private bool resolvendo = false;
	private bool acabouFase = false;

	private float boxWidth = 400.0f;
	private float boxHeight = 300.0f;

	private float cntWidth = 100f;
	private float cntHeight = 40f;

	private float btnWidth;
	private float btnHeight = 40f;

	private float btnFWidth;
	private float btnFHeight = 40f;

	private float cocarWidth ;
	private float cocarHeight = 40f;

	private float offset = 30f;

	private PlayerControl control;
	private TouchController touch;

	private Matematica prob;

	private int resposta;
	private string[] textoBtn;

	void OnEnable() {
		G.GanhouEstrelas = 0;
		pegou = false;
		pegado = false;
		resolvendo = false;
		acabouFase = false;
		
		boxWidth = 400.0f;
		boxHeight = 300.0f;
		
		cntWidth = 100f;
		cntHeight = 40f;
		
		btnHeight = 40f;
		
		btnFHeight = 40f;
		
		cocarHeight = 40f;
		
		offset = 30f;
		
		G.rate = Screen.height/320.0f;
	}

	void Start () {

		offset = offset * G.rate;

		boxWidth = boxWidth * G.rate;
		boxHeight = boxHeight * G.rate;
		cntWidth = cntWidth * G.rate;
		cntHeight = cntHeight * G.rate;


		btnWidth = (boxWidth - offset*5f)/4f;
		btnHeight = btnHeight * G.rate;

		btnFWidth = (boxWidth - offset*4f)/3f;
		btnFHeight = btnFHeight * G.rate;

		cocarWidth = (boxWidth - 2*offset*4f)/3f;
		cocarHeight = cocarWidth * 513f / 710f;

		skin.button.fontSize = Mathf.RoundToInt(18*G.rate);

		skin.box.fontSize = Mathf.RoundToInt(24*G.rate);
		skin.label.fontSize = Mathf.RoundToInt(24*G.rate);

		skin.customStyles[0].fontSize = Mathf.RoundToInt(70*G.rate);

		prob = new Matematica();

		resposta = Random.Range(0,4);
		textoBtn = new string[4];
		for (int i = 0; i < 4; i++) {
			if (i == resposta) {
				textoBtn[i] = "" + prob.resultado;
			} else {
				textoBtn[i] = "" + Random.Range(-10, 20);
			}
		}

		for (int i = 1; i <= 3; i++) {
			skin.customStyles[i].overflow.left = -10;
			skin.customStyles[i].overflow.right = -10;
			skin.customStyles[i].overflow.top = -10;
			skin.customStyles[i].overflow.bottom = -10;

		}
		skin.customStyles[4].overflow.left = 0;
		skin.customStyles[4].overflow.right = 0;
		skin.customStyles[4].overflow.top = 0;
		skin.customStyles[4].overflow.bottom = 0;
	}

	void AnimaCocar1(int v) {
		skin.customStyles[1].overflow.left = v;
		skin.customStyles[1].overflow.right = v;
		skin.customStyles[1].overflow.top = v;
		skin.customStyles[1].overflow.bottom = v;
	}
	void AnimaCocar2(int v) {
		skin.customStyles[2].overflow.left = v;
		skin.customStyles[2].overflow.right = v;
		skin.customStyles[2].overflow.top = v;
		skin.customStyles[2].overflow.bottom = v;
	}
	void AnimaCocar3(int v) {
		skin.customStyles[3].overflow.left = v;
		skin.customStyles[3].overflow.right = v;
		skin.customStyles[3].overflow.top = v;
		skin.customStyles[3].overflow.bottom = v;
	}

	void AcabouFase() {
		acabouFase = true;
		for (int i = 1; i <= G.GanhouEstrelas; i++) {
			iTween.ValueTo(gameObject,iTween.Hash("from", -10, "to", 0, "time", 1, "delay", (i-1) * 0.7 ,"easetype",iTween.EaseType.easeInOutCubic,"onupdate", ("AnimaCocar"+i)));
		}
	}

	void ContinuarJogo() {
		if (fimDaFase) {
			AcabouFase();
		} else {
			touch.enabled = true;
			Destroy(gameObject);
		}
	}
	
	void OnGUI() {
		if (skin) {
			GUI.skin = skin;
			if (acabouFase) {
				GUI.Box(new Rect( (Screen.width - boxWidth)/2, (Screen.height - boxHeight)/2, boxWidth, boxHeight ), "");
				GUI.Label(new Rect((Screen.width - boxWidth)/2, (Screen.height - boxHeight)/2 + offset, boxWidth, boxHeight - offset - cntHeight), "NÍVEL CONCLUÍDO");

				int i;

				for (i = 0; i < G.GanhouEstrelas; i++) {
					GUI.Box(new Rect((Screen.width - boxWidth)/2 + (i+1)*offset + i*cocarWidth + 2*offset, (Screen.height - cocarHeight)/2, cocarWidth, cocarHeight), "", skin.customStyles[i+1]);
				}
				for (i = G.GanhouEstrelas; i < 3; i++) {
					GUI.Box(new Rect((Screen.width - boxWidth)/2 + (i+1)*offset + i*cocarWidth + 2*offset, (Screen.height - cocarHeight)/2, cocarWidth, cocarHeight), "", skin.customStyles[4]);
				}

				i = 0;
				if (GUI.Button(new Rect((Screen.width - boxWidth)/2 + (i+1)*offset + i*btnFWidth, (Screen.height + boxHeight)/2 - offset - btnFHeight, btnFWidth, btnFHeight), "Menu")) {
					Application.LoadLevel("MainMenu");
				}
				i++;
				if (GUI.Button(new Rect((Screen.width - boxWidth)/2 + (i+1)*offset + i*btnFWidth, (Screen.height + boxHeight)/2 - offset - btnFHeight, btnFWidth, btnFHeight), "Reiniciar")) {
					Application.LoadLevel(Application.loadedLevel);
				}
				i++;
				if (GUI.Button(new Rect((Screen.width - boxWidth)/2 + (i+1)*offset + i*btnFWidth, (Screen.height + boxHeight)/2 - offset - btnFHeight, btnFWidth, btnFHeight), "Continuar")) {
					Application.LoadLevel(nextLevel);
				}

			} else if (!pegado && pegou) {
				GUI.Box(new Rect( (Screen.width - boxWidth)/2, (Screen.height - boxHeight)/2, boxWidth, boxHeight ), "");
				if (resolvendo) {
					GUI.Label(new Rect((Screen.width - boxWidth)/2, (Screen.height - boxHeight)/2  + offset, boxWidth, boxHeight - offset - cntHeight), "Qual o resultado do problema a seguir:");
					GUI.Label(new Rect((Screen.width - boxWidth)/2, (Screen.height - boxHeight)/2 + 100*G.rate, boxWidth, boxHeight - offset - cntHeight), "" + prob.num1 + " " + prob.getSinal() + " " + prob.num2 +  " = ?", skin.customStyles[0] );
					for (int i = 0; i < 4; i++) {
						if (GUI.Button(new Rect((Screen.width - boxWidth)/2 + (i+1)*offset + i*btnWidth, (Screen.height + boxHeight)/2 - offset - btnHeight, btnWidth, btnHeight), textoBtn[i])) {
							if (i == resposta) {
								G.GanhouEstrelas++;
								iTween.MoveTo(gameObject, iTween.Hash("y", 5,"time",.6, "delay",0.3 ,"easetype","easeincubic"));
								iTween.ScaleTo(gameObject, iTween.Hash("x", 2, "y", 2,"time",.6, "delay",0.3 ,"easetype","easeincubic"));
								iTween.MoveTo(gameObject, iTween.Hash("y", 30,"time",.6, "delay",0.9 ,"easetype","easeincubic", "oncomplete", "ContinuarJogo", "oncompletetarget", gameObject));

								pegou = false;
							} else {
								iTween.ScaleTo(gameObject, iTween.Hash("x", 0.5, "y", 0.5,"time",.6, "delay",0.3 ,"easetype","easeincubic"));
								iTween.MoveTo(gameObject, iTween.Hash("y", -30,"time",.6, "delay",0.9 ,"easetype","easeincubic", "oncomplete", "ContinuarJogo", "oncompletetarget", gameObject));
								Debug.Log("Perdeu PlayBoy");
							}
							pegado = true;

						}
					}

				} else {
					GUI.Label(new Rect((Screen.width - boxWidth)/2 + 2*offset, (Screen.height - boxHeight)/2 + offset, boxWidth - 4*offset, boxHeight - offset - cntHeight), "Para ganhar o cocar você deve resolver o problema a seguir que desativará o trator que está destruíndo a floresta.");
					if (GUI.Button(new Rect((Screen.width - cntWidth)/2, (Screen.height + boxHeight)/2 - offset - cntHeight, cntWidth, cntHeight), "Continuar")) {
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

			touch = GameObject.Find("hero2").GetComponent<TouchController>();

			touch.enabled = false;

		}
	}

}
