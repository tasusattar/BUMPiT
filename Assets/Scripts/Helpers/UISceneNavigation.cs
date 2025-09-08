using UnityEngine;

public class UISceneNavigation : MonoBehaviour
{
    public void NewGame(){
        GameMan.ClearRedoStock();
        GameMan.FreshStart();
        if (GameSys.GetTutorial()){GameSys.OpenScene(4);}
        else{GameSys.OpenScene(1);}
        
        
    }

    public void ContinueLast(){
        GameMan.ClearRedoStock();
        GameSys.OpenScene(1);
    }

    public void GoHome(){
        GameMan.RoundRetry();
        GameSys.OpenScene(0);
    }

    public void NextRound(){
        GameMan.ClearRedoStock();
        if(GameMan.GetRound()%7==0){
            GameSys.OpenScene(3);
            return;
        }

        GameSys.OpenScene(1);
        
    }

    public void RedoRound(){
        GameMan.RoundRetry();
        GameSys.OpenScene(5);
        
    }

}
