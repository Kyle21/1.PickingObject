using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour {

    enum State {Walking, Attacking, Idling, Died }
    State m_State = State.Idling;
    State m_NextState = State.Idling;
    public  bool m_bMyTurn = false;
    Move m_csMove;

	// Use this for initialization
	void Start () {
        m_csMove = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () {
        Ai_Update();

    }

    void Ai_Update()
    {
        switch(m_State)
        {
            case State.Idling:
                {
                    if(m_bMyTurn) //내 턴이 되면 상태방한테 걷는다.
                    {
                        Walk();
                    }

                    break;
                }
            case State.Walking:
                {
                    break;
                }
            case State.Attacking:
                {
                    break;
                }
               
        }
    }
    void Walk()
    {
       // m_csMove.m_vDestination
    }
}
