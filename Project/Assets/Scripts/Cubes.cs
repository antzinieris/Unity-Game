using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour {

	public static int cubeam;
	// Use this for initialization
	void Start () {
		cubeam = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeColor(){
		if (cubeam == 3) {
			transform.GetComponent<Renderer> ().material.color = Color.red;
			Debug.Log ("hey");
		} else if (cubeam == 2) {
			transform.GetComponent<Renderer> ().material.color = Color.yellow;
			Debug.Log ("heyy");
		} else if (cubeam == 1) {
			transform.GetComponent<Renderer> ().material.color = Color.blue;
			Debug.Log ("heyyy");
		}
	}
}
