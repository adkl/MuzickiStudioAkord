using UnityEngine;
using System.Collections;
using SpaceShipClass;
using System.IO;
using System.Collections.Generic;
using AssemblyCSharp;

public class CreateAsteroids : MonoBehaviour {
	public GameObject asteroidCeres;
	public GameObject asteroidVesta;
	public GameObject asteroidIrene;
	public GameObject asteroidFortuna;
	public SpaceShip ship;
	public int whatToCreate = 0;
	private int dontCreate = 0;
	private float cooldown = -1f;
	private float cooldownAmount = 1;
	// Use this for initialization
	void Start () {
		ship = SpaceShip.Instance (File.ReadAllText("Resources"));
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldown < 0) {
			stvoriAsteroid();
			cooldown = cooldownAmount;
		}
		cooldown -= Time.deltaTime;
	
	}
	public void stvoriAsteroid(){
		if (ship is Pegasus && ship.specialWeponActive == true) {
			dontCreate = 10;
			ship.specialWeponActive = false;
		}
		if (dontCreate == 0) {
			Vector3 position = new Vector3 (Random.Range (ship.x - 2000f, ship.x + 2000f), 
		                                Random.Range (ship.y - 2000f, ship.y + 2000f), 
		                                Random.Range (ship.z - 2000f, ship.z + 2000f));

			if(whatToCreate >= 0 && whatToCreate <= 5){
				Instantiate (asteroidCeres, position, transform.rotation);
				whatToCreate++;
			}
			else if(whatToCreate > 5 && whatToCreate <= 8){
				Instantiate (asteroidVesta, position, transform.rotation);
				whatToCreate++;
			}
			else if(whatToCreate >= 9 && whatToCreate <= 11){
				Instantiate (asteroidIrene, position, transform.rotation);
				whatToCreate++;
			}
			else if(whatToCreate == 12){
				Instantiate (asteroidFortuna, position, transform.rotation);
				whatToCreate = 0;
			}

		} else
			dontCreate -= 1;
	}


}
