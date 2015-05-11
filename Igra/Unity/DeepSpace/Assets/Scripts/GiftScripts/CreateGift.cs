using UnityEngine;
using System.Collections;
using SpaceShipClass;
using System.IO;
public class CreateGift : MonoBehaviour {
	public GameObject giftWepon;
	public SpaceShip ship;
	private float cooldown = -10f;
	private float cooldownAmount = 10;
	// Use this for initialization
	void Start () {
		ship = SpaceShip.Instance (File.ReadAllText("Resources"));
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldown < 0) {
			stvoriGift();
			cooldown = cooldownAmount;
		}
		cooldown -= Time.deltaTime;
	}
	public void stvoriGift(){
			Vector3 position = new Vector3 (Random.Range (ship.x - 200f, ship.x + 200f), 
			                                Random.Range (ship.y - 200f, ship.y + 200f), 
			                                Random.Range (ship.z - 200f, ship.z + 200f));
		Instantiate (giftWepon, position, transform.rotation);
	}
}
