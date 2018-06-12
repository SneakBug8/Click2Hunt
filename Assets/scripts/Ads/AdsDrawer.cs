using UnityEngine;
#if UNITY_ANDROID
using UnityEngine.Advertisements;
#endif
public class AdsDrawer : MonoBehaviour
{
    float timer;

    public GameObject[] ActivateAfterShown;
    bool Shown = false;

    private void Start() {
        timer = 1f;

    }

    void Update() {
        timer -= Time.deltaTime;

        #if UNITY_ANDROID
        if ((timer <= 0 && !Shown) || !Config.ShowAds) {
        #endif
            foreach (var obj in ActivateAfterShown) {
                obj.SetActive(true);
            }
            Shown = true;
        #if UNITY_ANDROID
        }
        #endif

        #if UNITY_ANDROID
        if (timer <= 0 && Advertisement.IsReady() && Config.ShowAds) {
            Advertisement.Show();
            timer = 60f;
        }
        #endif
    }
}
