using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentChanger : MonoBehaviour
{
    public Transform m_ItemChange;
    GameObject m_CurrentWeapon = null;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 150, 50), "Sword"))
        {
            SetItem("Sword");
        }
        if (GUI.Button(new Rect(150, 0, 150, 50), "Wand"))
        {
            SetItem("Wand");
        }
    }

    public void SaveItem()
    {
        if (m_CurrentWeapon != null)
        {
            m_CurrentWeapon.SetActive(false);
            m_CurrentWeapon = null;
        }
    }

    public void SetItem(string name)
    {
        if (m_CurrentWeapon != null)
            SaveItem();

        GameObject weapon = Resources.Load("Prefap/" + name) as GameObject;
        m_CurrentWeapon = (GameObject)Instantiate(weapon);

        m_CurrentWeapon.transform.SetParent(m_ItemChange.transform);

        m_CurrentWeapon.transform.localPosition = new Vector3(0.2f, 0.32f, 0.767f);
        m_CurrentWeapon.transform.localRotation = new Quaternion(0, 90, 0, 1);
        m_CurrentWeapon.transform.localScale = new Vector3(2f, 2, 2f);
    }


}
