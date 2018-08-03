using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamaratManager : MonoBehaviour {
	public static JamaratManager Instance;
	public int hitsNo;

	void Awake()
	{
		if (Instance == null) {
			Instance = this;
		}
		else if (Instance != this)
			Destroy (gameObject);   
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Hit() {
		++hitsNo;
		MsgManager.Instance.Show ("Nice shot! " + (7 - hitsNo) + " to go!");
		if (hitsNo == 7) {
			JamaratAchieved ();
		}
	}

	public void JamaratAchieved() {
		MsgManager.Instance.Show ("Jamarat Achieved!");
		ProgressManager.Instance.SetProgress (100);
	}
}
