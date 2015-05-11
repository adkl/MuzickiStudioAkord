using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using SpaceShipClass;
public class TakeScore : MonoBehaviour {
	public Text scoreText;
	SpaceShip ship = SpaceShip.Instance(File.ReadAllText("Resources"));
	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		scoreText.text = "Score : " + File.ReadAllText ("Score");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void playAgain(){

		ship.setupBack ();                                
		Application.LoadLevel (1);
	}
	public void chooseDifferent(){  
		ship.clearInstance ();
		Application.LoadLevel (0);
	}
}
