using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Spwan : MonoBehaviour {
    public GameObject slime;
    public float createTime = 3.0f;
    
	// Use this for initialization
	void Start () {
        Instantiate(slime).transform.SetParent(transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
