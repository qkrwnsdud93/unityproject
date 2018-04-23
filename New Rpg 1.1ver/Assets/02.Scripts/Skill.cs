using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    GameObject m_Item = null;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GUI_Manager.GetInstance().m_cSkillBtn1.UseSkill();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GUI_Manager.GetInstance().m_cSkillBtn2.UseSkill();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GUI_Manager.GetInstance().m_cSkillBtn3.UseSkill();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GUI_Manager.GetInstance().m_cSkillBtn4.UseSkill();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            QSkill();
            GUI_Manager.GetInstance().m_cSkillBtnQ.UseSkill();
        }
        else
            GameManager.GetInstance().aniPlayer.SetBool("hit01Chk", false);

        if (Input.GetKeyDown(KeyCode.E))
        {
            ESkill();
            GUI_Manager.GetInstance().m_cSkillBtnE.UseSkill();
        }
        else
            GameManager.GetInstance().aniPlayer.SetBool("hit02Chk", false);


        if (Input.GetKeyDown(KeyCode.R))
        {
            RSkill();
            GUI_Manager.GetInstance().m_cSkillBtnR.UseSkill();
        }
        else
            GameManager.GetInstance().aniPlayer.SetBool("hit03Chk", false);


        if (Input.GetKeyDown(KeyCode.F))
        {
            GUI_Manager.GetInstance().m_cSkillBtnF.UseSkill();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Monster")
        {
            
            QSkill();
        }
    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("OnCollisionEnter:" + collision.gameObject.name);
    //    if(collision.gameObject.tag == "Sword")
    //    {

    //    }
    //    if(collision.gameObject.tag == "Player")
    //    {

    //    }
    //}

    public void QSkill()
    {
        if (GUI_Manager.GetInstance().m_cSkillBtnQ.m_bCanUseSkill)
            GameManager.GetInstance().aniPlayer.SetBool("hit01Chk", true);
        else
            GameManager.GetInstance().aniPlayer.SetBool("hit01Chk", false);

        GameManager.GetInstance().monster.m_fHp = GameManager.GetInstance().monster.m_fHp - 
            (GameManager.GetInstance().player.m_fStr - GameManager.GetInstance().monster.m_fAtk_Def);
        Debug.Log("Monster Hp" + GameManager.GetInstance().monster.m_fHp);

        //if (.tag == "Sword")
        //{
        //    Debug.Log("검");

        //    if (GameManager.GetInstance().m_cPlayer.m_fMp >= 100)
        //    {
        //        GameManager.GetInstance().m_cMonster.m_fHp -= GameManager.GetInstance().m_cPlayer.m_fStr + (GameManager.GetInstance().m_cSword.m_nLv * 1.5f);
        //        GameManager.GetInstance().m_cPlayer.m_fMp -= 100;
        //    }
        //}
        //if (m_Item.gameObject.tag == "Wand")
        //{
        //    Debug.Log("지팡이.");

        //    if (GameManager.GetInstance().m_cPlayer.m_fMp >= 100)
        //    {
        //        GameManager.GetInstance().m_cMonster.m_fHp -= GameManager.GetInstance().m_cPlayer.m_fInt + (GameManager.GetInstance().m_cWand.m_nLv * 1.5f);
        //        GameManager.GetInstance().m_cPlayer.m_fMp -= 100;
        //    }
        //}
        //if (m_Item == null)
        //{
        //    Debug.Log("무기를 장착하세요.");
        //}

    }

    public void ESkill()
    {
        if (GUI_Manager.GetInstance().m_cSkillBtnE.m_bCanUseSkill)
            GameManager.GetInstance().aniPlayer.SetBool("hit02Chk", true);
        else
            GameManager.GetInstance().aniPlayer.SetBool("hit02Chk", false);

    }

    public void RSkill()
    {
        if (GUI_Manager.GetInstance().m_cSkillBtnR.m_bCanUseSkill)
            GameManager.GetInstance().aniPlayer.SetBool("hit03Chk", true);
        else
            GameManager.GetInstance().aniPlayer.SetBool("hit03Chk", false);

    }


    void PassiveSkill()
    {

    }
}   

