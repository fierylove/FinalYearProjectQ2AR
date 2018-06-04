using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTester : MonoBehaviour {

	//subscribe to object when it is created
	void Awake ()
    {
        DelegateHandler.programStartDelegate += Initialized;
	}

    void Initialized()
    {
        Debug.Log(gameObject.name + " Initialized");
    }

    //unsubscribe to object when it is deleted to prevent memory leak
    public void OnDisable()
    {
        DelegateHandler.programStartDelegate -= Initialized;
    }
}
