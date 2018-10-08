using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour {

    Animator animator;

    Move move;
    Vector3 prePosition;
    bool isDown = false;
    bool attacked = false;

    public float m_fIdleTime = 2.0f;




    public bool IsAttacked()
    {
        return attacked;
    }

    void StartAttackHit()
    {
        Debug.Log("StartAttackHit");
    }

    void EndAttackHit()
    {
        Debug.Log("EndAttackHit");
    }

    void EndAttack()
    {
        attacked = true;
    }
    void ResetIdleTime()
    {
        m_fIdleTime = 0.0f;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
       
        move = FindObjectOfType<Move>();
        prePosition = transform.position;
        //prePosition.x = 140;


    }

    void Update()
    {
        
    }
}
