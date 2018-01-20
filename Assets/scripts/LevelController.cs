using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
	public static LevelController Global;

	public List<CriticalPoint> Points = new List<CriticalPoint>();

	public List<float> SpawnQueue = new List<float>();

	public GameObject CriticalPointPref;

	const float MinimumCriticalPointDistance = 1f;

	public GameObject LostView;

	void Awake () {
		Global = this;
	}

	void Start() {
		Time.timeScale = 1f;
	}

	void Update() {
		for (int i = 0; i < SpawnQueue.Count; i++) {
			SpawnQueue [i] -= Time.deltaTime;
			if (SpawnQueue [i] <= 0) {
				var spawned = SpawnCriticalPoint ();
				if (spawned != null) {
					Points.Add (spawned);
					SpawnQueue.RemoveAt (i);
					break;
				}
			}
		}
	}

	CriticalPoint SpawnCriticalPoint() {
		var DownLeft = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		var UpperRight  = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));

		int i = 0;
		while (i < 100) {
			i++;

			var RandomPos = new Vector2 (Random.Range (DownLeft.x, UpperRight.x), Random.Range (DownLeft.y, UpperRight.y));
			var hit = Physics2D.Raycast (RandomPos, Vector2.zero);

			if (!hit) {
				continue;
			}

			if (hit.collider.transform != Monster.Global.transform) {
				continue;
			}

			bool TooClose = false;
			foreach (var point in LevelController.Global.Points) {
				if (Vector2.Distance (point.transform.position, RandomPos) < MinimumCriticalPointDistance) {
					TooClose = true;
					break;
				}
			}

			if (TooClose) {
				continue;
			}
				

			var CriticalPoint = Instantiate (CriticalPointPref, new Vector3(RandomPos.x , RandomPos.y, -1), new Quaternion ());
			return CriticalPoint.GetComponent<CriticalPoint>();
		}

		return null;
	}

	public void Lose() {
		Time.timeScale = 0f;
		LostView.SetActive (true);
	}
}
