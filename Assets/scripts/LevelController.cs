using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
	public static LevelController Global;
	public Dictionary<GameObject, float> Points = new Dictionary<GameObject, float>();

	public GameObject[] PointsPrefs;
	const float MinimumCriticalPointDistance = 2f;
	[Space]
	public GameObject LostView;

	void Awake () {
		Global = this;
	}

	void Start() {
		Time.timeScale = 1f;
		float timeout = 0;

		foreach(var pointpref in PointsPrefs) {
			var point = Instantiate(pointpref, new Vector3(), Quaternion.identity);
			point.SetActive(false);
			Points.Add(point, timeout);
			timeout += 0.2f;
		}
	}

	void Update() {
		var points = Points.Keys.ToArray();
		foreach (var point in points) {
			Points[point] -= Time.deltaTime;
			if (!point.activeSelf && Points[point] <= 0) {
				SpawnCriticalPoint(point);
				break;
			}
		}
	}
	GameObject SpawnCriticalPoint(GameObject CriticalPoint) {
		var DownLeft = Monster.Global.renderer.bounds.min * 0.75f;
		var UpperRight  = Monster.Global.renderer.bounds.max * 0.75f;

		int i = 0;
		while (i < 2) {
			i++;

			var RandomPos = new Vector2 (Random.Range (DownLeft.x, UpperRight.x), Random.Range (DownLeft.y, UpperRight.y));

			bool TooClose = false;

			foreach (var point in LevelController.Global.Points.Keys) {
				if (point.activeSelf && Vector2.Distance (point.transform.position, RandomPos) < MinimumCriticalPointDistance) {
					TooClose = true;
					break;
				}
			}

			if (TooClose) {
				Debug.Log("Too close");
				continue;
			}
				

			CriticalPoint.transform.position = new Vector3(RandomPos.x , RandomPos.y, -1);
			CriticalPoint.SetActive(true);
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
