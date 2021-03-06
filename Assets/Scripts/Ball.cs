using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    public float ballSpeed;
    public Image bar;
    public float reduceAmount, lerpTime, timer;
    public bool IsHotSpot,IsOverHeated;
    public Color[] colors;
    public GameObject holer;
    public Platform platform;
    public DrawLine line;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        line = FindObjectOfType<DrawLine>();
       
    }

  
    void Update()
    {
        Mathf.Clamp(bar.fillAmount, 0, 1);


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.AddTorque(new Vector3(horizontal, 0, vertical) * ballSpeed );

        if(IsHotSpot == true)
        {
            IncreaseHeatBar();
        }
        else
        {
            ReduceHeatBar();
        }

        if(bar.fillAmount >=1)
        {
            IsOverHeated = true;
            Debug.Log("OVERHEATED");
           
        }
        if (bar.fillAmount <= 0.75f)
        {
            IsOverHeated = false;

        }

        //if (horizontal>0.2f ||horizontal<-0.2f|| vertical>0.2f|| vertical < -0.2f)
        //{
        //    Vector3 ballPos = this.transform.position;
        //    if (Vector3.Distance(ballPos,line.linePositions[line.linePositions.Count-1])>0.1f)
        //    {
        //        line.UpdateLine(ballPos);
        //    }
        //}











    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Hotspot"))
        {
            IsHotSpot = true;
        }
        if (other.gameObject.CompareTag("Freeze"))
        {
            reduceAmount = 0.3f;
        }

        if(other.gameObject.CompareTag("EndPoint"))
        {
            if(other.gameObject.GetComponent<EndPoint>().Boxind.boxInd == 1)
            {
                platform.IsOne = true;
            }
           
        }
       

    }
    private void OnCollisionStay(Collision collision)
    {
        Vector3 ballPos = transform.position - new Vector3(0,transform.localScale.y/2,0);
        

        if (Vector3.Distance(ballPos, line.linePositions[line.linePositions.Count - 1]) > 0.5f)
        {
            line.UpdateLine(ballPos);
            if (line.linePositions.Count>100)
            {
                line.linePositions.Clear();
                line.createLine();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Hotspot"))
        {
            IsHotSpot = false;

        }
        if (other.gameObject.CompareTag("Freeze"))
        {
            reduceAmount = 0.1f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        line.createLine();
        if (IsOverHeated)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                GameObject temp = Instantiate(holer, this.transform.position, holer.transform.rotation);
                collision.gameObject.GetComponent<BoxCollider>().enabled = false;

            }

        }

        if(collision.gameObject.CompareTag("Respawn"))
        {
            LevelManager.instance.DestroyPreviousLines();
            transform.position = LevelManager.instance.spawnPos.position;
        }

        
        
       
       
    }

   
    public void ReduceHeatBar()
    {
        bar.fillAmount -= Time.deltaTime * reduceAmount;
      

    }

    public void IncreaseHeatBar()
    {
        bar.fillAmount += Time.deltaTime * reduceAmount;
       
    }

   






    

}
