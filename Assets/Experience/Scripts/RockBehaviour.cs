using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : MonoBehaviour {
	
	public bool correctRock;

	void Start () {
		
	}

	void Update () {
		
	}

	public void OnPoinerClick() {
		if (!correctRock) {
			Debug.Log ("Not correct");
			return;
		} else if (RocksManager.Instance.rocks == 7) {
			Debug.Log ("Rocks Achieved!");
			return;
		}
		FindObjectOfType<FirstPersonController> ().canRun = true;
		RocksManager.Instance.AddRock ();
		Destroy(gameObject);
	}
}
