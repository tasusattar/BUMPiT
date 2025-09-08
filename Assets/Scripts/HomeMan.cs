using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HomeMan : MonoBehaviour
{
    [SerializeField] Slider startBarSlide;
    [SerializeField] TextMeshProUGUI startBarInput;
    [SerializeField] Toggle musicTog;
    [SerializeField] Toggle tutTog;

    [SerializeField] GameObject bestScoreSign;
    [SerializeField] GameObject continueSign;

    // [SerializeField] GameObject bannerAd;

    [SerializeField] GameObject adBtn;

    [SerializeField] TextMeshProUGUI[] badgeTexts;


    private void Awake() {
        ScreenProperties.SetAllScreenProps(Camera.main.aspect);
        GameSys.MuteUnMute();
        if(AdMan.GetAdsOn()){AdMan.StartAdMan();}
        else{Destroy(adBtn);}
        
    }

    // Start is called before the first frame update
    void Start()
    {   
        GameSys.GrabSavedSettings();
        GameMan.GrabLastGame();
        Time.timeScale = 1f;

        if(AdMan.GetAdsOn() && AdMan.bannerView != null){AdMan.ShowAdType(0);}
        // if(AdMan.GetAdsOn() && AdMan.bannerView != null){AdMan.LoadAdType(0);}

        ShowBest();
        ShowContinue();
        SetBadgeNums();

        

        // Settings menu start
        startBarSlide.maxValue=GameSys.GetMaxBarrier();
        startBarSlide.value = GameSys.GetStartingBarrier();
        startBarSlide.onValueChanged.AddListener(delegate {
            SetStartBarr((int)startBarSlide.value);
        });

        startBarInput.text = GameSys.GetStartingBarrier().ToString();
        

        musicTog.onValueChanged.AddListener(delegate {
            GameSys.SetMusic(musicTog.isOn);
            GameSys.MuteUnMute();
        });

        tutTog.onValueChanged.AddListener(delegate {
            GameSys.SetTutorial(tutTog.isOn);
        });

        musicTog.isOn=GameSys.GetMusic();
        tutTog.isOn=GameSys.GetTutorial();



    }

    public void SettingsClosed(){
        GameSys.SaveSettings();
    }

    public void SetStartBarr(int barrs){
        int startbarrs = (barrs > GameSys.GetMaxBarrier()) ? GameSys.GetMaxBarrier() : barrs;
        startbarrs = (barrs < 0) ? 0 : startbarrs;
        GameSys.SetNewStartingBarrier(startbarrs);
        startBarSlide.value=GameSys.GetStartingBarrier();
        startBarInput.text=GameSys.GetStartingBarrier().ToString();

    }

    public void BarrUpDown(bool upordown){
        if (upordown){SetStartBarr(GameSys.GetStartingBarrier()+1);}
        else{SetStartBarr(GameSys.GetStartingBarrier()-1);}
    }

    public void RemoveAds(){
        AdMan.HideBanner();
        AdMan.TurnOffAds();
        // Destroy(bannerAd);
        Destroy(adBtn);
    }

    private void ShowBest(){
        bestScoreSign.GetComponentsInChildren<TextMeshProUGUI>()[0].text = GameSys.GetHighScore().ToString();
        bestScoreSign.GetComponentsInChildren<TextMeshProUGUI>()[1].text = GameSys.GetBestRound().ToString();
        if (GameSys.GetHighScore()>0){
            bestScoreSign.SetActive(true);
        }
    }
    private void ShowContinue(){
        if (GameMan.GetLives()>0 && GameMan.GetRound()>1){
            continueSign.SetActive(true);
        }
        else{
            continueSign.SetActive(false);
        }
    }

    private void SetBadgeNums(){
        for (int i = 0; i < badgeTexts.Length; i++){
            badgeTexts[i].text = GameSys.GetBadge(i).ToString();
        }
    }


}
