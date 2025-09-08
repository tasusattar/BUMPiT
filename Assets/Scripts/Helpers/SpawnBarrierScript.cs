using UnityEngine;

public class SpawnBarrierScript : MonoBehaviour
{
    [SerializeField] GameObject[] BarrierFabs;
    // Start is called before the first frame update
    void OnEnable()
    {

        int randi = GameSys.GetRandomInt(0, BarrierFabs.Length);
        try{GameObject barrChosen = BarrierFabs[randi];
            
            // GameObject barr1 = Instantiate(barrChosen, transform.position, Quaternion.Euler(0, 0, GameSys.GetRandomInt(0,360)));
            // barr1.transform.SetParent(GameObject.FindGameObjectWithTag("RedoStock").transform);
            
            GameMan.AddToRedo(barrChosen, transform.position, Quaternion.Euler(0, 0, GameSys.GetRandomInt(0,360)));
            GameObject barr = Instantiate(barrChosen, transform.position, Quaternion.Euler(0, 0, GameSys.GetRandomInt(0,360)));
            barr.transform.SetParent(transform);
        }
        catch{}

        

    }

}
