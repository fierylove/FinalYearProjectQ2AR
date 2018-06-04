using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateHandler : MonoBehaviour {

    public delegate void OnProgamStartDelegate();
    public static event OnProgamStartDelegate programStartDelegate;

	// Use this for initialization
	void Start () {
        if (programStartDelegate != null)
            programStartDelegate();
	}
	
}
