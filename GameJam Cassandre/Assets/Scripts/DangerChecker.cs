using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerChecker : MonoBehaviour
{
    public UIPeople peopleCounter;
    public float numberDanger;

    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag == "personne"){
            numberDanger = numberDanger +1;
            peopleCounter.UpdateDangerCounter(numberDanger);
        }
    }

    void OnTriggerExit(Collider collision){
        if(collision.gameObject.tag == "personne"){
            numberDanger = numberDanger -1;
            peopleCounter.UpdateDangerCounter(numberDanger);
        }
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
