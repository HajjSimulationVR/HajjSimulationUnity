using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgManager : MonoBehaviour {
	public static MsgManager Instance;
	public Text msgText;
	public float delay;
	public float distance;

	void Awake()
	{
		if (Instance == null) {
			Instance = this;
		}
		else if (Instance != this)
			Destroy (gameObject); 
		transform.GetChild (0).gameObject.SetActive (false);
	}

	public void Show(string msg) {
		msgText.text = msg;
		transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
		transform.LookAt (Camera.main.transform);
		StartCoroutine (ShowMsg ());
	}

	IEnumerator ShowMsg() {
		transform.GetChild (0).gameObject.SetActive (true);
		yield return new WaitForSeconds (delay);
		transform.GetChild (0).gameObject.SetActive (false);
	}
}
