using UnityEngine;

public class BlackHoleScript : MonoBehaviour
{
    private LevelManager lvlMan;

    void Start() {
        lvlMan = GameObject.FindGameObjectWithTag("LMan").GetComponent<LevelManager>();    
    }
    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "GameBall") {
            lvlMan.LoseRound();
        }
    }
}