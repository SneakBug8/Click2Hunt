using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkButton : MonoBehaviour {
	public string Url;

	void Start() {
		gameObject.GetComponent<Button>().onClick.AddListener (OnClick);
	}

	void OnClick() {
		Application.OpenURL (Url);
	}
}
