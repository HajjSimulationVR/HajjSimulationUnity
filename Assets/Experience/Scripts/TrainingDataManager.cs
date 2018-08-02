﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data {
	public string name;
	public string image;
	public string description;
	public string percentage;
}
[System.Serializable]
public class TrainingsData {
	public Data[] trainingsData;
}

public class TrainingDataManager : MonoBehaviour {

	public GameObject trainingPanel;
	public Transform contentParent;

	public TrainingsData trainingsData;

	// Use this for initialization
	void Start () {
		WebManager.Instance.Get (ParseData, HandleError);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ParseData(string data) {
		trainingsData = JsonUtility.FromJson<TrainingsData> (FixData(data)) ;

		foreach (var item in trainingsData.trainingsData) {
			var panel = Instantiate (trainingPanel, contentParent).GetComponent<PanelTraining>();
			panel.FillData (item);
		}
	}

	string FixData(string data) {
		return "{\"trainingsData\" :" + data + "}";
	}
	public void HandleError(string error) {

	}
}
