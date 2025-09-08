using UnityEngine;

public class GlowBlink : MonoBehaviour
{
    [SerializeField] float changeAmount;
    private SpriteRenderer spryt;
    private bool changedown;

    private LevelManager lvlMan;
    // Start is called before the first frame update
    void Start()
    {
        lvlMan = GameObject.FindGameObjectWithTag("LMan").GetComponent<LevelManager>();
        spryt = GetComponent<SpriteRenderer>();
        changedown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!lvlMan.GetShot()){return;}
        // make it glow/blink
        var curralpha = spryt.color.a;

        if (curralpha > 1f || curralpha < 0.7f){changedown = !changedown;}
        
        curralpha = (changedown)? curralpha-changeAmount : curralpha+changeAmount;
        
        spryt.color = new Color(spryt.color.r, spryt.color.g,
           spryt.color.b, curralpha);
    }
}
