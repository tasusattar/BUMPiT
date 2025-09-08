using UnityEngine;
using TMPro;

public class ScoreBoardScript : MonoBehaviour
{   
    private TextMeshProUGUI[] allChildComps;
    // Start is called before the first frame update
    void Start()
    {
        allChildComps = gameObject.GetComponentsInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        allChildComps[0].text = GameMan.GetScore().ToString();
        allChildComps[2].text = GameMan.GetRound().ToString();
        try{allChildComps[4].text = GameMan.GetLives().ToString();}catch{}
        
   
    }
}
