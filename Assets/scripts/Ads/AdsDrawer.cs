using UnityEngine;
using UnityEngine.Advertisements;

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

        if (timer <= 0 && !Shown) {
            foreach (var obj in ActivateAfterShown) {
                obj.SetActive(true);
            }
            Shown = true;
        }

        if (timer <= 0 && Advertisement.IsReady()) {
            Advertisement.Show();
            timer = 60f;
        }
    }
}
