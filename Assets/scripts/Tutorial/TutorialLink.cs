using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialLink : MonoBehaviour {
	public string ValueName;
	public string SceneIfFirstly;
	public string SceneIfSeen;

	private void Start() {
		GetComponent<Button>().onClick.AddListener(OnClick);
	}

	void OnClick() {
		if (PlayerPrefs.GetInt("Tutorial_" + ValueName) == 0) {
			PlayerPrefs.SetInt("Tutorial_" + ValueName, 1);
			SceneManager.LoadScene(SceneIfFirstly);
		}
		else {
			SceneManager.LoadScene(SceneIfSeen);
		}
	}
}
