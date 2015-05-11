using UnityEngine;
using System.Collections;

public class BombForward : MonoBehaviour {

	public float BombSpeed = 500;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * BombSpeed * Time.deltaTime);
	}
}
