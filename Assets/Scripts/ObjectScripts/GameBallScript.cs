using UnityEngine;

public class GameBallScript : MonoBehaviour
{
    private LevelManager lvlMan;

    private AudioSource audMan;
    private Rigidbody2D ballRB;
    private float maxSpeed;

// Check for shot propeties
    private float startTime;
    private float endTime;
    private Vector2 startPos;
    private Vector2 endPos;
    private bool hitmade;
    // private Collider2D ballcoll;


// check for win properties
    private GameObject holeOb;
    private Renderer holeSprite;
    private Renderer ballSprite;
    private float dist;     /*Distance between ball and hole*/
    private float radiusDifference;

    // Start is called before the first frame update
    void Start()
    {
        audMan = GetComponent<AudioSource>();
        lvlMan = GameObject.FindGameObjectWithTag("LMan").GetComponent<LevelManager>();
        holeOb = GameObject.FindGameObjectWithTag("Target");
        holeSprite = holeOb.GetComponent<Renderer>();
        ballRB = GetComponent<Rigidbody2D>();
        ballRB.velocity = new Vector2(0f, 0f);
        maxSpeed = 5.5f * ScreenProperties.GetSizeMult();

        startTime = 0f;
        endTime = 0f;
        hitmade = false;

        ballSprite = GetComponent<Renderer>();
        radiusDifference = (holeSprite.bounds.size.x - ballSprite.bounds.size.x) / 2;
        
    }

    private void FixedUpdate() {
        //  ballRB.velocity = Vector3.ClampMagnitude(ballRB.velocity, maxSpeed);

         if(ballRB.velocity.magnitude > maxSpeed)
        {
            ballRB.velocity = ballRB.velocity.normalized * maxSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ballRB.velocity = Vector3.ClampMagnitude(ballRB.velocity, maxSpeed);

        // Check Win
        dist = Vector2.Distance(transform.position, holeOb.transform.position);
        if (dist <= radiusDifference){ lvlMan.RoundWon(); return; }



        if (!lvlMan.GetShot() && Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            
            switch (touch.phase)
            {
                
                case TouchPhase.Began:
                    startPos = touch.position;
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(startPos);
                    if (ballRB.OverlapPoint(worldPos))
                    {
                        hitmade = true;
                        startTime = Time.time;
                    }
                    break;
                case TouchPhase.Stationary:
                    startTime = (hitmade) ? Time.time : startTime;
                    break;
                case TouchPhase.Ended:
                    if (hitmade){
                        
                        endTime = Time.time;
                        float totalTime = endTime - startTime;
                        
                        endPos = touch.position;
                        Vector2 deltaDist = endPos - startPos;
                        float totalDistance = deltaDist.magnitude;
                        /*Vector2 forcedist = deltaDist.normalized;*/
                        /*Debug.Log(totalDistance);*/

                        if (totalDistance > 15 && totalTime > 0 && totalTime < 3)
                        {
                            ballRB.AddForce(deltaDist*3);
                            lvlMan.Shoot();
                        }
                    }
                    break;

            }

        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        audMan.Play();        
    }

}
