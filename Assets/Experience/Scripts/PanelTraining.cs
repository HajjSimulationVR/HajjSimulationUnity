using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTraining : MonoBehaviour {
	public Data data;
	public Text titleText;
	public RawImage thumnail;
	public GameObject progressPanel;
	public Text progressText;
	public Text descriptionText;

	public void FillData(Data d) {
		data = d;
		titleText.text = d.name;
		WebManager.Instance.GetTexture (d.image, SetImage, HandleError);
		descriptionText.text = d.description;
		progressText.text = d.percentage + "%";
		GetComponent<Button> ().onClick.AddListener (OnButtonClick);
	}

	void SetImage(Texture tex) {
		thumnail.texture = tex;
	}

	void HandleError(string error) {
		
	}

	public void OnButtonClick() {
		// Debug.Log(WebManager.Instance.Post<Data> (data.pk + "/progress/", null));
		UnityEngine.SceneManagement.SceneManager.LoadScene (data.name);
	}
}
