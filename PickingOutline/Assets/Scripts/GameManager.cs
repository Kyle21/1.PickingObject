using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private GameObject[] m_Players;
    private GameObject[] m_OtherPlayers;

	// Use this for initialization
	void Start () {

        m_OtherPlayers = GameObject.FindGameObjectsWithTag("OtherPlayer");
        m_Players = GameObject.FindGameObjectsWithTag("Player");

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
