using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonDestroy : MonoBehaviour {
	public GameObject obj;
	private void Start() {
		GetComponent<Button>().onClick.AddListener(OnClick);
	}

	void OnClick() {
		Destroy(obj);
	}
}
