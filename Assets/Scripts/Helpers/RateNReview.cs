using UnityEngine;

#if UNITY_IOS
using UnityEngine.iOS;             
#endif


public class RateNReview : MonoBehaviour
{
    [SerializeField] GameObject noRate;

    private void Awake() {
        GameSys.MuteUnMute();
    }

    public void ClickRate(){
        #if UNITY_ANDROID
            Application.OpenURL("market://details?id=com.KochiGamerz.BUMPiT");
        #elif UNITY_IOS
            var rev = Device.RequestStoreReview();
            if (!rev) {noRate.SetActive(true); gameObject.SetActive(false);}
        #else
            return;
        #endif
    }
}
