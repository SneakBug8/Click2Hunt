using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsDrawer : MonoBehaviour
{
    private void OnEnable()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
}
