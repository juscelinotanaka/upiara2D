using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	
	public GUISkin skin;
	
	private float boxWidth = 406f;
	private float boxHeight = 507f;
	
	private float cntWidth = 150f;
	private float cntHeight = 60f;

	private float configWidth = 180f;
	private float configHeight = 58f;
	
	private float offset = 10f;
	
	private TouchController touch;
	
	
	
	void Start () {
		G.rate = Screen.height/480.0f;
		G.Tucumas = 5;
		boxWidth = boxWidth * G.rate;
		boxHeight = boxHeight * G.rate;
		cntWidth = cntWidth * G.rate;
		cntHeight = cntHeight * G.rate;
		configWidth = configWidth * G.rate;
		configHeight = configHeight * G.rate;
		offset = offset * G.rate;
		skin.button.fontSize = Mathf.RoundToInt(18*G.rate);
		skin.box.fontSize = Mathf.RoundToInt(30*G.rate);
		skin.customStyles[0].fontSize = Mathf.RoundToInt(30*G.rate);
	}
	
	void OnGUI() {
		
		
		GUI.skin = skin;
		//GUI.Box(new Rect( (Screen.width - boxWidth)/2, (Screen.height - boxHeight)/2, boxWidth, boxHeight ), "");
		if(GUI.Button(new Rect((Screen.width - cntWidth)/2, (Screen.height - cntHeight)/2, cntWidth, cntHeight), "JOGAR",skin.customStyles[0])){
			Application.LoadLevel("SelectLevel");
		}
		GUI.Button(new Rect((Screen.width - configWidth)/2, (Screen.height - configHeight)/2 + offset*10, configWidth, configHeight), "CONFIGURAÇOES");



		
	}
	
	
}