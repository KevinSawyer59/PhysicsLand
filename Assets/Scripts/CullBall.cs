using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullBall : MonoBehaviour
{
    public float activeTime = 0;
    public float timeCull = 60;
    public GameObject trail;

    private void Update()
    {
        activeTime += Time.deltaTime;
        timeCull -= Time.deltaTime;

        if (timeCull < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
