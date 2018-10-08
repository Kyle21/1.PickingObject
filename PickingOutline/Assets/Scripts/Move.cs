using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private Rigidbody m_Rigidbody;
    private Transform m_Transform;
    private Vector3 m_vMovement;
    private bool m_bRotated = false;
    private Vector3 m_vDir;


    public float m_fRotationSpeed = 360.0f;
    public Vector3 m_vDestination;
    public float m_fSpeed = 2.0f;
    public float fStoppingDistance = 2.0f;


    // Use this for initialization
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Transform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        // m_Transform.

    }
    void FixedUpdate()
    {
        Rotate();
        Walk();
    }

    void Walk()
    {
        //m_vMovement.Set(m_vDir);
        // 식이 별로 보기 좋지 않으니 깔끔하게 수정할것.
        if (!m_bRotated)
        {
            return;
        }
        float fDistance = Vector3.Distance(transform.position, m_vDestination);
        if (fDistance < fStoppingDistance)
            return;
        // 식이 별로 보기 좋지 않으니 깔끔하게 수정할것.
        m_vMovement.x = m_vDir.x;
        m_vMovement.y = 0.0f; ;
        m_vMovement.z = m_vDir.z;
        m_vMovement = m_vMovement.normalized * m_fSpeed * Time.deltaTime;
        m_Rigidbody.MovePosition(transform.position + m_vMovement);



    }
    void Rotate()
    {
        if (m_bRotated) //회전을 했다면
            return;
        Vector3 vPos = m_Transform.position;
        vPos.y = 0; //y축 고려안함
        m_vDir = (m_vDestination - vPos).normalized;


        //  float fAngle = Vector3.Dot(vDir, vPos.normalized);

        Quaternion characterTargetRotation = Quaternion.LookRotation((m_vDestination - vPos).normalized);
        m_Rigidbody.MoveRotation(characterTargetRotation);


        float angle = Vector3.Dot(m_Transform.right, m_vDir);
        if (Vector3.Dot(m_Transform.right, m_vDir) < 0.1f)
        {
            m_bRotated = true;
        }


    }
}
