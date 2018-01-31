using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class ShowInterstitional : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
		Debug.Log ("Trying to show ads");
		if (Appodeal.isLoaded (Appodeal.INTERSTITIAL)) {
			Appodeal.show (Appodeal.INTERSTITIAL);
		} else if (Appodeal.isLoaded (Appodeal.NON_SKIPPABLE_VIDEO)) {
			Appodeal.show (Appodeal.NON_SKIPPABLE_VIDEO);
		}
	}
}
