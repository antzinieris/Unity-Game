using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FPSController : MonoBehaviour {
	public Vector3 fpspos;
	public static float tempy;
	public static double tempy2;
	public static float posy;
	public static float posx;
	public static float posz;
	public static Quaternion forpos;
	public static Vector3 fpsposition;
	public static Vector3 fpsdirection;
	public static Quaternion fpsrotation;
	public static Vector3 spawnpos;
	private int distance;
	private int flag;
	public GameObject cube;
	public Color32 yellow;
	public Color32 green;
	public Color32 red;
	public Color32 blue;

	void Start () {
		transform.position = new Vector3 ((menuscript.number) / 2, 2, (menuscript.number) / 2);

		distance = 2;
		fpsposition = new Vector3 ((int)transform.position.x, (int)transform.position.y, (int)transform.position.z);
		fpsdirection = transform.forward;
		fpsrotation = transform.rotation;
		spawnpos = fpsposition + fpsdirection * distance;
		fpspos = transform.position;
		tempy = transform.position.y;
		flag = 0;
		red = new Color32 (255, 0, 0, 255);
		yellow = new Color32 (255, 255, 0, 255);
		green = new Color32 (0, 255, 0, 255);
		blue = new Color32 (0, 0, 255, 255);

	}
	void Update(){


		fpspos = transform.position;
		posy = transform.position.y;
		posz = transform.position.z;
		posx = transform.position.x;

		fpsposition = new Vector3 ((int)transform.position.x, (int)transform.position.y, (int)transform.position.z);
		fpsdirection = new Vector3((int)transform.forward);
		fpsrotation = transform.rotation;
		spawnpos = fpsposition + fpsdirection * distance;
		Level ();	
		enterNlevel ();
		Raycasting ();

		if (transform.position.y < 0) {
			transform.position = new Vector3 ((menuscript.number) / 2, 2, (menuscript.number) / 2);
			Basic.lifes = Basic.lifes - 1;
		}
		Debug.Log ("points= " + Basic.points);
		Debug.Log ("lifes= " + Basic.lifes);
	}
	public void Level(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			StartCoroutine(Example());
			if (transform.position.y > tempy +0.5) {
				Basic.points = Basic.points + 5;
				tempy = transform.position.y;
			} 
		}
		if (transform.position.y < tempy - 1) {
			Basic.points = Basic.points - 5;
			tempy = transform.position.y;
		}
	}

	IEnumerator Example()
	{
		
		yield return new WaitForSeconds(1);

	}
	void enterNlevel(){
		if (flag == 0) {
			if (transform.position.y > menuscript.number) {
				flag = 1;
				Basic.points = Basic.points + 100;
				Basic.lifes = Basic.lifes + 1;
			}
		}
	}
	void Raycasting(){

		Ray ray = new Ray (new Vector3(transform.position.x,transform.position.y,transform.position.z), transform.forward);
		RaycastHit hit;
		if (Input.GetKeyDown (KeyCode.E)){
			if (Physics.Raycast (ray, out hit, 5)) {
				if (hit.transform.gameObject.GetComponent<Renderer> ().material.color == green) {
					hit.transform.gameObject.GetComponent<Renderer> ().material.color = red;
					Basic.numberofcubes++;
					Basic.points = Basic.points - 5;
				} else if (hit.transform.gameObject.GetComponent<Renderer> ().material.color == red) {
					hit.transform.gameObject.GetComponent<Renderer> ().material.color = yellow;
					Basic.numberofcubes++;
					Basic.points = Basic.points - 5;
				
				} else if (hit.transform.gameObject.GetComponent<Renderer> ().material.color == yellow) {
					hit.transform.gameObject.GetComponent<Renderer> ().material.color =blue;
					Basic.numberofcubes++;
					Basic.points = Basic.points - 5;

				}
				//Destroy (hit.transform.gameObject);
					print ("There is something in front of the object!");
			}
		}
	}
	/*void Raycasting(){

		Ray ray = new Ray (new Vector3(transform.position.x,transform.position.y,transform.position.z), transform.forward);
		RaycastHit hit;
		if (Input.GetKeyDown (KeyCode.E)){
			if (Physics.Raycast (ray, out hit, 5)) {
				if (hit.transform.tag=="Greencube") {
					Destroy (hit.transform.gameObject);
					Instantiate (GetComponent<Basic>().Redcube, new Vector3(hit.transform.position.x,hit.transform.position.y,hit.transform.position.z), Quaternion.identity);
					Basic.numberofcubes++;
					Basic.points = Basic.points - 5;
				} else if (hit.transform.tag=="Redcube") {
					Destroy (hit.transform.gameObject);
					Instantiate (GetComponent<Basic>().Yellowcube, new Vector3(hit.transform.position.x,hit.transform.position.y,hit.transform.position.z), Quaternion.identity);
					Basic.points = Basic.points - 5;

				} else if (hit.transform.tag=="Yellowcube") {
					Destroy (hit.transform.gameObject);
					Instantiate (GetComponent<Basic>().Bluecube,new Vector3(hit.transform.position.x,hit.transform.position.y,hit.transform.position.z), Quaternion.identity);
					Basic.points = Basic.points - 5;

				}
				//Destroy (hit.transform.gameObject);
				print ("There is something in front of the object!");
			}
		}
	}*/

		
}
