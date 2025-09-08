using UnityEngine;

public class BallBarScript : MonoBehaviour
{
    // [SerializeField] LevelManager lvlMan;
    private Rigidbody2D ballRB;
    private float maxSpeed;
    private Vector2 velVector;

    private bool started;

    private LevelManager lvlMan;

    private Vector3 startpos;

    private void Awake() {
        startpos = transform.position;
    }


    // Start is called before the first frame update
    void Start()
    {
        lvlMan = GameObject.FindGameObjectWithTag("LMan").GetComponent<LevelManager>();
        started = false;
        ballRB = GetComponent<Rigidbody2D>();
        velVector = new Vector2(GameSys.GetRandomInt(-9, 9), GameSys.GetRandomInt(-9, 9));
        maxSpeed = 7f;

        // startpos = transform.position;
        
    }

    private void OnEnable() {
        if (startpos != null){transform.position = startpos;}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!lvlMan.GetShot()){return;}

        if(!started) {ballRB.velocity = velVector; started = true;}
        
        ballRB.velocity = Vector3.ClampMagnitude(ballRB.velocity, maxSpeed);
    }
}
