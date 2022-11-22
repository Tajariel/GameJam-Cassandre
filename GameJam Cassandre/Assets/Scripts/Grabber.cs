using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grabber : MonoBehaviour
{

    private GameObject selectedObject;
    //Change this value to change size of grid
    public float gridSize = 10f;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            //When left click when nothing selected, grab object
            if(selectedObject == null){
                RaycastHit hit = CastRay();

                if(hit.collider != null) {
                    if(!hit.collider.CompareTag("drag")){
                        return;
                    }
                    selectedObject = hit.collider.gameObject;
                    //Cursor.visible = false;
                }
            }else{
                //when left click when object is selected, drop object where mouse is
                Vector3 position = new Vector3(Input.mousePosition.x,Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                selectedObject.transform.position = new Vector3(RoundToNearestGrid(worldPosition.x),0f,RoundToNearestGrid(worldPosition.z));
                
                selectedObject = null;
                //Cursor.visible = true;
            }
        }
        //When object is selected move object with mouse
        if(selectedObject != null){
            Vector3 position = new Vector3(Input.mousePosition.x,Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(RoundToNearestGrid(worldPosition.x),1f,RoundToNearestGrid(worldPosition.z));
        }
    }
    //Creation of a ray that use the mouse as the caster and the camera near and far clipping plane as the ray distance
    private RaycastHit CastRay() {
        //Position of mouse on screen with camera farthest view as the end point
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        //Position of mouse on screen with camera nearest view as the end point
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
            //Conversion of mouse position to world camera
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear,worldMousePosFar-worldMousePosNear,out hit);

        return hit;
    }

    float RoundToNearestGrid(float pos){

        float xDiff = pos % gridSize;
        pos-=xDiff;
        if (xDiff>(gridSize/2)){
            pos+=gridSize;
        }
        print("pos "+pos+"/gridSize "+gridSize+"/xDiff "+xDiff);
        return pos;
    }
}
