using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    static GameManager instance = null;
    public Animator aniPlayer;
    public Player player;
    public Monster monster;
    public EventManager eventManager;
    public Sword sword;
    public Wand wand;
    public ItemManager itemManager;

    // Use this for initialization
    void Start () {
        instance = this;

    }

    // Update is called once per frame
    void Update () {
        
	}

    public static GameManager GetInstance()
    {
        return instance;
    }
}
