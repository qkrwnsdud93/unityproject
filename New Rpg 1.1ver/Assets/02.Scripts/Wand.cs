using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : Weapon {

    public Wand(int lv, string name, int fun)
    {
        m_nLv = lv;
        m_strName = name;
        m_nFunction = fun;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
