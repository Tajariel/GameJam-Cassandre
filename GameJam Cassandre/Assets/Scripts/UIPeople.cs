using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPeople : MonoBehaviour
{
    public Text textUI;

    public void UpdateDangerCounter(float newValue){
        textUI.text = newValue.ToString();
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
