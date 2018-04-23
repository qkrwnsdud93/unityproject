using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic : MonoBehaviour
{
    public Camera m_cCamera;

    public float m_fSpeed;

    float m_fMoveDist = -1; //이동할 거리
    float m_fMovedDist = 0; //이동할 위치까지 이동된 거리

    // Use this for initialization
    void Start()
    {
    }

    void Update()
    {
        if ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0))
        {
            GameManager.GetInstance().aniPlayer.SetBool("walkChk", true);
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * m_fSpeed * Time.deltaTime);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    transform.Translate(Vector3.forward * m_fSpeed * 2 * Time.deltaTime);
                    GameManager.GetInstance().aniPlayer.SetBool("runChk", true);
                }
                else
                    GameManager.GetInstance().aniPlayer.SetBool("runChk", false);
            }
            else
                GameManager.GetInstance().aniPlayer.SetBool("runChk", false);

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * m_fSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * m_fSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * m_fSpeed * Time.deltaTime);
            }
        }
        else
            GameManager.GetInstance().aniPlayer.SetBool("walkChk", false);

        if (Input.GetKey(KeyCode.Space))
        {
            GameManager.GetInstance().aniPlayer.SetBool("jumpChk", true);
        }
        else
            GameManager.GetInstance().aniPlayer.SetBool("jumpChk", false);

        //InputProcess();
        //MoveProcess(Time.deltaTime);
    }   

    void InputProcess()
    {

        if (Input.GetMouseButtonUp(1))
        {
            //마우스의 2D좌표를 이용하여 광선 생성(광선시작위치,광선방향)
            Ray ray = m_cCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo; //충돌이 성공했을때 충돌된 물체의 정보
            float fDistance = 100; //충돌체크용(광선길이)
            //광선의 길이 안에 물체가 있다면 hitInfo에 저장된다.
            if (Physics.Raycast(ray, out hitInfo, fDistance))
            {
                Vector3 vPos = this.transform.position;
                Vector3 vRayFickingPos = hitInfo.point;

                //이동할방향 = 이동할위치 - 현재위치 
                Vector3 vDir = vRayFickingPos - vPos;
                m_fMoveDist = vDir.magnitude; //이동할 위치와 거리를 구함.
                m_fMovedDist = 0; //이동한 거리를 0으로 초기화한다.

                //마우스를 찍은 위치 바라보기
                transform.LookAt(vRayFickingPos);
                ////오일러의 각을 이용하여 회전하기
                //vDir.Normalize();
                //Quaternion q = Quaternion.LookRotation(vDir);
                //transform.rotation = Quaternion.Euler(0, q.eulerAngles.y,0);
            }
        }
    }

    void MoveProcess(float time)
    {
        //이동할 거리가 0보다 클때까지 이동시킨다.
        if (m_fMoveDist >= 0)
        {
            //물체가 바라보는 방향으로 이동속도만큼 이동시킨다.
            Vector3 vMove = Vector3.forward * m_fSpeed * time;
            transform.Translate(vMove);
            //이동한 물체의 거리를 누적하여 저장한다.
            m_fMovedDist += vMove.magnitude;
            //이동한 거리가 이동할거리보다 커지면 이동을 중지시킨다.
            if (m_fMovedDist > m_fMoveDist)
                m_fMoveDist = -1; //-1을 이용하여 이동하지않도록한다.
        }
    }

}

//private void OnCollisionEnter(Collision collision)
//{
//    Debug.Log("OnCollisionEnter:" + collision.gameObject.name);
//    if (collision.gameObject.tag == "Monster")
//    {
//        GameManager.GetInstance().MAttack(GameManager.GetInstance().monster.m_fStr);
//        Debug.Log("공격받음 플레이어 체력:" + GameManager.GetInstance().player.m_fHp);
//        GameManager.GetInstance().Attack(GameManager.GetInstance().player.m_fStr);
//        Debug.Log("공격함 몬스터 체력:" + GameManager.GetInstance().monster.m_fHp);
//    }
//    if (GameManager.GetInstance().monster.Dead() == true)
//    {
//        GameManager.GetInstance().player.SetInventory(GameManager.GetInstance().monster.GetIventoryItem(Random.Range(0, 7)));
//        Debug.Log("아이템획득" + GameManager.GetInstance().player.m_Inventory[0].m_eKind);
//        GameManager.GetInstance().player.SetEquipment(GameManager.GetInstance().player.m_Inventory[0]);
//        GameManager.GetInstance().monster.DeleteMonster(collision.gameObject);
//    }
//}
