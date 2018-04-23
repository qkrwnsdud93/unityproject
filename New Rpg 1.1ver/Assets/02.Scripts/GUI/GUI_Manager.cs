using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_Manager : MonoBehaviour {
    static GUI_Manager m_cInstance = null;
    public GUI_SkillBtn m_cSkillBtn1;
    public GUI_SkillBtn m_cSkillBtn2;
    public GUI_SkillBtn m_cSkillBtn3;
    public GUI_SkillBtn m_cSkillBtn4;
    public GUI_SkillBtn m_cSkillBtnQ;
    public GUI_SkillBtn m_cSkillBtnE;
    public GUI_SkillBtn m_cSkillBtnR;
    public GUI_SkillBtn m_cSkillBtnF;


    // Use this for initialization
    void Start () {
        m_cInstance = this;

    }

    // Update is called once per frame
    void Update () {
		
	}
    public static GUI_Manager GetInstance()
    {
        return m_cInstance;
    }

}
