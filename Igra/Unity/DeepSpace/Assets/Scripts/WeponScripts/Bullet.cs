using UnityEngine;
using System.Collections;
using SpaceShipClass;
using System.IO;
public class Bullet : MonoBehaviour {
	public GameObject PrimaryWepon;
	public float debouncing = -0.2f;
	public SpaceShip ship = SpaceShip.Instance (File.ReadAllText("Resources"));
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0) && debouncing < 0 && ship.PrimaryWepon > 0) {
			//GameObject shooting = (GameObject)
			Instantiate (PrimaryWepon, transform.position, transform.rotation);
			debouncing = 0.3f;
			ship.PrimaryWepon -= 1;
		}
			debouncing -= Time.deltaTime;
	}

}
