using UnityEngine;

public class ResizeCamera : MonoBehaviour
{

    private Camera mainCam;
    private float size;

    private float aspectRatio;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        float size = mainCam.orthographicSize;
        aspectRatio = mainCam.aspect;
        float sizeMultiplier = (20f/9f)*aspectRatio;
        mainCam.orthographicSize = size*sizeMultiplier;
    }

}
