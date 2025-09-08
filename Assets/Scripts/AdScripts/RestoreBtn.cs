using UnityEngine;

public class RestoreBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        # if UNITY_ANDROID
            Destroy(gameObject);
        #endif

    }

}
