using System.Collections.Generic;
using UnityEngine;

public static class GameMan 
{

    private static int score = 0;
    private static int lscore = 0;
    private static int round = 1;
    private static int lives = 1;
    private static int nextlifetoken = 1;
    private static int barriers = 0;
    private static int nextbarrier = 2;

    // public static Vector3 gbp = new Vector3();
    // public static Vector3 ghp = new Vector3();

    public static int[] gbhp = {0, 1};
    private static List<GameObject> redostock = new List<GameObject>();
    private static List<Vector3> redopos = new List<Vector3>();
    private static List<Quaternion> redorot = new List<Quaternion>();


    public static List<GameObject> GetRedoStock(){return redostock;}
    public static List<Vector3> GetRedoPos(){return redopos;}
    public static List<Quaternion> GetRedoRot(){return redorot;}

    public static void AddToRedo(GameObject ob, Vector3 pos, Quaternion rot){
        redostock.Add(ob);
        redopos.Add(pos);
        redorot.Add(rot);
        }

    public static void ClearRedoStock(){
        if(redostock != null){
        redostock.Clear(); redopos.Clear(); redorot.Clear();
        }
    }



    public static void FreshStart(){
        score = 0;
        lscore = 0;
        round = 1;
        lives = 1;
        nextlifetoken = 1;
        barriers = GameSys.GetStartingBarrier();
        CheckBarrierIncrement();
        SaveGame();
    }

    public static void SaveGame(){
        PlayerPrefs.SetInt("Score", lscore);
        PlayerPrefs.SetInt("Round", round);
        PlayerPrefs.SetInt("Lives", lives);
        PlayerPrefs.SetInt("Barriers", barriers);
        PlayerPrefs.SetInt("NextBarrier", nextbarrier);
        PlayerPrefs.SetInt("NextLife", nextlifetoken);
        PlayerPrefs.Save();
    }

    public static void GrabLastGame(){
        try{
        if(!PlayerPrefs.HasKey("Score")){Debug.Log("so");return;};
        score = PlayerPrefs.GetInt("Score");
        lscore = score;
        round = PlayerPrefs.GetInt("Round");
        lives = PlayerPrefs.GetInt("Lives");
        barriers = PlayerPrefs.GetInt("Barriers");
        nextbarrier = PlayerPrefs.GetInt("NextBarrier");
        nextlifetoken = PlayerPrefs.GetInt("NextLife");
        }
        catch{
            Debug.Log("First Time, eh?");
        }
    }

    public static void RoundComplete(){
        AddRoundScore();
        ++round;
        --nextbarrier;
        if(nextbarrier==0){
            ++barriers;
            CheckBarrierIncrement();
            GameSys.CheckNewMaxBarrier(barriers);       
        }

        --nextlifetoken;
        

        SaveGame();

    }

    public static void RoundLost(GameObject lpanel){
        Debug.Log(lives);
        LifeUp(false);
        --nextlifetoken;
        if (lives<1){
            GameSys.CheckNewBest();
            lscore = score;
            SaveGame();
            GameSys.OpenScene(2);
            return;
        }
        lpanel.SetActive(true);
        GameSys.CheckNewBest();
        SaveGame();
    }

    public static void RoundRetry(){
        score = lscore;
    }



    public static void LifeUp(bool upordown){
        lives = (upordown) ? lives+1 : lives-1;
    }

    public static void AddWallScore(bool wallbroken){
        score = (wallbroken) ? score+40 : score+20;
    }

    public static void AddRoundScore(){
        score += 50+(25*barriers);
        lscore = score;
    }

    public static void ResetLifeToken(){nextlifetoken=6;}

// PUBLIC GETTERS
    public static int GetScore(){
        return score;
    }

    public static int GetRound(){
        return round;
    }

    public static int GetLives(){
        return lives;
    }

    public static int GetNumBarriers(){
        return barriers;
    }

    public static int GetTillNextBarr(){
        return nextbarrier;
    }
    public static int GetTillNextLife(){
        return nextlifetoken;
    }

// PRIVATE METHODS
    private static void CheckBarrierIncrement(){
        if(barriers>11){
            barriers=12;
            nextbarrier=100;
        }
        else if (barriers < 2) {
            nextbarrier = 2;
        } 
        else if (barriers < 4){ 
            nextbarrier = 4;
        }
        else if (barriers < 7){
            nextbarrier = 6;
        }
        else if(barriers<9){nextbarrier=8;}
        else if(barriers<12){nextbarrier=10;}

    }

    

 
}
