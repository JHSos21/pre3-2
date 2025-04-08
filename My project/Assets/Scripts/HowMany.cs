using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowMany : MonoBehaviour
{
    public TextMeshProUGUI Num;
    public static int Ans = 0;
    public void SumAns()
    {
        Ans++;
        Debug.Log(Ans);
        Num.text = string.Format("{0}/7", Ans);
        if (Ans == 7)
        {
            SceneManager.LoadScene(2);
        }
    }
}