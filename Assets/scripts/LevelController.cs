using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
	public static LevelController Global;

	[HideInInspector]
	public List<float> SpawnQueue = new List<float>();

	[HideInInspector]
	public List<GameObject> Points = new List<GameObject>();

	public GameObject CriticalPointPref;

	public GameObject[] SpecialCriticalPoints;

	const float MinimumCriticalPointDistance = 1f;

	[Space]
	public GameObject LostView;

	[Space]
	public Card[] Cards;

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
				var spawned = SpawnCriticalPoint (CriticalPointPref);
				if (spawned != null) {
					SpawnQueue.RemoveAt (i);
					Points.Add (spawned);
					break;
				}
			}
		}

		SpawnSpecial ();
	}

	void SpawnSpecial() {
		var chance = Random.Range(0,100);
		if (chance <= 2)
		{
			var spawned = SpawnCriticalPoint (SpecialCriticalPoints [Random.Range (0, SpecialCriticalPoints.Length)]);
			Points.Add (spawned);
		}
	}

	GameObject SpawnCriticalPoint(GameObject pointPref) {
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
			while (Points.Contains (null)) {
				Points.Remove (null);
			}
			foreach (var point in LevelController.Global.Points) {
				if (Vector2.Distance (point.transform.position, RandomPos) < MinimumCriticalPointDistance) {
					TooClose = true;
					break;
				}
			}

			if (TooClose) {
				continue;
			}
				

			var CriticalPoint = Instantiate (pointPref, new Vector3(RandomPos.x , RandomPos.y, -1), new Quaternion ());
			return CriticalPoint;
		}

		return null;
	}

	public void Lose() {
		PlayerPrefs.SetFloat ("GoldBooster", 1f);
		PlayerPrefs.SetFloat ("HealthBooster", 1f);
		PlayerPrefs.SetFloat ("DamageBooster", 1f);


		Time.timeScale = 0f;
		LostView.SetActive (true);
	}
}
