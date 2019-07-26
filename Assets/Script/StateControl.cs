using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateControl : MonoBehaviour
{
    public Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
        m_Animator.SetBool("Next", true);
    }

    public void Prev()
    {
        m_Animator.SetBool("Prev", true);
    }

    public void Reset()
    {
        m_Animator.Play("Start", 0, 0f);
    }
}
