using UnityEngine;
using UnityEngine.Advertisements;

public class ShowingSkipVideo : MonoBehaviour
{
    public void ShowSkipVideo()
    {
        if (Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
    }
    public void ShowRewardedVideo()
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }

    }
}
