using UnityEngine;
using System.Collections;
using System.IO;
using SpaceShipClass;
public class PegasusButtonScript : MonoBehaviour {
	public string shipName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void pokreniIgru(){
		File.WriteAllText ("Resources", "Pegasus");
		SpaceShip ship = SpaceShip.Instance ("Pegasus");
		ship.setupBack ();
		Application.LoadLevel (1);
	}
}
