using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public List<Sword> m_listSword = new List<Sword>();
    public List<Wand> m_listWand = new List<Wand>();

    public int m_nLv = 1;
    public float m_fExp;
    public float m_fStr;
    public float m_fInt;
    public float m_fCrt;
    public float m_fAtk_Def;
    public float m_fMag_Def;
    public float m_fMove_Spd;
    public float m_fAtk_Spd;
    public float m_fRange;

    public float m_fMax_Lv;
    public float m_fMax_Exp;

    public string m_strName;
    public string m_strComent;
    public int m_nFunction;
    public string m_strImage;

    public void Init()
    {
        m_listSword.Add(new Sword(1, "검", 10));
        m_listWand.Add(new Wand(1, "지팡이", 10));

    }

    public void Status(int Lv, int Exp, int Str, int Int, int Crt, int Atk_Def, int Mag_Def, int Move_Spd, int Atk_Spd, int Range)
    {
        m_nLv = Lv;
        m_fExp = Exp;
        m_fStr = Str;
        m_fInt = Int;
        m_fCrt = Crt;
        m_fAtk_Def = Atk_Def;
        m_fMag_Def = Mag_Def;
        m_fMove_Spd = Move_Spd;
        m_fAtk_Spd = Atk_Spd;
        m_fRange = Range;
    }

    public void WeaponFun()
    {
        GameManager.GetInstance().player.m_fStr += m_fStr;
        GameManager.GetInstance().player.m_fInt += m_fInt;
        GameManager.GetInstance().player.m_fCrt += m_fCrt;
        GameManager.GetInstance().player.m_fAtk_Def += m_fAtk_Def;
        GameManager.GetInstance().player.m_fMag_Def += m_fMag_Def; //+개념
        GameManager.GetInstance().player.m_fMove_Spd = m_fMove_Spd; // =개념
        GameManager.GetInstance().player.m_fAtk_Spd = m_fAtk_Spd;
        GameManager.GetInstance().player.m_fRange = m_fRange;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
