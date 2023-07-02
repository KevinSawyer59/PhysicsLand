using System.Collections.Generic;
using UnityEngine;

public class MarkLocation : MonoBehaviour
{
    public List<GameObject> markers;
    public GameObject markerPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            GameObject marker = Instantiate(markerPrefab) as GameObject;
            marker.transform.position = collision.gameObject.transform.position;
            CullBall ball = collision.gameObject.GetComponent<CullBall>();
            ball.trail.transform.SetParent(marker.transform);
            marker.GetComponent<Marker>().setTexts(ball.activeTime);
            markers.Add(marker);
            Destroy(collision.gameObject);
        }
    }

    public void RemoveAllMarkers()
    {
        if (markers.Count > 0)
        {
            for (int i = 0; i < markers.Count; i++)
            {
                Destroy(markers[i].gameObject);
            }
            markers.Clear();
        }
    }
}
