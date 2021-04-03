using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject currentLine;
    public GameObject linePrefab;
    public LineRenderer lineRenderer;
    public List<Vector3> linePositions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        linePositions.Clear();
        Ball ball = FindObjectOfType<Ball>();
        linePositions.Add(ball.transform.position);
        linePositions.Add(ball.transform.position);
        lineRenderer.SetPosition(0, linePositions[0]);
        lineRenderer.SetPosition(1, linePositions[1]);
        
    }
    public void UpdateLine(Vector3 newLinePos)
    {
        linePositions.Add(newLinePos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newLinePos);
    }

    
}
