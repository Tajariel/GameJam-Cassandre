using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    public float snapDistance = 1; //Max Distance from grid snap is active
    public Vector3 snapPos;
    public Vector3 targetPos;
    public Vector3 startPos;
    public Vector3 dist;

    void OnMouseDown(){
        //Init the value used when moving the object
        startPos = Camera.main.WorldToScreenPoint(transform.position);
        dist = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, startPos.z));
    }

    void OnMouseDrag(){
        //Update the value with the position of the cursor
        Vector3 lastPos=new Vector3(Mathf.Round(Input.mousePosition.x),Mathf.Round(Input.mousePosition.y),startPos.z);
        transform.position = Camera.main.ScreenToWorldPoint(lastPos) + dist;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
