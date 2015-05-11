using UnityEngine;
using System.Collections;

public class BulletForward : MonoBehaviour {
	public float BulletSpeed = 1000;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * BulletSpeed * Time.deltaTime);
	}
}
