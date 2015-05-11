using UnityEngine;
using System.Collections;
using SpaceShipClass;
using System.IO;

public class GiftBehavior : MonoBehaviour {
	public float brzina = 400f;
	public SpaceShip ship;
	// Use this for initialization
	void Start () {
		ship = SpaceShip.Instance (File.ReadAllText("Resources"));
	}
	
	// Update is called once per frame
	void Update () {
		int a, b, c;
		int a1, b1, c1;
		transform.position = transform.position + new Vector3 (brzina * Time.deltaTime,brzina * Time.deltaTime, brzina * Time.deltaTime);
		if (transform.position.x < 0f)
			a = (int)transform.position.x * -1;
		else
			a = (int)transform.position.x;
		if (transform.position.y < 0f)
			b = (int)transform.position.y * -1;
		else
			b = (int)transform.position.y;
		if (transform.position.z < 0f)
			c = (int)transform.position.z * -1;
		else
			c = (int)transform.position.z;
		if (ship.x < 0)
			a1 = (int)ship.x * -1;
		else
			a1 = (int)ship.x;
		if (ship.y < 0)
			b1 = (int)ship.y  * -1;
		else
			b1 = (int)ship.y ;
		if (ship.z < 0)
			c1 = (int)ship.z * -1;
		else
			c1 = (int)ship.z;
		if (a+500 < a1 || b+500 < b1 || c+500 < c1) {
			Destroy(gameObject);
		}
	}
	void OnCollisionEnter(Collision collision){
		
		if (collision.collider.gameObject.tag == "Bullet" ||
			collision.collider.gameObject.tag == "Bomba") {
			Destroy (collision.collider.gameObject);
			Destroy (gameObject);
			ship.Score--;
		}
		if (collision.collider.gameObject.tag == "Ship") {
			ship.Shields += (int)Random.Range (1, 15);
			ship.PrimaryWepon += (int)Random.Range (1, 15);
			ship.SecondaryWepon += (int)Random.Range (1, 15);
			ship.timesForSpecial += (int)Random.Range (0, 1);
			Destroy (gameObject);
		}
	}
}
