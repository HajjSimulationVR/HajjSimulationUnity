using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksManager : MonoBehaviour {

	public static RocksManager Instance;

	public GameObject wall;
	public int rocks;
	void Awake()
	{
		if (Instance == null) {
			Instance = this;
		}
		else if (Instance != this)
			Destroy (gameObject);   
	}
		
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddRock() {
		if (rocks == 7)
			return;
		++rocks;
		MsgManager.Instance.Show ("rocks collected! " + (7 - RocksManager.Instance.rocks).ToString() + " to go");
		if (rocks == 7)
			RocksAchieved ();
	}

	void RocksAchieved() {
		wall.SetActive (false);
		MsgManager.Instance.Show ("Achievement Unlocked: Rocks collected!");
		FindObjectOfType<FirstPersonController> ().walkSpeed = 1f;
		ProgressManager.Instance.SetProgress (40);
	}
}
