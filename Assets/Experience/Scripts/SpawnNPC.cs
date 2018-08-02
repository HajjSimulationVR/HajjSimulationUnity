using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPC : MonoBehaviour {

	public GameObject NPC;
	public float initialNPCs;
	public float minOffsetX;
	public float maxOffsetX;
	public float minOffsetZ;
	public float maxOffsetZ;
	public float delay;
	public float spawnRate;

	private bool canOffsetZ = true;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < initialNPCs; i++) {
			spawn ();
		}
		canOffsetZ = false;
		InvokeRepeating ("spawn", delay, spawnRate);
	}

	// Update is called once per frame
	void Update () {
		
	}

	void spawn() {
		float offsetX, offsetZ;
		offsetX = Random.Range (minOffsetX, maxOffsetX);
		if (canOffsetZ)
			offsetZ = Random.Range (minOffsetZ, maxOffsetZ);
		else
			offsetZ = 0;
		Instantiate (NPC, transform.position + offsetX * Vector3.right + offsetZ * Vector3.forward, transform.rotation, transform);
	}
}
