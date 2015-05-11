using UnityEngine;
using System.Collections;
using System.IO;
using SpaceShipClass;
public class EnterpriseButtonScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void pokreniIgru(){
		File.WriteAllText ("Resources", "Enterprise");
		SpaceShip ship = SpaceShip.Instance ("Enterprise");
		ship.setupBack ();
		Application.LoadLevel (1);
	}
}
