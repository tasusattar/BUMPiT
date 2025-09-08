using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        # if UNITY_IPHONE
            Destroy(gameObject);
        #endif

    }
}
