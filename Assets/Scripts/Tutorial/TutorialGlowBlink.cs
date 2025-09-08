using UnityEngine;
using UnityEngine.UI;

public class TutorialGlowBlink : MonoBehaviour
{
    private float changeAmount;
    private Image spryt;
    private bool changedown;

    // Start is called before the first frame update
    void Start()
    {
        changeAmount = 0.007f;
        spryt = GetComponent<Image>();
        changedown = true;
    }

    // Update is called once per frame
    void Update()
    {
        // make it glow/blink
        var curralpha = spryt.color.a;

        if (curralpha > 1f || curralpha < 0.5f){changedown = !changedown;}
        
        curralpha = (changedown)? curralpha-changeAmount : curralpha+changeAmount;
        
        spryt.color = new Color(spryt.color.r, spryt.color.g,
           spryt.color.b, curralpha);
    }
}
