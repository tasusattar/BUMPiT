using GoogleMobileAds.Api;
using System;
using UnityEngine;

public static class AdMan 
{
    private static bool adson = AdsOnSetting();
    public static int nextIntAd = 4;
    public static bool intaddisplay = false;
    public static int nextBanAd = 2;

    public static BannerView bannerView;
    public static InterstitialAd interstitial;
    public static RewardedAd rewardedAd;

    private static GameObject intAdPanel; 

    public static bool GetAdsOn(){return adson;}

    public static bool GetDisplayBool(){return intaddisplay;}
    public static void SetDisplayBool(bool yon){intaddisplay = yon;}

    private static bool AdsOnSetting(){
        if(PlayerPrefs.HasKey("Ads")){
            if (PlayerPrefs.GetInt("Ads") == 0){return false;}
        }
        return true;
    }
    public static void TurnOffAds(){adson = false; PlayerPrefs.SetInt("Ads", 0); PlayerPrefs.Save(); bannerView.Destroy(); interstitial.Destroy(); rewardedAd.Destroy();}
    
    public static void SetIntAdPanel(GameObject ipan){intAdPanel = ipan;}

    public static void LoadAdType(int typei){
        if(!adson) return;
        if(typei == 0) bannerView.LoadAd(new AdRequest.Builder().Build()); bannerView.Hide();
        if(typei == 1) interstitial.LoadAd(new AdRequest.Builder().Build());
        if(typei == 2) rewardedAd.LoadAd(new AdRequest.Builder().Build());
    }

    public static void ShowAdType(int typei){
        if(!adson) return;
        if(typei == 0) bannerView.Show();
        if(typei == 1 && interstitial.IsLoaded()) interstitial.Show();
        if(typei == 2 && rewardedAd.IsLoaded()) rewardedAd.Show();
    }

    public static void HideBanner(){
        if(bannerView != null) bannerView.Hide();
        }


    public static bool CheckForAds(){
        if (!adson){return false;}
        nextIntAd -= 1;
        nextBanAd -=1;
        if(nextBanAd < 1) {
            nextBanAd = 2;
            
            // CreateAdRequest(0);
        }
        if(nextIntAd < 1) {
            nextIntAd = 6;
            // CreateAdRequest(1);
            return true;
            }
        return false;
    }

    public static void StartAdMan(){
        MobileAds.Initialize(initStatus => { });

        InitializeAds();

        LoadAdType(0);

        // CreateAdRequest(0);
    }

    
    public static void InitializeAds(){
        if(!adson) return;

        string bannerUnitId = "";
        string interUnitId = "";
        string rewardUnitId = "";


        // Production
        #if UNITY_ANDROID
            bannerUnitId = "ca-app-pub-5567577973859661/5758186305";
        #elif UNITY_IPHONE
            bannerUnitId = "ca-app-pub-5567577973859661/7864942062";
        #else
            bannerUnitId = "unexpected_platform";
        #endif

        // Testing
        // #if UNITY_ANDROID
        //     bannerUnitId = "ca-app-pub-3940256099942544/6300978111";
        // #elif UNITY_IPHONE
        //     bannerUnitId = "ca-app-pub-3940256099942544/6300978111";
        // #else
        //     bannerUnitId = "unexpected_platform";
        // #endif
        

        if(bannerView!=null) {bannerView.Destroy();}
        var asize = (ScreenProperties.GetAspectRatio() > 0.65) ? AdSize.Leaderboard : AdSize.Banner;
        // Create a banner at the top of the screen.
        bannerView = new BannerView(bannerUnitId, asize, AdPosition.Top);
       // Called when an ad request has successfully loaded.
        bannerView.OnAdLoaded += HandleOnAdLoaded;
            // Called when an ad request failed to load.
        bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
        bannerView.OnAdOpening += HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
        bannerView.OnAdClosed += HandleOnAdClosed;



        // PRODUCTION
        #if UNITY_ANDROID
                interUnitId = "ca-app-pub-5567577973859661/6146071253";
            #elif UNITY_IPHONE
                interUnitId = "ca-app-pub-5567577973859661/2945192841";
            #else
                interUnitId = "unexpected_platform";
            #endif
        
        // TESTING
        // #if UNITY_ANDROID
        //         interUnitId = "ca-app-pub-3940256099942544/1033173712";
        // #elif UNITY_IPHONE
        //     interUnitId = "ca-app-pub-3940256099942544/1033173712";
        // #else
        //     interUnitId = "unexpected_platform";
        // #endif
        
            if(interstitial!=null) {interstitial.Destroy();}

            interstitial = new InterstitialAd(interUnitId);

            // Called when an ad request has successfully loaded.
            interstitial.OnAdLoaded += HandleOnIntAdLoaded;
            // Called when an ad request failed to load.
            interstitial.OnAdFailedToLoad += HandleOnIntAdFailedToLoad;
            // Called when an ad is shown.
            interstitial.OnAdOpening += HandleOnIntAdOpening;
            // Called when the ad is closed.
            interstitial.OnAdClosed += HandleOnIntAdClosed;


        // PRODUCTION
        #if UNITY_ANDROID
                rewardUnitId = "ca-app-pub-5567577973859661/5954499565";
            #elif UNITY_IPHONE
                rewardUnitId = "ca-app-pub-5567577973859661/3551697502";
            #else
                rewardUnitId = "unexpected_platform";
            #endif
        // TESTING    
        // #if UNITY_ANDROID
        //         rewardUnitId = "ca-app-pub-3940256099942544/5224354917";
        //     #elif UNITY_IPHONE
        //         rewardUnitId = "ca-app-pub-3940256099942544/5224354917";
        //     #else
        //         rewardUnitId = "unexpected_platform";
        //     #endif

            rewardedAd = new RewardedAd(rewardUnitId);

            // Called when an ad request has successfully loaded.
            rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
            // Called when an ad request failed to load.
            rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
            // Called when an ad is shown.
            rewardedAd.OnAdOpening += HandleRewardedAdOpening;
            // Called when an ad request failed to show.
            rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
            // Called when the user should be rewarded for interacting with the ad.
            rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
            // Called when the ad is closed.
            rewardedAd.OnAdClosed += HandleRewardedAdClosed;



    }

// --------------------------------------------------------------------------------
// BANNER HANDLERS
private static void HandleOnAdLoaded(object sender, EventArgs args)
    {
    //    Debug.Log("HandleAdLoaded event received");
    }

private static void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        // Debug.Log("HandleFailedToReceiveAd event received with message: "
        //                     + args.LoadAdError.GetMessage());
        bannerView.Destroy();
        // CreateAdRequest(0);
    }

