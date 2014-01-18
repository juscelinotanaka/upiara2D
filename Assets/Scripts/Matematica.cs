using UnityEngine;
using System.Collections;

public class Matematica {

	public int num1;
	public int num2;
	public int sinal;
	public int resultado;

	//string[] names = {"Matt", "Joanne", "Robert"};
	//public string[] sinalString = {"+", "-", "x", "/"};

	public string getSinal() {
		switch (sinal) {
		case 0:
			return "+";
		case 1:
			return "-";
		case 2:
			return "*";
		case 3:
			return "/";

		}
		return "";
	}
	
	// Use this for initialization
	public Matematica () {


		if (G.nivel == 1) {
			num1 = Random.Range(1,6);
			num2 = Random.Range(1,6);
			sinal = Random.Range(0,2);
		} else if (G.nivel == 2) {
			num1 = Random.Range(1,10);
			num2 = Random.Range(1,10);
			sinal = Random.Range(0,2);
		} else if (G.nivel == 3) {
			num1 = Random.Range(1,6);
			num2 = Random.Range(1,6);
			sinal = Random.Range(0,4);
		} else if (G.nivel == 4) {
			num1 = Random.Range(1,10);
			num2 = Random.Range(1,10);
			sinal = Random.Range(0,4);
		}
		
		switch (sinal) {
			case 0:
				resultado = num1 + num2;
				break;
			case 1:
				resultado = num1 - num2;
				break;
			case 2:
				resultado = num1 * num2;
				break;
			case 3:
				resultado = num1 / num2;
				break;
		}
		Debug.Log("" + num1 + " " + getSinal() + " " + num2 + " = " + resultado);
	}
}
