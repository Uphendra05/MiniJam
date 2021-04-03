using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Transform spawnPos;
    public GameObject playerPrefab;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        
    }



    public void InstantiatePlayer()
    {
       GameObject temp = Instantiate(playerPrefab, spawnPos.position, Quaternion.identity);
    }
}
