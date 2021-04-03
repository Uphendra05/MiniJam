using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndPoint : MonoBehaviour
{
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Player in");
            StartCoroutine(waiting(waitTime));
            this.GetComponent<Collider>().enabled = false;
            other.gameObject.GetComponent<Ball>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(waiting(waitTime));
        }
    }
  
    public IEnumerator waiting(float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        LevelManager.instance.InstantiatePlayer();
    }

   
}
