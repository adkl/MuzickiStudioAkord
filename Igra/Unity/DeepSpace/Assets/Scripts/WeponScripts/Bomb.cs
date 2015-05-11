using UnityEngine;
using System.Collections;
using SpaceShipClass;
using System.IO;
public class Bomb : MonoBehaviour {

	public GameObject SecondaryWepon;
	public float debouncing = -0.2f;
	public SpaceShip ship = SpaceShip.Instance (File.ReadAllText("Resources"));
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1) && debouncing < 0 && ship.SecondaryWepon > 0) {
			Instantiate (SecondaryWepon, transform.position, transform.rotation);
			debouncing = 0.3f;
			ship.SecondaryWepon -= 1;
		}
		debouncing -= Time.deltaTime;
	}
}
