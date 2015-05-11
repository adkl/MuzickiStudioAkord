using UnityEngine;
using System.Collections;
using SpaceShipClass;
using System.IO;
using AssemblyCSharp;

public abstract class Asteroid : MonoBehaviour, IObserver {
	public float brzina = 400f;
	public SpaceShip ship;
	public int Health {
		get;
		set;
	}
	// Use this for initialization
	void Start () {
		ship = SpaceShip.Instance (File.ReadAllText("Resources"));
	}
	
	// Update is called once per frame
	void Update () {
		int a, b, c;
		int a1, b1, c1;
		transform.position = Vector3.Lerp(transform.position, new Vector3 (ship.x, ship.y,ship.z),  Mathf.SmoothStep(0.0f,1.0f, Time.deltaTime*brzina));
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
		if(ship.specialWeponActive == true && ship is Enterprise){
			Destroy(gameObject);	
			GameObject[] others = GameObject.FindGameObjectsWithTag("Asteroid");
			foreach (GameObject other in others)
			{ Destroy(other); }

			ship.specialWeponActive = false;

		}
	
	}
	public abstract void update(GameObject secondObject);
	void OnCollisionEnter(Collision collision){
		update (collision.gameObject);
	}
	public void destroyMe(){
		GameObject refParticles = new GameObject ();
		refParticles = GameObject.Find("Efekat");
		refParticles.transform.position = transform.position;
		refParticles.gameObject.transform.GetComponent<ParticleSystem> ().Emit (50);
		Destroy(gameObject);
	}
}
