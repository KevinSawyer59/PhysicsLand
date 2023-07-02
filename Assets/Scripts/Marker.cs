using UnityEngine;
using TMPro;
public class Marker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI distanceText, timeText;

    public void setTexts(float time)
    {
        distanceText.text = this.gameObject.transform.position.z.ToString() + "m";
        timeText.text = time.ToString() + "s";
    }
}
