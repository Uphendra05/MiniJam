using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Transform spawnPos;
    public GameObject playerPrefab;
    public CameraFollow camFollow;
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
        camFollow = FindObjectOfType<CameraFollow>();
    }



    public void InstantiatePlayer()
    {
        // spawning player and enabling the script 
       GameObject temp = Instantiate(playerPrefab, spawnPos.position, Quaternion.identity);
        camFollow.target = temp.transform;
        temp.GetComponent<Ball>().enabled = true;
        temp.GetComponent<Ball>().bar.fillAmount = 1;
        temp.GetComponent<Rigidbody>().isKinematic = false;
    }
}
