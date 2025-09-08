using System.Collections.Generic;
using UnityEngine;

public class BarrPositionsScript : MonoBehaviour
{
    [SerializeField] GameObject[] PositionRows;
    [SerializeField] GameObject BallBarr;

    private List<Transform>[] rowsListed = {
             new List<Transform>(),
             new List<Transform>(),
             new List<Transform>(),
             new List<Transform>(),
             new List<Transform>()
        };

    private int bariteration = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0; i < 5; i++){
            
            // Make a list all barrier spawn spots {i : List<GameObject>} 
            rowsListed[i].AddRange(PositionRows[i].GetComponentsInChildren<Transform>(true));
        }

        for (var j = 0; j < GameMan.GetNumBarriers(); j++){
            bariteration = j;
            ChooseRow();
        }
        
    }

    private void ChooseRow(){
        if (GameMan.GetNumBarriers() < 2){
            ChooseSpawnSpot(0);
        }
        else if (GameMan.GetNumBarriers() < 5){
            int randi = GameSys.GetRandomInt(0, 3);
            // int randi = Random.Range(0, 2);
            ChooseSpawnSpot(randi);
        }
        else
        {
            int randi = GameSys.GetRandomInt(0, 5);
            // int randi = Random.Range(0, 4);
            ChooseSpawnSpot(randi);
        }
    }

    private void ChooseSpawnSpot(int row){
        
        if (rowsListed[row].Count < 3 && bariteration < 10){ ChooseRow(); return;}
        else if (rowsListed[row].Count<2){ChooseRow(); return;}

        int whichSpot = GameSys.GetRandomInt(1, rowsListed[row].Count);
        Transform childSpot = rowsListed[row][whichSpot];
        rowsListed[row].RemoveAt(whichSpot);


        if(bariteration > 9){
            GameMan.AddToRedo(BallBarr, transform.position, Quaternion.identity);
            GameObject barr = Instantiate(BallBarr, childSpot.position, Quaternion.identity);
            barr.transform.SetParent(transform); 
            return;
            }
        childSpot.gameObject.SetActive(true);
        


    }
 
}
