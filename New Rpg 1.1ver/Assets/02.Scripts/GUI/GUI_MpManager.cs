using UnityEngine;
using UnityEngine.UI;
public class GUI_MpManager : MonoBehaviour
{
    public Image CurrentMp;

    // Use this for initialization
    void Start()
    {
        CurrentMp.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentMp.fillAmount = (1 / GameManager.GetInstance().player.m_fMax_Mp) * GameManager.GetInstance().player.m_fMp;
    }
}



