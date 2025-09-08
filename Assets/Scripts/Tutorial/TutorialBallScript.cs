using UnityEngine;

public class TutorialBallScript : MonoBehaviour
{
    [SerializeField] GameObject[] tutorialPanels;
    [SerializeField] SpriteRenderer validHitBox;
    [SerializeField] GameObject tapObj ;
    [SerializeField] GameObject triggerZone;
    [SerializeField] GameObject bumper;
    [SerializeField] GameObject ballEndPos;
    

    


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

    private bool validhit;
    private bool wallhit;
    private bool triggered;
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
        maxSpeed = 6f;

        startTime = 0f;
        endTime = 0f;
        hitmade = false;
        validhit = false;
        wallhit = false;
        triggered = false;

        ballSprite = GetComponent<Renderer>();
        radiusDifference = (holeSprite.bounds.size.x - ballSprite.bounds.size.x) / 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        ballRB.velocity = Vector3.ClampMagnitude(ballRB.velocity, maxSpeed);

        // Check Win
        dist = Vector2.Distance(transform.position, holeOb.transform.position);
        if (dist <= radiusDifference){ lvlMan.RoundWon(); GameSys.SetTutorial(false); GameSys.SaveSettings(); return; }

        
        // Check to see if Panel 3 Triggered 
        if(ballRB.OverlapPoint(triggerZone.transform.position) && !triggered){triggered=true; OpenPanel(2);}

        // Check to see if TapZone pressed
        if(tutorialPanels[2].activeSelf && Input.GetMouseButton(0)){
            
            Vector3 wopos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            wopos.z = 0;

            bool xtrue = (wopos.x < tapObj.transform.position.x + tapObj.transform.localScale.x && wopos.x > tapObj.transform.position.x - tapObj.transform.localScale.x) ? true : false;
            bool ytrue = (wopos.x < tapObj.transform.position.y + tapObj.transform.localScale.y && wopos.y > tapObj.transform.position.y - tapObj.transform.localScale.y) ? true : false;
            if (xtrue && ytrue){
                bumper.SetActive(true);
                Destroy(tapObj.gameObject);
                ClosePanel(2);
            }
        }


        

        if (!lvlMan.GetShot() && Input.touchCount > 0) {
        // if (!lvlMan.GetShot() && Input.GetMouseButton(0)) {
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
                case TouchPhase.Moved:
                    // startPos = touch.position;
                    Vector2 movepos = touch.position;
                    Vector3 worldMovedPos = Camera.main.ScreenToWorldPoint(movepos);
                    worldMovedPos.z = 0f;
                    validhit = (validHitBox.bounds.Contains(worldMovedPos)) ? true : false;
                    break;

                case TouchPhase.Ended:
                    if (hitmade && validhit){
                        
                        endTime = Time.time;
                        float totalTime = endTime - startTime;
                        
                        endPos = touch.position;
                        Vector2 deltaDist = endPos - startPos;
                        float totalDistance = deltaDist.magnitude;
                        /*Vector2 forcedist = deltaDist.normalized;*/

                        if (totalDistance > 15 && totalTime > 0 && totalTime < 3)
                        {
                            ballRB.AddForce(new Vector2(5f, 9f)*30);
                            lvlMan.Shoot();
                            Destroy(validHitBox.gameObject);
                            ClosePanel(0);
                            
                        }
                    }
                    break;

            }

            // ballRB.AddForce(new Vector2(5f, 9f)*30);
            // Vector2 deltaDist = ballEndPos.transform.position - transform.position;
            // ballRB.AddForce(deltaDist*40);
            // lvlMan.Shoot();
            // ClosePanel(0);

        }

    }

    private void OnCollisionEnter2D(Collision2D other) {
        audMan.Play();
        if(other.gameObject.name == "RWall" && !wallhit){
            wallhit = true;
            OpenPanel(1);
        }

    }

    public void OpenPanel(int paneli){
        tutorialPanels[paneli].SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePanel(int paneli){
        
        tutorialPanels[paneli].SetActive(false);
        Time.timeScale = 1f;
    }

}
