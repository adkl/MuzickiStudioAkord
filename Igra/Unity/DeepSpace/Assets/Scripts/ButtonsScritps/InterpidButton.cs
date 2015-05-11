using UnityEngine;
using System.Collections;
using System.IO;
using SpaceShipClass;
public class InterpidButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void pokreniIgru(){
		File.WriteAllText ("Resources", "Interpid");
		SpaceShip ship = SpaceShip.Instance ("Interpid");
		ship.setupBack ();
		Application.LoadLevel (1);
	}
}
