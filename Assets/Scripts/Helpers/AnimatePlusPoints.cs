using UnityEngine;

public class AnimatePlusPoints : MonoBehaviour
{   

    private float showtime;
    // Start is called before the first frame update
    void Start()
    {   
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        // gameObject.transform.position = new Vector3(-1.5f, -4.1f, 0f);

        showtime = 0.8f;
    }

    // Update is called once per frame
    void Update()
    {

        // Debug.Log(originalYPos);
        float yanimate = gameObject.transform.position.y + 0.004f;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, yanimate, 0f);
        
        showtime -= Time.deltaTime;
        if (showtime<0) {Destroy(gameObject);}
        
    }
}
