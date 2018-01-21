using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenSprite : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var DownLeft = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		var UpperRight  = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));

		var height = UpperRight.y - DownLeft.y;
		var width = UpperRight.x - DownLeft.x;

		var renderer = GetComponent<SpriteRenderer> ();
		renderer.size = new Vector2 (width, height);
	}
}
