using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateControl : MonoBehaviour
{
    public Animator m_Animator;
    private string[] m_States = { "BLEND_White Cube", "BLEND_Rods", "BLEND_Teal Cylinder Rotates",
        "BLEND_Teal Cylinder + Box + Small Black Top", "BLEND_Bucket", "BLEND_R + B Wire",
        "BLEND_D Grey Lid Rotate + R + B Plugs", "BLEND_D Grey Lid + Body", "BLEND_Silver Wire",
        "BLEND_Film Peel", "BLEND_Film", "BLEND_Small Cup", "BLEND_Liquid"};
    private int m_CurrentState;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentState = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
        //m_Animator.SetBool("Next", true);
        if (m_CurrentState < m_States.Length - 1)
        {
            m_CurrentState++;
            m_Animator.Play(m_States[m_CurrentState] + " Start", 0, 0f);
        }
    }

    public void Prev()
    {
        //m_Animator.SetBool("Prev", true);
        if (m_CurrentState > -1)
        {    
            m_Animator.Play(m_States[m_CurrentState] + " End", 0, 0f);
            m_CurrentState--;
        }
    }

    public void Reset()
    {
        m_Animator.Play("Start", 0, 0f);
        m_CurrentState = -1;
    }
}
