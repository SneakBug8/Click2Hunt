using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneChanger : MonoBehaviour {
	public string Scene;

	bool loadedScene = false;
	void Update () {
		if (!loadedScene) {
			SceneManager.LoadScene (Scene);
			loadedScene = true;
		}
	}
}
