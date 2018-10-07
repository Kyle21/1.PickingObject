using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    // Use this for initialization
    private bool m_bSelected = false;
    public bool GS_Selected
    {
        get { return m_bSelected; }
        set { m_bSelected = GS_Selected; }
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
