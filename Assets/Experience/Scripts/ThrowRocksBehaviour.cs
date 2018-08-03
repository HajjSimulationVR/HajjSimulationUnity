using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRocksBehaviour : MonoBehaviour {

	public GameObject rock;
	public Transform throwPoint;
	public float force;
	public bool canThrow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (canThrow & Input.GetMouseButtonDown (0))
			ThrowRock ();
	}

	public void ThrowRock() {
		GameObject go = Instantiate (rock, throwPoint.position, Camera.main.transform.rotation);
		Rigidbody rb = go.AddComponent<Rigidbody> ();
		rb.AddForce (Camera.main.transform.forward * force);
	}
}
