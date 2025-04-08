using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public Image[] Hearts;
    public Sprite HeartFull;
    public Sprite HeartEmpty;
    private int Life = 3;

    public void SetLife(int newLife)
    {
        Life = Mathf.Clamp(newLife, 0, 3);
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < Life)
                Hearts[i].sprite = HeartFull;
            else
                Hearts[i].sprite = HeartEmpty;
        }
    }
    public void Miss()
    {
        SetLife(Life - 1);
        if (Life == 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
