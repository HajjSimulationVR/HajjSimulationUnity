using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTraining : MonoBehaviour {
	public Text titleText;
	public RawImage thumnail;
	public GameObject progressPanel;
	public Text progressText;
	public Text descriptionText;

	public void FillData(Data d) {
		titleText.text = d.name;
		WebManager.Instance.GetTexture (d.image, SetImage, HandleError);
		descriptionText.text = d.description;
		progressText.text = d.percentage + "%";
	}

	void SetImage(Texture tex) {
		thumnail.texture = tex;
	}

	void HandleError(string error) {
		
	}


}
