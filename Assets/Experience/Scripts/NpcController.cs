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
	}



	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.CompareTag("Player"))
		Debug.Log("Game over" + hit.gameObject.name);

	}
}
