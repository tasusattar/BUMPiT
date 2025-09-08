using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameSys
{
    private static int highscore = 0;
    private static int highround = 0;
    private static int startingBarrier = 0;
    private static int barriermax = 0;

    private static bool music = true;
    private static bool tutorial = true;

    private static System.Random randomizer = new System.Random();

   public static int bgnum = 0; 

    public static void OpenScene(int scenenum){
        SceneManager.LoadScene(scenenum);
    }

    public static int GetRandomInt(int minIn, int maxEx){
        return randomizer.Next(minIn, maxEx);
    }
    public static int GetStartingBarrier(){return startingBarrier;}

    public static int GetMaxBarrier(){return barriermax;}
    public static int GetHighScore(){return highscore;}
    public static int GetBestRound(){return highround;}

    public static bool GetMusic(){return music;}
    public static bool GetTutorial(){return tutorial;}

    public static void CheckNewBest(){
        if (GameMan.GetScore() > highscore){
            highscore = GameMan.GetScore();
            highround = GameMan.GetRound();
        }
        PlayerPrefs.SetInt("HighScore", highscore);
        PlayerPrefs.SetInt("BestRound", highround);
        PlayerPrefs.Save();
    }

    public static void CheckNewMaxBarrier(int newbarr){
        barriermax = (newbarr > barriermax) ? newbarr : barriermax;
        PlayerPrefs.SetInt("MaxBarrier", barriermax);
        PlayerPrefs.Save();
    }

    public static void SetMusic(bool swish){
        music=swish;
        }
    public static void SetTutorial(bool swish){
        tutorial=swish;
        }

    public static void SetNewStartingBarrier(int numbar){
        startingBarrier = (numbar > barriermax) ? barriermax : numbar;
    }

    public static void SaveSettings(){
        int musicbinary = (music) ? 1:0;
        int tutbinary = (tutorial) ? 1:0;
        PlayerPrefs.SetInt("Music",musicbinary); 
        PlayerPrefs.SetInt("Tutorial",tutbinary);

        PlayerPrefs.SetInt("StartBar", startingBarrier);

        PlayerPrefs.Save();
    }

    public static void GrabSavedSettings(){
        try{
            if(!PlayerPrefs.HasKey("StartBar")){Debug.Log("lo");return;};
            highscore = PlayerPrefs.GetInt("HighScore");
            highround = PlayerPrefs.GetInt("BestRound");
            startingBarrier = PlayerPrefs.GetInt("StartBar");
            barriermax = PlayerPrefs.GetInt("MaxBarrier");

            int mbinary = PlayerPrefs.GetInt("Music");
            int sbinary = PlayerPrefs.GetInt("SFX");
            int tbinary = PlayerPrefs.GetInt("Tutorial");
            music = (mbinary==1) ? true : false;
            tutorial = (tbinary==1) ? true : false;
        }
        catch {
            Debug.Log("Prothom ashco naki?");
        }
        
    }

    public static void MuteUnMute(){
        AudioSource[] allAuds = GameObject.FindObjectsOfType<AudioSource>(true);
        foreach (var auds in allAuds){
            auds.mute = !music;
        }
    }

    private static int[] badges = {LoadBadge(0), LoadBadge(1), LoadBadge(2), LoadBadge(3), LoadBadge(4)};

    public static void AddBadge(int i){
        badges[i]++;
        PlayerPrefs.SetInt("Badge"+i.ToString(), badges[i]);
        PlayerPrefs.Save();
         }
    private static int LoadBadge(int i){return PlayerPrefs.GetInt("Badge" + i.ToString(), 0);}
    public static int GetBadge(int i){return badges[i];}


}
