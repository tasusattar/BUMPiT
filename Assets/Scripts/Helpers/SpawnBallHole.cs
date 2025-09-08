using UnityEngine;

public class SpawnBallHole : MonoBehaviour
{
    [SerializeField] Transform[] spots;
    [SerializeField] GameObject ballFab;
    [SerializeField] GameObject holeFab;

    [SerializeField] bool redolvl;

    // private System.Random randomizer = new System.Random();

    // Start is called before the first frame update
    void Start()
    {   
        if(!redolvl){
            int[] ballHole = {0,0};
            int randi = GameSys.GetRandomInt(0,2);
            int topRandom = GameSys.GetRandomInt(1,3);

            ballHole[randi] = topRandom;
        
            GameMan.gbhp = ballHole;

        }

        GameObject ball = Instantiate(ballFab, spots[GameMan.gbhp[0]].position, Quaternion.identity);
        ball.transform.SetParent(transform);
        GameObject hole = Instantiate(holeFab, spots[GameMan.gbhp[1]].position, Quaternion.identity);
        hole.transform.SetParent(transform);
            
    }    
    
}

