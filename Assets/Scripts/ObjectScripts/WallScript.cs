using UnityEngine;

public class WallScript : MonoBehaviour
{
    [SerializeField] Sprite[] wallColors;

    // private TextMeshProUGUI pptxt;
    private SpriteRenderer srender;
    private Collider2D wallcollider;

    [SerializeField] LevelManager lvlMan;

    private int hits;
    [SerializeField] AudioSource audMan;
    // Start is called before the first frame update
    void Start()
    {
        hits = 0;
        srender = GetComponent<SpriteRenderer>();
        wallcollider = GetComponent<Collider2D>();
        // audMan = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.tag == "GameBall"){
            hits++;
            audMan.Play();
            if (hits>3){
                lvlMan.AddWallRoundPoints(true);
                Destroy(gameObject);
                return;
            }
            srender.sprite = wallColors[hits-1];
            lvlMan.AddWallRoundPoints(false);
        }

    }

}
