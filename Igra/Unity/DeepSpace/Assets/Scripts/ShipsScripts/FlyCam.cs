using UnityEngine;
using System.Collections;
using SpaceShipClass;
using System.IO;
using AssemblyCSharp;
public class FlyCam : MonoBehaviour {
	
	
	public float speed = 100.0f;		// max speed of camera
	public float sensitivity = 0.25f; 		// keep it from 0..1
	public bool inverted = false;
	private bool slowDown = false;


	// smoothing
	public bool smooth = true;
	public float acceleration = 0.01f;		// keep it from 0 to 1
	private Vector3 lastDir = new Vector3();
	
	public float debouncing = -0.2f;

	//Ship
	SpaceShip ship = SpaceShip.Instance(File.ReadAllText("Resources"));
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(new Vector3(Input.GetAxis("Mouse Y")*-1, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * 200.0f);
		
		// Movement of the camera
		
		Vector3 dir = new Vector3();			// create (0,0,0)
		
		if (Input.GetKey(KeyCode.W)) dir.z += 1.0f;
		if (Input.GetKey (KeyCode.S)) {
			dir.z -= 1.0f;
			slowDown = true;
		}
		if (Input.GetKey (KeyCode.A)) dir.x -= 1.0f;
		if (Input.GetKey (KeyCode.D)) dir.x += 1.0f;
		if (Input.GetKey (KeyCode.E) && debouncing < 0) {
			if(ship.timesForSpecial > 0){
				ship.specialWeponActive = true;
				ship.timesForSpecial -= 1;
				debouncing = 0.3f;
				if(ship is Interpid){
					ship.specialWeponActive = false;
					ship.Shields += 100;
				}
			}

		}
		debouncing -= Time.deltaTime;
		dir.Normalize();

		if (Input.GetKey (KeyCode.Escape)) {
			GameObject.Find("Panel").GetComponent<ExitPanel>().displayMenu();
		}

		if (dir != Vector3.zero && slowDown == false) {
			// some movement 
			if (ship.Speed < 1) {
				ship.Speed += acceleration * Time.deltaTime * 40;
			} else {
				ship.Speed = 1.0f;
			}
			
			lastDir = dir;
		} else if (slowDown == true) {
			slowDown = false;
			if (ship.Speed > 0) {
				ship.Speed -= acceleration * Time.deltaTime * 60;
			}
			else {
				ship.Speed = 0.0f;
		}
		} else {
			// should stop
			
			if (ship.Speed > 0) {
				ship.Speed -= acceleration * Time.deltaTime;
			}
			else {
				ship.Speed = 0.0f;
			}
		}
		
		ship.x = transform.position.x;
		ship.y = transform.position.y;
		ship.z = transform.position.z;
		
		if (smooth) 
			transform.Translate( lastDir * ship.Speed * speed * Time.deltaTime );
		
		else 
			transform.Translate ( dir * speed * Time.deltaTime );

		if (ship.Shields < 0) {
			File.WriteAllText("Score", ship.Score.ToString());
			Application.LoadLevel(2);
		}

	}
	
	void OnGUI() {
		GUI.color = Color.red;
		GUILayout.Box (File.ReadAllText("Resources"));
		GUILayout.Box ("Speed: " + ((int)(ship.Speed*10000)).ToString());
		GUILayout.Box ("Shields: " + ship.Shields.ToString());
		GUILayout.Box ("Primary Wepon : " + ship.PrimaryWepon.ToString ());
		GUILayout.Box ("Second Wepon: " + ship.SecondaryWepon.ToString());
		GUILayout.Box ("Special Attack : " + ship.timesForSpecial.ToString());
		GUI.color = Color.white;
		GUILayout.Box ("Score : " + ship.Score);
	}
}
