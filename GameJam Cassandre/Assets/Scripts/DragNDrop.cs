using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    private float snapDistance = 1; //Max Distance from grid snap is active
    //Size of the custom grid
    private float gridsize = 10f;
    private bool isDragged = false;
    private Vector3 mouseStartPos;
    private Vector3 spriteStartPos;

    //Function that round number to closest custom grid
    float RoundToNearestGrid(float position){
        float posDiff = position%gridsize;
        position -= posDiff;
        //If posDiff superior than half of the gridsize, round up instead
        if(posDiff>(gridsize/2)){
            position+=gridsize;
        }
        return position;
    }

    private void OnMouseDown(){
        //Init the value used when moving the object
        mouseStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteStartPos = transform.position;
    }

    private void OnMouseDrag(){
        //Update the value with the position of the cursor
        transform.position = spriteStartPos + (Camera.main.ScreenToWorldPoint(Input.mousePosition)- mouseStartPos);
        
    }

    private void OnMouseUp(){
        //Snap to grid when mouse release
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
