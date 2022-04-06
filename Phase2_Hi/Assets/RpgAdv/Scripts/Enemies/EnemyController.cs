using System.Collections;
using System.Collections.Generic;
using RpgAdv;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IAttackAnimListener
{
// properties 
    public Animator Animator { get { return m_Animator; } }

// variable declarations
    private NavMeshAgent m_NavMeshAgent;
    private Animator m_Animator;
    private float m_SpeedModifier = 0.7f;

// this method runs once at the start of the scene 
    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
    }


    private void OnAnimatorMove()
    {
        if (m_NavMeshAgent.enabled)
        {
            m_NavMeshAgent.speed =
                (m_Animator.deltaPosition / Time.fixedDeltaTime).magnitude * m_SpeedModifier;
        }
    }
// gives enemy the ability to follow the player
    public bool FollowTarget(Vector3 position)
    {
        if (!m_NavMeshAgent.enabled) { m_NavMeshAgent.enabled = true; }
        return m_NavMeshAgent.SetDestination(position);
    }

// the enemy will stop following based on the proximity to the player 
    public void StopFollowTarget()
    {
        m_NavMeshAgent.enabled = false;
    }
// start attack
    public void MeleeAttackStart() { }
    // end attack
    public void MeleeAttackEnd() { }
}
