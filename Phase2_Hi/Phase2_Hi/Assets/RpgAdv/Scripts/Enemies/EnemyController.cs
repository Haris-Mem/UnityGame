using RpgAdv;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IAttackAnimListener
{
    public Animator animator
    {
        get { return m_Animator; }
    }

    private NavMeshAgent m_NavMeshAgent;
    private Animator m_Animator;

    private float m_SpeedMultiplier = 0.7f;
    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnAnimatorMove()
    {
        if (m_NavMeshAgent.enabled)
        {
            m_NavMeshAgent.speed = (m_Animator.deltaPosition / Time.fixedDeltaTime).magnitude * m_SpeedMultiplier;
        }

        
    }

    public bool FollowTarget(Vector3 position)
    {
        if (!m_NavMeshAgent.enabled)
        {
            m_NavMeshAgent.enabled = true;
        }
        return m_NavMeshAgent.SetDestination(position);
    }

    public void StopFollowTarget()
    {
        m_NavMeshAgent.enabled = false;
    }

    public void MeleeAttackStart()
    {
        
    }

    public void MeleeAttackEnd()
    {
       
    }
}