private static void HandleOnAdOpened(object sender, EventArgs args)
    {
        // Debug.Log("HandleAdOpened event received");
    }

private static void HandleOnAdClosed(object sender, EventArgs args)
    {
        // Debug.Log("HandleAdClosed event received");
    }


// --------------------------------------------------------------------------------
// INTERSTITIAL AD HANDLERS
private static void HandleOnIntAdLoaded(object sender, EventArgs args)
{
    // MonoBehaviour.print("HandleAdLoaded event received");
    // iadReady = true;
}

private static void HandleOnIntAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
{
    // MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
    //                     + args.Message);
    // iadReady = false;
    interstitial.Destroy();
    // CreateAdRequest(1);
    if(intAdPanel != null) intAdPanel.SetActive(true);
}

private static void HandleOnIntAdOpening(object sender, EventArgs args)
{

    // MonoBehaviour.print("HandleAdOpening event received");
    if(intAdPanel != null) intAdPanel.SetActive(false);
}

private static void HandleOnIntAdClosed(object sender, EventArgs args)
{
    // MonoBehaviour.print("HandleAdClosed event received");
    interstitial.Destroy();
    if(intAdPanel != null) intAdPanel.SetActive(false);
    // CreateAdRequest(1);
}



// --------------------------------------------------------------------------------
// REWARDED AD HANDLERS
    private static void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        // radReady = true;
        // MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    private static void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        // radReady = false;
        // rewardedAd.Destroy();
        // MonoBehaviour.print(
        //     "HandleRewardedAdFailedToLoad event received with message: "
        //                      + args.Message);
    }

    private static void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        // MonoBehaviour.print("HandleRewardedAdOpening event received");
        GameSys.OpenScene(1);
    }

    private static void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        // MonoBehaviour.print(
        //     "HandleRewardedAdFailedToShow event received with message: "
        //                      + args.Message);
        GameSys.OpenScene(1);
        rewardedAd.Destroy();
        // CreateAdRequest(2);
    }

    private static void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        // MonoBehaviour.print("HandleRewardedAdClosed event received");
        
        rewardedAd.Destroy();
        // CreateAdRequest(2);
    }

    private static void HandleUserEarnedReward(object sender, Reward args)
    {

        GameMan.LifeUp(true);
        
        // string type = args.Type;
        // double amount = args.Amount;
        // Debug.Log();(
        //     "HandleRewardedAdRewarded event received for "
        //                 + amount.ToString() + " " + type);
    }


}
