using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour {

	public float walkSpeed;
	private CharacterController charachterController;
	private Vector3 moveDir;

	// Use this for initialization
	void Start () {
		charachterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (transform.forward * Time.deltaTime * walkSpeed);
		if (transform.position.z > 75) {
			Destroy (gameObject);
		}
	}
}
