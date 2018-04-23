using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    public Sword(int lv, string name, int fun)
    {
        m_nLv = lv;
        m_strName = name;
        m_nFunction = fun;
    }

    //void WeaponFunction()
    //{
    //    switch (m_eKind_Weapon)
    //    {
    //        //case 
    //    }
    //}

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Reward()
    {
        m_fExp = GameManager.GetInstance().monster.m_fExp;

        if (m_fExp == m_fMax_Exp)
        {
            m_nLv++;
            m_fStr += 10;
            m_fInt += 4;
            m_fMax_Exp = m_fExp * 1.5f;
            m_fExp = 0;
        }
    }
}
