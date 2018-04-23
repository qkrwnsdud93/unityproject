using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Item
{
    public List<Item> m_listItems = new List<Item>();

    //방어구로 변경
    public enum eItem { NONE = -1, HPPotion, MPPotion, CLOTH_ARMOR, BONE_ARMOR, STEEL_ARMOR }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    //방어구로 변경 할 부분
    public void Init()
    {
        m_listItems.Add(new Item("체력포션", Item.eKind.HPPotion, "체력 회복", 50));
        m_listItems.Add(new Item("마나포션", Item.eKind.MPPotion, "마나 회복", 50));
       
    }

    public Item GetItem(int idx)
    {
        return m_listItems[idx];
    }

}