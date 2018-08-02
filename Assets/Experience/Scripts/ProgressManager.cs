using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgressData {
	public string pk;
	public string percentage;

	public ProgressData(string percentage, string pk) {
		this.pk = pk;
		this.percentage = percentage;
	}
}

public class ProgressManager : MonoBehaviour {
	
	public static ProgressManager Instance;
	public ProgressData progressData;
	public string path;

	void Awake()
	{
		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
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

	public void SetProgress(int percentage) {
		progressData.percentage = percentage.ToString();
		Debug.Log(WebManager.Instance.Put<ProgressData> (path, progressData));
	}
}
