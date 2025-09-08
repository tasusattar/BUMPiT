using UnityEngine;
using TMPro;

public class ShowRoundDetails : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] relChildText;
    [SerializeField] LevelManager lvlMan;
    // Start is called before the first frame update
    void Start()
    {   
        // allChildComps = gameObject.GetComponentsInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    private void OnEnable()
    {
        relChildText[0].text = "+ " + lvlMan.GetBarRoundPoints().ToString();
        relChildText[1].text = "+ " + lvlMan.GetWallRoundPoints().ToString();

    }
}
