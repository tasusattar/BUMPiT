using UnityEngine;

public class AdjustPosition : MonoBehaviour
{

    float newXPos;
    float newYPos;
    

    private RectTransform rectaltrans;

    private void Awake() {
        // newXPos = gameObject.transform.position.x*ScreenProperties.GetXMult();
        // newYPos = gameObject.transform.position.y*ScreenProperties.GetYMult();
                
        // gameObject.transform.position = new Vector3(newXPos, newYPos, gameObject.transform.position.z);
    }
    // Start is called before the first frame update
    void Start()
    {
        
        // rectaltrans = GetComponent<RectTransform>();
        
        // if (rectaltrans == null){
        //     newXPos = transform.position.x*ScreenProperties.GetXMult();
        //     newYPos = transform.position.y*ScreenProperties.GetYMult();
        //     // newXPos = SetNewPos(ScreenProperties.GetXDiff(), transform.position.x);
        //     // newYPos = SetNewPos(ScreenProperties.GetYDiff(), transform.position.y);            
        //     transform.position = new Vector3(newXPos, newYPos, transform.position.z);
        // }
        // else{
        //     float newXpo = rectaltrans.anchoredPosition.x*ScreenProperties.GetXMult();
        //     float newYpo = rectaltrans.anchoredPosition.y*ScreenProperties.GetYMult();
        
        //     rectaltrans.anchoredPosition = new Vector2(newXpo, newYpo);
        // }


        // rectaltrans = GetComponent<RectTransform>();

        // rectaltrans.sizeDelta *= ScreenProperties.GetSizeMult();

        newXPos = transform.position.x*ScreenProperties.GetXMult();
        newYPos = transform.position.y*ScreenProperties.GetYMult();
        //     // newXPos = SetNewPos(ScreenProperties.GetXDiff(), transform.position.x);
        //     // newYPos = SetNewPos(ScreenProperties.GetYDiff(), transform.position.y);            
        transform.position = new Vector3(newXPos, newYPos, transform.position.z);
        
    }

    
    private float SetNewPos(float diff, float pos){
        if(pos == 0f) {return 0f;}
        else if (pos<0) {return pos - diff;}
        return pos + diff;

    }

}
