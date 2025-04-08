using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    private float SumTime = 0f;
    void Update()
    {
        SumTime += Time.deltaTime;
        int min = Mathf.FloorToInt(SumTime / 60f);
        int sec = Mathf.FloorToInt(SumTime % 60f);
        TimerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
