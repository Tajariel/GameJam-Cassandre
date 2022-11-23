using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCounter : MonoBehaviour 
{
    public Grabber objectGrabbed;
    public GameObject selectedItem = null;
    public float moveCount;

    //Calculate the difference between the starting position and the current position to return the number of square the object moved on this axis
    float DistanceMovedOnAxis(float startAxisValue, float currentAxisValue){
        float distanceMoved = 0;
        if(startAxisValue<currentAxisValue){
            distanceMoved = currentAxisValue - startAxisValue;
        }else if(startAxisValue>currentAxisValue){
            distanceMoved = startAxisValue-currentAxisValue;
        }
        print(distanceMoved);
        return distanceMoved;
    }

    public void UpdateSelectedObject(GameObject selectedObj){
        selectedItem = selectedObj;
        print("updated");
    }


    float TotalDistanceMoved(){
        float totalDistance = 0;
        Vector3 objCurrentPos = objectGrabbed.currentPos;
        Vector3 objStartPos = objectGrabbed.startPosition;

        totalDistance = DistanceMovedOnAxis(objStartPos.x,objCurrentPos.x) + DistanceMovedOnAxis(objStartPos.z,objCurrentPos.z);
        totalDistance = totalDistance/objectGrabbed.gridSize;
        return totalDistance;
    }

    public void OnConfirmMajMoveCount(){
        if(objectGrabbed.confirmationState==true){
            moveCount-=TotalDistanceMoved();
        }else if(objectGrabbed.confirmationState==false){
            moveCount+=TotalDistanceMoved();
        }
        print(moveCount);
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
