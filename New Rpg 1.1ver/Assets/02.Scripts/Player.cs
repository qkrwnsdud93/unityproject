using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    List<Item> m_listInvetory = new List<Item>();

    public int m_nLv = 1;
    public float m_fHp;
    public float m_fMp;
    public float m_fExp;
    public float m_fStr;
    public float m_fInt;
    public float m_fCrt;
    public float m_fAtk_Def;
    public float m_fMag_Def;
    public float m_fMove_Spd;
    public float m_fAtk_Spd;
    public float m_fRange;

    public int m_nMax_Lv;
    public float m_fMax_Hp;
    public float m_fMax_Mp;
    public float m_fMax_Exp;

    public int m_nGold;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool Death()
    {
        if (m_fHp <= 0)
            return true;
        else
            return false;
    }

    public void Reward()
    {
        m_fExp = GameManager.GetInstance().monster.m_fExp;

        if (m_fExp == m_fMax_Exp)
        {
            m_nLv++;
            m_fHp += 20;
            m_fMp += 10;
            m_fStr += 1;
            m_fInt += 1;
            m_fMax_Exp = m_fExp * 1.5f;
            m_fExp = 0;
        }
    }

    public void Basic_AD()
    {
        GameManager.GetInstance().monster.m_fHp = GameManager.GetInstance().monster.m_fHp - (m_fStr - GameManager.GetInstance().monster.m_fAtk_Def);
    }

    public void Basic_AP()
    {
        GameManager.GetInstance().monster.m_fHp = GameManager.GetInstance().monster.m_fHp - (m_fInt - GameManager.GetInstance().monster.m_fMag_Def);
    }

    public void Battle()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit m_HitInfo;                                       //충돌 성공했을 때 물체의 정보.
            if (Physics.Raycast(ray, out m_HitInfo, m_fRange))  //위치, 정보 , 사거리
            {
                GameObject col = m_HitInfo.collider.gameObject;
                if (col.gameObject.tag == "Monster")
                {
                    Basic_AD();
                    Debug.Log("Monster Hp" + GameManager.GetInstance().monster.m_fHp);
                }
            }
        }
    }

    public List<Item> GetInventoryList()
    {
        return m_listInvetory;
    }

    public void SetInventory(Item item)
    {
        m_listInvetory.Add(item);
    }

    public Item GetInventoryItem(int idx)
    {
        return m_listInvetory[idx];
    }

    public void DeleteInventory(Item item)
    {
        m_listInvetory.Remove(item);
    }

    public bool FindInventory(Item item)
    {
        for (int i = 0; i < m_listInvetory.Count; i++)
        {
            if (m_listInvetory[i] == item)
                return true;
        }
        return false;
    }

    public void SetEquipment(Item idx)
    {
        //웨폰 인벤토리 셋인벤토리
        //웨폰에 기능함수 추가
        //플레이어 인벤토리 릴리즈아이템
    }
}