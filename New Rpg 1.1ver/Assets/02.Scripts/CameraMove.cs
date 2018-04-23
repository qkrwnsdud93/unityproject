using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public Camera m_cCamera;

    public float xSensitivity = 1.0f;
    public float ySensitivity = 1.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float yRot = Input.GetAxis("Mouse X") * xSensitivity;
        float xRot = Input.GetAxis("Mouse Y") * ySensitivity;

        this.transform.localRotation *= Quaternion.Euler(0, yRot, 0);
        m_cCamera.transform.localRotation *= Quaternion.Euler(-xRot, 0, 0);
    }

    //   public Camera m_cCamera;

    //   public float m_fHorizontalSpeed = 2.0F;
    //   public float m_fVerticalSpeed = 2.0F;

    //   // Use this for initialization
    //   void Start () {

    //}

    //// Update is called once per frame
    //void Update () {
    //       float fVertical = -Input.GetAxis("Mouse Y");
    //       float fHorizontal = Input.GetAxis("Mouse X");

    //       float fAbsV = Mathf.Abs(fVertical);
    //       float fAbSH = Mathf.Abs(fHorizontal);

    //       if (fAbsV < fAbSH)
    //           m_cCamera.transform.Rotate(0, m_fHorizontalSpeed * fHorizontal, 0);//마우스 좌우 이동
    //       else if (fAbsV > fAbSH)
    //           m_cCamera.transform.Rotate(m_fVerticalSpeed * fVertical, 0, 0);//마우스 상하 이동


    //   }
}
