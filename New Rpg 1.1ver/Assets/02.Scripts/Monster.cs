using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour {
    public Transform m_Target; //추적대상
    public float m_fMinDist; //대상을 추적하는 범위
    NavMeshAgent m_cNavMeshAgent;
    public float m_fDist = 0; //대상과의 남은거리, //디버깅을 위해 멤버변수로 만듦

    public List<Item> m_listItems = new List<Item>();

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

    // Use this for initialization
    void Start () {
        m_cNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update () {
        TrancingTarget();
    }

    public void MonsterStatus(int Lv, int Hp, int Mp, int Exp, int Str, int Int, int Crt, int Atk_Def, int Mag_Def, int Move_Spd, int Atk_Spd, int Range)
    {
        m_nLv = Lv;
        m_fHp = m_fMax_Hp = Hp;
        m_fMp = m_fMax_Mp = Mp;
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

    public bool Death()
    {
        if (m_fHp <= 0)
            return true;
        else
            return false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            MonsterAttack();
        }
        if (GameManager.GetInstance().monster.Death() == true)
        {

            Destroy(this.gameObject);
            }
    }

    public void MonsterAttack()
    {
        GameManager.GetInstance().player.m_fHp = GameManager.GetInstance().player.m_fHp - (m_fStr - GameManager.GetInstance().player.m_fAtk_Def);
        Debug.Log("Player Hp" + GameManager.GetInstance().player.m_fHp);
    }

    private void TrancingTarget()
    {
        m_Target = GameObject.Find("Player").transform;
        Vector3 vTargetPos = m_Target.position; //추적대상 위치
        Vector3 vPos = transform.position; //물체위치

        m_fDist = Vector3.Distance(vTargetPos, vPos);

        if (m_fDist < m_fMinDist) //대상의 추적 최소거리까지 물체를 추적함.
            m_cNavMeshAgent.SetDestination(vTargetPos);
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 20), "Dist" + m_fDist);
    }

    public void SetInventoryList()
    {
        m_listItems.Add(GameManager.GetInstance().itemManager.GetItem((int)Item.eKind.HPPotion));
        m_listItems.Add(GameManager.GetInstance().itemManager.GetItem((int)Item.eKind.MPPotion));
    }
}
