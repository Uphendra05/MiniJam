using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndPoint : MonoBehaviour
{
    public float waitTime;
    public IntCount Boxind;
    public GameObject freezeSpot;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelManager.instance.boxCount == 0)
        {
            Debug.Log("Finished Level");
            Time.timeScale = 0;
            
        }


        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball")&& Boxind.boxInd == 1)
        {
            StartCoroutine(waiting(waitTime));
            this.GetComponent<Collider>().enabled = false;
            other.gameObject.GetComponent<Ball>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            freezeSpot.GetComponent<Collider>().enabled = false;
            freezeSpot.GetComponent<MeshRenderer>().material.color = Color.gray;
            Debug.Log("First Dabba");
            LevelManager.instance.boxCount--;

        }
        if (other.gameObject.CompareTag("Ball") && Boxind.boxInd == 2)
        {
            StartCoroutine(waiting(waitTime));
            this.GetComponent<Collider>().enabled = false;
            other.gameObject.GetComponent<Ball>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            freezeSpot.GetComponent<Collider>().enabled = false;
            freezeSpot.GetComponent<MeshRenderer>().material.color = Color.gray;
            Debug.Log("First Dabba");
            LevelManager.instance.boxCount--;

        }
        if (other.gameObject.CompareTag("Ball") && Boxind.boxInd == 3)
        {
            StartCoroutine(waiting(waitTime));
            this.GetComponent<Collider>().enabled = false;
            other.gameObject.GetComponent<Ball>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            freezeSpot.GetComponent<Collider>().enabled = false;
            freezeSpot.GetComponent<MeshRenderer>().material.color = Color.gray;
            Debug.Log("First Dabba");
            LevelManager.instance.boxCount--;

        }
        if (other.gameObject.CompareTag("Ball") && Boxind.boxInd == 4)
        {
           // StartCoroutine(waiting(waitTime));
            this.GetComponent<Collider>().enabled = false;
            other.gameObject.GetComponent<Ball>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            freezeSpot.GetComponent<Collider>().enabled = false;
            freezeSpot.GetComponent<MeshRenderer>().material.color = Color.gray;
            Debug.Log("First Dabba");
            LevelManager.instance.boxCount--;

        }




    }
  
    public IEnumerator waiting(float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        LevelManager.instance.InstantiatePlayer();
    }

   
}
