using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseBadge : MonoBehaviour
{

    [SerializeField] Sprite[] badgeSprites;
    [SerializeField] AudioClip[] badgeSounds;
    [SerializeField] TextMeshProUGUI badgeText;
    [SerializeField] LevelManager lvlMan;
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    private void OnEnable() {
        var audplayer = GetComponent<AudioSource>();
        var obSpriteRend = GetComponent<Image>();
        var wallpts = lvlMan.GetWallRoundPoints();
        if(wallpts < 60){
            obSpriteRend.sprite = badgeSprites[0];
            badgeText.color = new Color(0f, 216f, 255f);
            badgeText.text = "Straight Shooter";
            GameSys.AddBadge(0);
            audplayer.PlayOneShot(badgeSounds[0]);
            
        }
        else if(wallpts < 120){
            obSpriteRend.sprite = badgeSprites[1];
            badgeText.color = new Color(255f, 255f, 0f);
            badgeText.text = "Freestyler";
            GameSys.AddBadge(1);
            audplayer.PlayOneShot(badgeSounds[1]);
        }
        else if(wallpts < 200){
            obSpriteRend.sprite = badgeSprites[2];
            badgeText.color = new Color(255f, 126f, 0f);
            badgeText.text = "Daredevil";
            GameSys.AddBadge(2);
            audplayer.PlayOneShot(badgeSounds[2]);
        }
        else if(wallpts < 300){
            obSpriteRend.sprite = badgeSprites[3];
            badgeText.color = new Color(255f, 0f, 0f);
            badgeText.text = "Fearless Warrior";
            GameSys.AddBadge(3);
            audplayer.PlayOneShot(badgeSounds[3]);
        }
        else{
            obSpriteRend.sprite = badgeSprites[4];
            badgeText.color = new Color(0f, 255f, 0f);
            badgeText.text = "Berserk Monster";
            GameSys.AddBadge(4);
            audplayer.PlayOneShot(badgeSounds[4]);
        }
    }
}
