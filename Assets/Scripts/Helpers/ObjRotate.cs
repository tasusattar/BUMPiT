using UnityEngine;

public class ObjRotate : MonoBehaviour
{

    private LevelManager lvlMan;
    [SerializeField] float rotateAmount;
    // Start is called before the first frame update
    [SerializeField] bool flip;

    private Rigidbody2D flipRB;
    void Start()
    {   
        lvlMan = GameObject.FindGameObjectWithTag("LMan").GetComponent<LevelManager>();
        if (flip){
            flipRB = GetComponent<Rigidbody2D>();
        } 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!lvlMan.GetShot()){ return; }
        if (flip){
            flipRB.MoveRotation(flipRB.rotation + rotateAmount*Time.deltaTime*2);
            return;
        } 
        gameObject.transform.Rotate(new Vector3(0f, 0f, rotateAmount*Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (flip){
            rotateAmount*=-1;
        }    
    }
}
