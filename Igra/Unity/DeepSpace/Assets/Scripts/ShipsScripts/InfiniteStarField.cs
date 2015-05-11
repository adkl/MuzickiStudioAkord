using UnityEngine;
using System.Collections;

public class InfiniteStarField : MonoBehaviour {
	private Transform tx;
	private ParticleSystem.Particle[] points;
	public int starsMax = 1000;
	public float starSize = 100f;
	public float starDistance = 30;
	public float starClipDistance = 20;
	private float starDistanceSqr;
	private float starClipDistanceSqr;
	private ParticleSystem shuriken;

	// Use this for initialization
	void Start () {
		tx = transform;
		starDistanceSqr = starDistance * starDistance;
		starClipDistanceSqr = starClipDistance * starClipDistance;
	}
	
	
	private void CreateStars() {
		points = new ParticleSystem.Particle[starsMax];
		
		for (int i = 0; i < starsMax; i++) {
			points[i].position = Random.insideUnitSphere * starDistance + tx.transform.position;
			points[i].color = new Color(1,1,1,1);
			points[i].size = starSize;
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		if ( points == null ) CreateStars();

		for (int i = 0; i < starsMax; i++) {
			if ((points[i].position - tx.position).sqrMagnitude > starDistanceSqr) {
				points[i].position = Random.insideUnitSphere.normalized * starDistance + tx.position;
			}
			
			if ((points[i].position - tx.position).sqrMagnitude <= starClipDistanceSqr) {
				float percent = (points[i].position - tx.position).sqrMagnitude / starClipDistanceSqr;
				points[i].color = new Color(1,1,1, percent);
				points[i].size = percent * starSize;
			}

		}

		GetComponent<ParticleSystem> ().SetParticles (points, points.Length);

	}
}
