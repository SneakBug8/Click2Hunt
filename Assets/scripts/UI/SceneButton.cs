using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour {
	public string SceneName;

	void Start() {
		gameObject.GetComponent<Button> ().onClick.AddListener (OnClick);
	}

	void OnClick() {
		SceneManager.LoadScene (SceneName);
	}
}
