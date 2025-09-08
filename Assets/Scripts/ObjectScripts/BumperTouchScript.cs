using UnityEngine;

public class BumperTouchScript : MonoBehaviour
{

    [SerializeField] GameObject bumper;
    [SerializeField] LevelManager lvlMan;

    private Rigidbody2D bumpRB;
    // Start is called before the first frame update
    void Start()
    {
        bumpRB = bumper.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && lvlMan.GetShot()  && Time.timeScale == 1)
        {            
            Touch touche = Input.GetTouch(0);
            TouchPhase touchphase = touche.phase;

            Vector3 spawnpos;
            spawnpos = Camera.main.ScreenToWorldPoint(touche.position);
            spawnpos.z = 0;
            // bumper.transform.position = spawnpos;
            ;

            if (touchphase == TouchPhase.Began){
                bumper.transform.position = spawnpos;
                bumper.SetActive(true);
                bumpRB.position = spawnpos;

            }

            if (touchphase == TouchPhase.Ended){
                bumper.SetActive(false);
            }


            bumpRB.MovePosition(spawnpos);

            // if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) { return; }
            
            
            


        }
    }
}
