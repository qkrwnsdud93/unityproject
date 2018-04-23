using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    private float h = 0.0f;
    private float v = 0.0f;

    private Transform tr;
    public float moveSpeed = 5f;
    public float rotSpeed = 100.0f;

    // Use this for initialization
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        if ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0))
        {
            if (Input.GetKey(KeyCode.W))
            {
                GameManager.GetInstance().aniPlayer.SetBool("ani_walk_forward", true);
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    transform.Translate(Vector3.forward * moveSpeed * 1.3f * Time.deltaTime);
                }
            }
            else
                GameManager.GetInstance().aniPlayer.SetBool("ani_walk_forward", false);

            if (Input.GetKey(KeyCode.S))
            {
                GameManager.GetInstance().aniPlayer.SetBool("ani_walk_back", true);
                transform.Translate(Vector3.back * moveSpeed/2.0f * Time.deltaTime);
            }
            else
                GameManager.GetInstance().aniPlayer.SetBool("ani_walk_back", false);

            if (Input.GetKey(KeyCode.D))
            {
                GameManager.GetInstance().aniPlayer.SetBool("ani_walk_right", true);
                transform.Translate(Vector3.right * moveSpeed/1.7f * Time.deltaTime);
            }
            else
                GameManager.GetInstance().aniPlayer.SetBool("ani_walk_right", false);

            if (Input.GetKey(KeyCode.A))
            {
                GameManager.GetInstance().aniPlayer.SetBool("ani_walk_left", true);
                transform.Translate(Vector3.left * moveSpeed/1.7f * Time.deltaTime);
            }
            else
                GameManager.GetInstance().aniPlayer.SetBool("ani_walk_left", false);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            GameManager.GetInstance().aniPlayer.SetBool("ani_jump", true);
        }
        else
            GameManager.GetInstance().aniPlayer.SetBool("ani_jump", false);


        tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));
    }
}
