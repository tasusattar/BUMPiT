using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
   [SerializeField] Image timerFill;
   [SerializeField] LevelManager levelManager;

   [SerializeField] AudioSource audPlayer;
   [SerializeField] AudioClip audSound1;

   [SerializeField] AudioClip bumpedSound;

   private bool sound1;
   private bool sound2;
   private bool sound3;

    private float startingTime;
    // private bool timerRunning;
    private float timeRemaining;
    private int timeToDisplay;
    private TextMeshProUGUI timeText;
    private bool timerBumped;
    private float bumpTime;

    // Start is called before the first frame update
    void Start()
    {
        startingTime = CheckLevelStartTime();

        timeRemaining = startingTime;
        timeToDisplay = (int) timeRemaining;
        timeText = GetComponent<TextMeshProUGUI>();

        timerBumped = false;
        bumpTime = 1f;

        timerFill.fillAmount = 1f;

        sound1 = false;
        sound2 = false;
        sound3 = false;


    }

    // Update is called once per frame
    void Update()
    {
        timeToDisplay = Mathf.CeilToInt(timeRemaining);
        timeText.text = timeToDisplay.ToString();


        if (timerBumped) {
            bumpTime -= Time.deltaTime;
            timeText.color = new Color(0.8396226f, 0.4123277f, 0.099f, 0.7f);
            if (bumpTime <= 0) {
                timerBumped = false;
                timeText.color = new Color(255f, 255f, 255f, 1f);
            }
            return;
        }

        if (levelManager.GetShot()) {
            timeRemaining -= Time.deltaTime;
            AnimateFill();
            // timeText.color = (timeRemaining < 3) ? new Color(0.5803922f, 0.01568628f, 0.1411765f, 0.7f) : new Color(0.1921569f, 0.4588236f, 0.5058824f, 1f);
            timeText.color = (timeRemaining < 3) ? new Color(0.5803922f, 0.01568628f, 0.1411765f, 0.7f) : new Color(255f, 255f, 255f, 1f);
        }

        if (timeRemaining <= -0.1) {
            timeRemaining = 0f;
            levelManager.LoseRound();

        }

        if (timeRemaining <= 3 && !sound1) {
            sound1  = true;
            audPlayer.PlayOneShot(audSound1);
        } 
        if (timeRemaining <= 2 && !sound2) {
            sound2  = true;
            audPlayer.PlayOneShot(audSound1);
        } 
        if (timeRemaining <= 1 && !sound3) {
            sound3  = true;
            audPlayer.PlayOneShot(audSound1);
        } 


    }

    void OnCollisionEnter2D(Collision2D other) {
        bumpTime = 1f;
        timerBumped = true;
        audPlayer.PlayOneShot(bumpedSound);
    }

    void AnimateFill() {
        timerFill.fillAmount = timeRemaining / startingTime;
    }

    private int CheckLevelStartTime() {
        // if(GameMan.GetNumBarriers()<3){return 8;}
        // else if(GameMan.GetNumBarriers()< 5){return 10;}
        // else if(GameMan.GetNumBarriers()<7){return 12;}
        // else if(GameMan.GetNumBarriers()<9){return 15;}
        // else {return 20;}
        return 10 + GameMan.GetNumBarriers();
    }

    public void Freeze(){
        Time.timeScale = 0f;
    }

    public void UnFreeze(){
        Time.timeScale = 1f;
        
    }

}


