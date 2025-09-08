using UnityEngine;
// using UnityEngine.EventSystems;

public class BumperScript : MonoBehaviour
{

    private Vector3 startsize;
    private Vector3 smallsize;
    // Start is called before the first frame update

    private void Awake() {
        startsize = transform.localScale;
        smallsize = new Vector3(startsize.x/10, startsize.y/10, 1);
    }

    private void OnEnable() {
        transform.localScale = smallsize;        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < startsize.x) {
            transform.localScale = new Vector3(transform.localScale.x + 0.009f, transform.localScale.y + 0.009f, 1f );
        }
        
    }
}
