using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool IsOne, IsTwo;
    public GameObject[] platforms;

    void Start()
    {
        
    }

    void Update()
    {
        if(IsOne==true)
        {
            platforms[0].transform.position = Vector3.Lerp(platforms[0].transform.position, new Vector3(platforms[0].transform.position.x, 0, platforms[0].transform.position.z), 0.1f);

        }

        if (IsTwo == true)
        {
            platforms[1].transform.position = Vector3.Lerp(platforms[1].transform.position, new Vector3(platforms[1].transform.position.x, 0, platforms[1].transform.position.z), 0.1f);

        }



    }
}
