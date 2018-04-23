using UnityEngine;
using UnityEngine.UI;
public class GUI_HpManager : MonoBehaviour {
    public Image CurrentHp;

    // Use this for initialization
    void Start () {
        CurrentHp.fillAmount = 1;
    }
	
	// Update is called once per frame
	void Update () {
        CurrentHp.fillAmount = (1 / GameManager.GetInstance().player.m_fMax_Hp) * GameManager.GetInstance().player.m_fHp;
    }
}


