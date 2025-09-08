using UnityEngine;


public class SpeedsterScript : MonoBehaviour
{
    [SerializeField] Sprite state1;
    [SerializeField] Sprite state2;
    private bool statecheck;
    private float checktimer;
    private SpriteRenderer srender;
    // Start is called before the first frame update
    void Start()
    {
        srender = GetComponent<SpriteRenderer>();
        statecheck = true;
        checktimer = 0.75f;
        
    }

    // Update is called once per frame
    void Update()
    {
        srender.sprite = (statecheck) ? state1 : state2;
        checktimer -= Time.deltaTime;
        if (checktimer < 0f){
            statecheck = !statecheck;
            checktimer=0.75f;
        }
        
        
    }

}
