using UnityEngine;
using System.Collections;

public class SelectLevel : MonoBehaviour {
	
	public GUISkin skin;
	
	private float boxWidth = 406f;
	private float boxHeight = 507f;
	
	private float folhaWidth = 246f;
	private float folhaHeight = 151f;
	
	private float offset = 10f;
	
	private TouchController touch;
	
	
	
	void Start () {
		G.rate = Screen.height/480.0f;
		boxWidth = boxWidth * G.rate;
		boxHeight = boxHeight * G.rate;
		folhaWidth = folhaWidth * G.rate;
		folhaHeight = folhaHeight * G.rate;
		offset = offset * G.rate;
		skin.button.fontSize = Mathf.RoundToInt(18*G.rate);
		skin.box.fontSize = Mathf.RoundToInt(30*G.rate);
		skin.customStyles[2].fontSize = Mathf.RoundToInt(30*G.rate);
		skin.customStyles[3].fontSize = Mathf.RoundToInt(30*G.rate);
		skin.customStyles[4].fontSize = Mathf.RoundToInt(30*G.rate);
		skin.customStyles[5].fontSize = Mathf.RoundToInt(30*G.rate);
	}
	
	void OnGUI() {

		
		GUI.skin = skin;
		GUI.Box(new Rect( (Screen.width - boxWidth)/2, (Screen.height - boxHeight)/2, boxWidth, boxHeight ), "",skin.customStyles[1]);
		//GUI.Button(new Rect((Screen.width - cntWidth)/2, (Screen.height - cntHeight)/2, cntWidth, cntHeight), "JOGAR");
		if(GUI.Button(new Rect((Screen.width - folhaWidth)/2 - offset*16, (Screen.height - folhaHeight)/2 + offset*8, folhaWidth, folhaHeight), "LEVEL 1" , skin.customStyles[2])){
			Application.LoadLevel("Level01");
		}
		if(GUI.Button(new Rect((Screen.width - folhaWidth)/2 - offset*16, (Screen.height - folhaHeight)/2 - offset*8, folhaWidth, folhaHeight), "LEVEL 3" , skin.customStyles[5])){
			Application.LoadLevel("");
		}
		if(GUI.Button(new Rect((Screen.width - folhaWidth)/2 + offset*16, (Screen.height - folhaHeight)/2 + offset*2, folhaWidth, folhaHeight), "LEVEL 2" , skin.customStyles[4])){
			Application.LoadLevel("");
		}
		if(GUI.Button(new Rect((Screen.width - folhaWidth)/2 + offset*16, (Screen.height - folhaHeight)/2 - offset*12, folhaWidth, folhaHeight), "LEVEL 4" , skin.customStyles[4])){
			Application.LoadLevel("");
		}
		

	}
	
	
}
