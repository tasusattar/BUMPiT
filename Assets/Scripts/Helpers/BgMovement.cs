using UnityEngine;

public class BgMovement : MonoBehaviour
{
    MeshRenderer mr;
    Material mat;
    Vector2 offset;
    // [SerializeField] bool menuScreen;

    [SerializeField] Texture[] pics;

    // float v;
    // Start is called before the first frame update
    void Start()
    {

        mr = GetComponent<MeshRenderer>();
        mat = mr.material;

        // if(pics.Length > 0){
            // int choice = GameSys.GetRandomInt(0, pics.Length);
            // mat.mainTexture = pics[choice];
            // }

        int choice = (GameSys.bgnum > pics.Length-1) ? 0 : GameSys.bgnum; 
        mat.mainTexture = pics[choice];
        choice++;
        GameSys.bgnum = choice;

        offset = mat.mainTextureOffset;
        // v = 0.001f;
    }

    

    // Update is called once per frame
    void Update()
    {
        // v = (v<1f) ? v+0.0001f: 0.001f;
        offset.x += Time.deltaTime / 25f;
        offset.y += Time.deltaTime/35f;
        transform.Rotate(new Vector3(0f, 0f, 2*Time.deltaTime), Space.Self); 

        mat.mainTextureOffset = offset;
    }


}
