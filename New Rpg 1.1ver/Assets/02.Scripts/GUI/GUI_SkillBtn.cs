using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI_SkillBtn : MonoBehaviour
{
    public Image skillFilter;
    public Text coolTimeCounter; //남은 쿨타임을 표시할 텍스트
    public Animator m_aniPlayer;

    public float m_fCoolTime;
    public float m_fCurrentCoolTime; //남은 쿨타임을 추적 할 변수
    public bool m_bCanUseSkill = true; //스킬을 사용할 수 있는지 확인하는 변수
    public bool m_bMotionSkill = true; //애니메이션이 사용중인지 확인하는 변수

    void start()
    {
        skillFilter.fillAmount = 0; //처음에 스킬 버튼을 가리지 않음
    }

    public void MotionChk()
    {
        if(m_bMotionSkill == false)
        {

        }
    }

    public void UseSkill()
    {
        if (m_bMotionSkill)
        {
            if (m_bCanUseSkill)
            {
                Debug.Log("Use Skill");
                skillFilter.fillAmount = 1;

                m_bMotionSkill = false;
                MotionChk();

                StartCoroutine("Cooltime");

                m_fCurrentCoolTime = m_fCoolTime;
                coolTimeCounter.text = "" + m_fCurrentCoolTime;

                StartCoroutine("CoolTimeCounter");

                m_bCanUseSkill = false; //스킬을 사용하면 사용할 수 없는 상태로 바꿈

            }
            else
            {
                Debug.Log("아직 스킬을 사용할 수 없습니다.");
            }
        }
    }

    IEnumerator Cooltime()
    {
        while (skillFilter.fillAmount > 0)
        {
            skillFilter.fillAmount -= 1 * Time.smoothDeltaTime / m_fCoolTime;
            yield return null;
        }

        m_bMotionSkill = true;
        m_bCanUseSkill = true; //스킬 쿨타임이 끝나면 스킬을 사용할 수 있는 상태로 바꿈
        yield break;
    }

    //남은 쿨타임을 계산할 코르틴을 만듦
    IEnumerator CoolTimeCounter()
    {
        while (m_fCurrentCoolTime > 0)
        {
            yield return new WaitForSeconds(1.0f);

            m_fCurrentCoolTime -= 1.0f;
            coolTimeCounter.text = "" + m_fCurrentCoolTime;
        }
        yield break;
    }
}