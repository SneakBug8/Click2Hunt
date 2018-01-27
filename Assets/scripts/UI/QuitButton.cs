using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour {

	// Use this for initialization
	void Start() {
		gameObject.GetComponent<Button>().onClick.AddListener (Quit);
	}

	void Quit() {
		Application.Quit ();
	}
}
