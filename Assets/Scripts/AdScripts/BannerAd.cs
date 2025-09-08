using UnityEngine;

public class BannerAd : MonoBehaviour
{
 
    // private BannerView bannerView;
    void Start()
    {
        // AdMan.ShowBanner();
        // AdMan.bannerView.LoadAd(AdMan.NewRequest());
        
        // AdMan.bannerView.Show();
        if(!AdMan.GetAdsOn()) Destroy(gameObject);
        // AdMan.LoadAdType(0);
        // AdMan.ShowAdType(0);

    }

    private void OnEnable() {
        if(AdMan.bannerView != null) AdMan.ShowAdType(0);
    }

    private void OnDisable() {
        Debug.Log("disabled");
        AdMan.HideBanner();
    }
    // private void OnDestroy() {
    //     Debug.Log("DESTROYED");
    //     AdMan.bannerView.Destroy();

    // }
}
