// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class RedoStockScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var stoc = GameMan.GetRedoStock();
        var stocP = GameMan.GetRedoPos();
        var stocR = GameMan.GetRedoRot();

        try{
            if(stoc.Count == stocP.Count && stoc.Count == stocR.Count){
                for (int i = 0; i<stoc.Count; i++){
                    var go = Instantiate(stoc[i], stocP[i], stocR[i]);
                    go.transform.SetParent(transform);
                }       
            }
        } catch{}
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
