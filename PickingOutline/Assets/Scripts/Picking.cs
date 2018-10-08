using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picking : MonoBehaviour {

    string m_strShaderName = "Outlined/UltimateOutline";
    // string m_basicShader = "Mobile/Unlit (Supports Lightmap)";
    string m_basicShader = "Standard";
    bool m_bSelected = false;
    GameObject m_SelectedObject;
    private void Start()
    {
       GameObject[] m_MyObjects =  GameObject.FindGameObjectsWithTag("Player");
      
  
       
    }
    private void Update()
    {
       // if(Input.GetMouseButtonDown(0))
        {
            

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit) && hit.transform.tag == "Player") //충돌과 태그가 플레이어 것일 때
            {
                if(!m_SelectedObject) //아직 선택하지 않았다면
                {
                    SkinnedMeshRenderer mr = hit.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
                    mr.material.shader = Shader.Find(m_strShaderName);

                   // mr.material.shader = Shader.Find(m_basicShader);
                    m_SelectedObject = hit.transform.gameObject;
                }
                else //이미 선택된 객체가 있을 경우
                {
                    if(m_SelectedObject != hit.transform.gameObject) //옛날에 선택했던것과 다르다면
                    {
                        SkinnedMeshRenderer mr = m_SelectedObject.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
                        mr.material.shader = Shader.Find(m_basicShader);


                        mr = hit.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
                        mr.material.shader = Shader.Find(m_strShaderName);             
                        m_SelectedObject = hit.transform.gameObject;
                    }
                }
              
            }
            else //광선이 게임 오브젝트에 닿지 않은다면.  //
            {
                if(m_SelectedObject)
                {
                    SkinnedMeshRenderer mr = m_SelectedObject.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
                    mr.material.shader = Shader.Find(m_basicShader);
                    m_SelectedObject = null;
                }
            }
        }
    }
    void SelectCharacter()
    {

    }
}
