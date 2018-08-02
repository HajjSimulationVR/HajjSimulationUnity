using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class WebManager : MonoBehaviour {
	
	public static WebManager Instance;
	public string url;
	public string data;

	public delegate void GetAction (string msg);
	public delegate void GetTextureAction (Texture tex);

	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy (gameObject);   
	}

	public void Get(GetAction OnSuccess, GetAction OnFail) {
		StartCoroutine (GetData (OnSuccess, OnFail));
	}

	IEnumerator GetData(GetAction OnSuccess, GetAction OnFail)
	{
		using (UnityWebRequest www = UnityWebRequest.Get(url))
		{
			yield return www.SendWebRequest();

			if (www.isNetworkError || www.isHttpError)
			{
				Debug.LogError(www.error);
				data = null;
				OnFail (www.error);
			}
			else
			{
				data = www.downloadHandler.text;
				OnSuccess (data);
			}
		}
	}

	public void GetTexture(string url, GetTextureAction OnSuccess, GetAction OnFail) {
		StartCoroutine(GetTextureData(url, OnSuccess, OnFail));
	}

	IEnumerator GetTextureData(string url, GetTextureAction OnSuccess, GetAction OnFail) {
		UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
		yield return www.SendWebRequest();

		if(www.isNetworkError || www.isHttpError) {
			Debug.LogError(www.error);
			OnFail (www.error);
		}
		else {
			Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
			OnSuccess (myTexture);
		}
	}

}
