using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class Initialize : MonoBehaviour {

	public static bool IsInitialized = false;

	// Use this for initialization
	void Start () {
		if (!IsInitialized) {
			string appKey = "efdb8c008ba81f7bcf83617dbb58452ff42ee16831f3a697";
			Appodeal.disableLocationPermissionCheck ();
			Appodeal.initialize (appKey, Appodeal.INTERSTITIAL | Appodeal.NON_SKIPPABLE_VIDEO);
			Debug.Log ("Initialized AppoDeal");
		}
	}
}
