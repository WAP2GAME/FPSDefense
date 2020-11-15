using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance = null; 
    public static GameManager instance
    {
        get
        {
            return Instance;
        }
    }



    [SerializeField] Text CountText;
    float Count = 60;

    public int AddZombieHp;
    public int AddZombiePower;



    public GameObject Player;
    public GameObject Nexus;



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        AddZombieHp = 0;
        AddZombiePower = 0;
    }

    void FixedUpdate()
    {
        Count -= Time.deltaTime;
        CountText.text = (int)Count + "";

        if(Count < 0)
        {
            Count = 60;
            AddZombieHp += 100; // 시간이 지날수록 좀비HP 100
            AddZombiePower += 10; // 공격력 10 강화
        }
    }


    public void StageReset()
    {
        AddZombieHp = 0; 
        AddZombiePower = 0;
    }
}
