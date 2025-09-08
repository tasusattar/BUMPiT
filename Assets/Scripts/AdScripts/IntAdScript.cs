using UnityEngine;

public class IntAdScript : MonoBehaviour
{

    [SerializeField] GameObject heardBtn;
    // Start is called before the first frame update
    void Start()
    {
      if(!AdMan.GetAdsOn()) Destroy(gameObject);   
    }

    // Update is called once per frame
    void Update()
    {
        if (AdMan.interstitial.IsLoaded()){
            AdMan.interstitial.Show();
        }
        else {
            heardBtn.SetActive(true);
        }
        
    }
}
