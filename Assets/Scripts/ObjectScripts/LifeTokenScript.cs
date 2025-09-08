using UnityEngine;

public class LifeTokenScript : MonoBehaviour
{

    [SerializeField] Transform[] Positions;
    [SerializeField] AudioSource audi;

    void Start() {
        int selection = GameSys.GetRandomInt(0, Positions.Length);
        transform.position = Positions[selection].position;
        
    }
    void OnTriggerEnter2D(Collider2D other){

        if (other.tag == "GameBall"){
            audi.Play();
            GameMan.LifeUp(true);
            gameObject.SetActive(false);
        }
    }
}

