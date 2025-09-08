using UnityEngine;

public class BoundaryExitScript : MonoBehaviour
{
    [SerializeField] LevelManager lvlMan;
    // Start is called before the first frame update

    private float xdi;
    private float ydi;
    private void Start() {
        xdi = ScreenProperties.GetXDiff()*2;
        ydi = ScreenProperties.GetYDiff()*2;

        transform.localScale = new Vector3(transform.localScale.x + xdi, transform.localScale.y + ydi, 1f);

    }
    private void OnTriggerExit2D(Collider2D other) {
        // if(lvlMan.tutorialLevel) return;
        Debug.Log("ITS ME");
        if(other.tag == "GameBall") lvlMan.LoseRound();
    }
}
