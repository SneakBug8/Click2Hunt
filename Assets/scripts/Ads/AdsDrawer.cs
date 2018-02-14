using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsDrawer : MonoBehaviour
{
    float timer = 1f;

    void Update() {
        timer -= Time.deltaTime;

        if (timer <= 0 && Advertisement.IsReady()) {
            Advertisement.Show();
            timer = 10f;
        }
    }
}
