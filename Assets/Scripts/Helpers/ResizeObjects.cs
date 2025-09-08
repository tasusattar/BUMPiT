using UnityEngine;

public class ResizeObjects : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Start is called before the first frame update
    void Start()
    {
        // mainCam = Camera.main;
        // Transform goTran = gameObject.transform;
        // oldWidth = 2.25f;
        // oldHeight = 5f;

         
        
        // aspectRatio = mainCam.aspect;

        // float sizeMultiplier = (20f/9f)*aspectRatio;
        // if(gameObject.name == "TWall" || gameObject.name == "BWall"){goTran.localScale /= sizeMultiplier;}
        // else{goTran.localScale *= sizeMultiplier;}

        // goTran.localScale *= (gameObject.name == "TWall" || gameObject.name == "BWall") ? sizeMultiplier : sizeMultiplier;
        
        
        // float newWidth = 5 * aspectRatio * sizeMultiplier;
        
        // float xMultiplier = newWidth/oldWidth;
        // float yMultiplier = (5*sizeMultiplier)/oldHeight;

        

        // goTran.localScale *= (gameObject.name == "TWall" || gameObject.name == "BWall") ? xMultiplier : sizeMultiplier;
        transform.localScale *= (gameObject.name == "TWall" || gameObject.name == "BWall") ? ScreenProperties.GetXMult() : ScreenProperties.GetSizeMult();

        // if (gameObject.name == "TWall" || gameObject.name == "BWall") {transform.localScale *= ScreenProperties.GetXMult(); return;}
        // if (gameObject.name == "LWall" || gameObject.name == "RWall") {transform.localScale *= ScreenProperties.GetYMult(); return;}

        // transform.localScale = new Vector3(transform.localScale.x + (2*ScreenProperties.GetXDiff()), transform.localScale.y + (2*ScreenProperties.GetYDiff()), 1);



    }

}
