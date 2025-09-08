using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject LosePanel;

    [SerializeField] GameObject GamePanel;
    [SerializeField] GameObject AllSpawns;

    [SerializeField] Transform PlusPointLocation;
    [SerializeField] GameObject PlusPointTextObj;

    [SerializeField] Button PauseBtn;

    [SerializeField] GameObject LifeToken;

    [SerializeField] AudioClip[] allBGMusic;

    [SerializeField] GameObject intAdPanel;
    [SerializeField] GameObject BannerAdObj;

    // private GameObject banadob;

    public bool tutorialLevel;

    private int bgMusicChoice;
    private AudioSource audSauce;
    private int wallroundpoints;
    private int barroundpoints;
    private bool shotsfired;
    private TextMeshProUGUI pptxt;    



    private void Awake() {
        ScreenProperties.SetAllScreenProps(Camera.main.aspect);    
        bgMusicChoice = GameSys.GetRandomInt(0, allBGMusic.Length);
        
        if(AdMan.bannerView == null || AdMan.interstitial == null || AdMan.rewardedAd == null) AdMan.InitializeAds();
        // BannerAdObj.SetActive(false);
        
    }

    private void OnApplicationPause(bool pauseStatus) {
        if (pauseStatus && !WinPanel.activeSelf && !LosePanel.activeSelf) {
            PauseBtn.onClick.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameSys.MuteUnMute();   
        shotsfired = false;
        wallroundpoints = 0;
        barroundpoints = 50+(25*GameMan.GetNumBarriers());
        pptxt = PlusPointTextObj.GetComponent<TextMeshProUGUI>();
        CheckForLife();
        audSauce = GetComponent<AudioSource>();
        audSauce.clip = allBGMusic[bgMusicChoice];
        audSauce.loop = true;
        audSauce.Play();

        // if(AdMan.nextIntAd == 1) AdMan.LoadAdType(1);
        if(GameMan.GetRound()%7 == 6) AdMan.LoadAdType(2);
        if(GameMan.GetRound()%2 == 0) AdMan.LoadAdType(0);

        if(AdMan.GetAdsOn()) AdMan.HideBanner();

        // if(AdMan.GetAdsOn()) { banadob = Instantiate(BannerAdObj); banadob.SetActive(false);}

    }

    public void Shoot(){shotsfired = true;}
    public bool GetShot(){return shotsfired;}
    public void RoundWon(){
        GameMan.RoundComplete();
        // GamePanel.SetActive(false);
        Destroy(GamePanel);
        WinPanel.SetActive(true);
        // AllSpawns.SetActive(false);
        Destroy(AllSpawns);
        if(AdMan.GetAdsOn() && !tutorialLevel){BannerAdObj.SetActive(true);}

        Adpanel();
    }

    public void LoseRound(){
        // GamePanel.SetActive(false);
        Destroy(GamePanel);
        GameMan.RoundLost(LosePanel);
        // AllSpawns.SetActive(false);
        Destroy(AllSpawns);

        if(AdMan.GetAdsOn() && !tutorialLevel){BannerAdObj.SetActive(true);}

        
        Adpanel();
        
    }

    private void Adpanel(){
        // if(AdMan.CheckForAds()){
        //     intAdPanel.SetActive(true);
        //     AdMan.SetIntAdPanel(intAdPanel);    
        //     // AdMan.ShowInterstitial();

        // }
        if(AdMan.GetDisplayBool()){
            intAdPanel.SetActive(true);
            AdMan.SetIntAdPanel(intAdPanel);
            AdMan.SetDisplayBool(false);    
            // AdMan.ShowInterstitial();
        }
    }

    public void AddWallRoundPoints(bool wallbroken){
        int points = (wallbroken) ? 40 : 20;
        wallroundpoints+=points;

        // Animate Round Points Added
        pptxt.text = "+ " + points.ToString();
        GameObject txtgo = Instantiate(PlusPointTextObj, PlusPointLocation.transform.position, Quaternion.identity);
        txtgo.transform.SetParent(PlusPointLocation);

        GameMan.AddWallScore(wallbroken);
        }
    public int GetWallRoundPoints(){return wallroundpoints;}
    public int GetBarRoundPoints(){return barroundpoints;}

    private void CheckForLife(){
        if (GameMan.GetTillNextLife() < 1) {
            LifeToken.SetActive(true);
            GameMan.ResetLifeToken();
            AdMan.LoadAdType(1);
            AdMan.SetDisplayBool(true);
        }
    }

    
    public void pauseBanner(bool onoff){
        if (!AdMan.GetAdsOn()) return;
        // banadob.SetActive(onoff);
    }

}
