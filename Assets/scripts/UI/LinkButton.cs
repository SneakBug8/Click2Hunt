using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkButton : MonoBehaviour {
	void Start() {
		gameObject.GetComponent<Button>().onClick.AddListener (OnClick);
	}

	void OnClick() {
		Application.OpenURL ("https://sneakbug8.com");
	}
}
