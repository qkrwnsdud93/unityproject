using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public enum eKind { HPPotion, MPPotion, ARMOR }
    string m_strName;
    eKind m_eKind;
    string m_strComent;
    float m_nFunction;
    string m_strImage;

    
    public Item() { }
    public Item(string name, eKind kind, string coment, float fun)
    {
        m_strName = name;
        m_eKind = kind;
        m_strComent = coment;
        m_nFunction = fun;
    }

    void ItemFunction()
    {
        switch (m_eKind)
        {
            //case eItem.HPPotion:

        }
    }

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }
}
