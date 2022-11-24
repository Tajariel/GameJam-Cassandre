using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Counter : MonoBehaviour
{

    public List<GameObject> listDragableObjects;
    public Text textCounter;
    private MoveCounter selectedObj;

    public void UpdateCounter()
    {
        float totalMoves = 0;
                MoveCounter mc = listDragableObjects[0].GetComponent<MoveCounter>();
                if(mc)
                {
                    totalMoves += mc.moveCount;
                    print(listDragableObjects[0].GetComponent<MoveCounter>().moveCount);
                    print (totalMoves);
                }
                else
                {
                    Debug.LogWarning("TA MERE");
                }
            //counter.SetText(totalMoves.ToString());
            textCounter.text = totalMoves.ToString();
    }

    // Start is called before the first frame update
    void Awake()
    {
        textCounter = GetComponent<Text>();
    }

    /*// Update is called once per frame
    void Update()
    {
       // Debug.Log(textCounter.text);
        if(Input.GetMouseButtonDown(0)||Input.GetMouseButtonDown(1))
        {
            
        }
    }*/
}
