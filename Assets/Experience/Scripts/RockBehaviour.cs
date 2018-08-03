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
			MsgManager.Instance.Show ("Wrong size :( try agian!");
			return;
		} else if (RocksManager.Instance.rocks == 7) {
			MsgManager.Instance.Show ("All rocks collected! ");
			return;
		}
		FindObjectOfType<FirstPersonController> ().canRun = true;
		RocksManager.Instance.AddRock ();
		Destroy(gameObject);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Jamarat")) {
			JamaratManager.Instance.Hit ();
			Destroy (gameObject);
		} else if (GetComponent<Rigidbody> () != null) {
			MsgManager.Instance.Show ("Be carful! You can harm someone!");
			Destroy (gameObject);
		}
	}
}
