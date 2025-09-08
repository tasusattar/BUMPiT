using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdScene : MonoBehaviour
{

    [SerializeField] GameObject[] Panels;
    [SerializeField] Button adBtn;
    [SerializeField] TextMeshProUGUI btnTxt;

    // Start is called before the first frame update
    void Start()
    {
        if(!AdMan.GetAdsOn()){
            Panels[0].SetActive(true); 
            Panels[1].SetActive(false);
        }
        else {
            Panels[0].SetActive(false); 
            Panels[1].SetActive(true);
            // AdMan.rewardedAd.LoadAd(AdMan.NewRequest());
        }
        
    }
    private void OnEnable() {
        if(!AdMan.GetAdsOn()){
            Panels[0].SetActive(true); 
            Panels[1].SetActive(false);
        }
        else {
            Panels[0].SetActive(false); 
            Panels[1].SetActive(true);
            // AdMan.rewardedAd.LoadAd(AdMan.NewRequest());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!AdMan.GetAdsOn()) return;
        if (AdMan.rewardedAd.IsLoaded()){
            adBtn.enabled = true;
            adBtn.interactable = true;
            // bool isSet = (btnTxt.fontStyle & FontStyles.Strikethrough) != 0;
            btnTxt.fontStyle = FontStyles.Bold;
        }
        else{
            adBtn.enabled = false;
            adBtn.interactable = false;
            btnTxt.fontStyle = FontStyles.Strikethrough;
        }
    }

    public void Thanks(){
        GameMan.LifeUp(true);
        GameSys.OpenScene(1);
    }

    public void WatchAdForLife(){
        // Call Rewarded Ad
        // OnCloseExitToGame
        AdMan.rewardedAd.Show();
        Panels[2].SetActive(false);

    }

    public void RemoveAd(){
        // Remove Ads IAP
        AdMan.TurnOffAds();
        AdMan.rewardedAd.Destroy();
    }

    public void NoThanks(){
        AdMan.rewardedAd.Destroy();
        GameSys.OpenScene(1);
    }



}
