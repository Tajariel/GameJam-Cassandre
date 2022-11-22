using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grabber : MonoBehaviour
{

    private GameObject selectedObject;
    public bool confirmationState = false;
    //Change this value to change size of grid
    public float gridSize = 10f;
    public Vector3 startPosition;
    public Vector3 currentPos;
    public float gridOffset = 5f;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            
            //When object is in confirmation and left click is used accept movement of object
            if(confirmationState == true){
                selectedObject.tag = "drag";
                selectedObject = null;
                confirmationState = false;
                print("confirmé");
            }
            //When left click when nothing selected, grab object

            else if(selectedObject == null){
                RaycastHit hit = CastRay();

                if(hit.collider != null) {
                    if(!hit.collider.CompareTag("drag")){
                        return;
                    }
                    
                    selectedObject = hit.collider.gameObject;
                    startPosition = selectedObject.transform.position;
                    print("grabbed");
                    //Cursor.visible = false;
                }
            }else{
                //when left click when object is selected, drop object where mouse is
                print(selectedObject);
                Vector3 position = new Vector3(Input.mousePosition.x,Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                selectedObject.transform.position = new Vector3(RoundToNearestGrid(worldPosition.x)+gridOffset,0f,RoundToNearestGrid(worldPosition.z)+gridOffset);
                currentPos = selectedObject.transform.position;
                confirmationState = true;
                selectedObject.tag = "frozen";
                print(selectedObject);
                print("posé en attente de confirmation");
                
                //Cursor.visible = true;
            }
        }

        //Cancel potential object move by left clicking
        if(Input.GetMouseButtonDown(1)){

            if(confirmationState == true){
                selectedObject.transform.position = startPosition;
                selectedObject.tag = "drag";
                selectedObject = null;
                confirmationState = false;
                print("annulé en confirmation");
            }else if(selectedObject != null){
                selectedObject.transform.position = startPosition;
                selectedObject.tag = "drag";
                selectedObject = null;
                print(selectedObject);
                print("annulé en mouvement");
            }
            
        }

        //When object is selected move object with mouse
        if((selectedObject != null) && (confirmationState== false)){
            Vector3 position = new Vector3(Input.mousePosition.x,Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(RoundToNearestGrid(worldPosition.x)+gridOffset,1f,RoundToNearestGrid(worldPosition.z)+gridOffset);
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
        return pos;
    }
}
