using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class menuscript : MonoBehaviour {

	public static int number;

	private InputField input;

	void Awake(){
		input = GameObject.Find ("InputField").GetComponent<InputField>();
	}

	public void GetInput(string num){
		Debug.Log ("enter " + num);
			input.text="";
		number = int.Parse (num);
		SceneManager.LoadScene (1);
	}

}
