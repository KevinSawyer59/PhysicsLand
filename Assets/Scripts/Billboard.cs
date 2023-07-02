using UnityEngine;

public class Billboard : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.LookAt(GameManager.instance.mainCam.transform.position);
    }
}
