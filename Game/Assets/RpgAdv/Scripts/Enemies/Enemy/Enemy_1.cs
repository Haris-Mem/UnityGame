using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;

namespace RpgAdv
{
    public class Enemy_1 : MonoBehaviour, IMessageReceiver
    {

        public PlayerScanner playerScanner;
        public float timeToStopPursuit = 0.5f;
        public float timeToWaitOnPursuit = 2.0f;
        public float attackDistance = 1.1f;

        public bool HasFollowTarget
        {
            get
            {
                return _FollowTarget != null;
            }
        }

        private PlayerController _FollowTarget;
        private EnemyController m_EnemyController;
        
        private Animator m_Animator;
        private float TimeSinceLostTarget = 0;
        private Vector3 originPosition;
        private Quaternion originRotation;
        
        private readonly int HashInPursuit = Animator.StringToHash("InPursuit");
        private readonly int HashNearBase = Animator.StringToHash("NearBase");
        private readonly int HashAttack = Animator.StringToHash("Attack");
        

        private void Awake()
        {
            m_EnemyController = GetComponent<EnemyController>();
            m_Animator = GetComponent<Animator>();

            originPosition = transform.position;
            originRotation = transform.rotation;
        }

        private void Update()
        {
           GuardPosition();
        }

        private void GuardPosition()
        {
            var detectedTarget = playerScanner.Detect(transform);
            bool hasDetectedTarget = detectedTarget != null;

            if (hasDetectedTarget) { _FollowTarget = detectedTarget; }

            if (HasFollowTarget)
            {
                AttackOrFollowTarget();

                if (hasDetectedTarget)
                {
                    TimeSinceLostTarget = 0;
                }
                else
                {
                    StopPursuit();
                }
            }
            CheckIfNearBase();
        }

        public void OnReceiveMessage(MessageType type)
        {
            Debug.Log("Enemy"+type);
        }

        private void AttackOrFollowTarget()
        {
            Vector3 toTarget = _FollowTarget.transform.position - transform.position;
            if (toTarget.magnitude <= attackDistance)
            {
              AttackTarget(toTarget);
            }
            else
            {
                FollowTarget();
            }
        }

        private void StopPursuit()
        {
            TimeSinceLostTarget += Time.deltaTime;
                   
            if (TimeSinceLostTarget >= timeToStopPursuit)
            {
                _FollowTarget = null;
                m_Animator.SetBool(HashInPursuit,false);
                StartCoroutine(WaitBeforeReturn());
            }
        }

        private void AttackTarget(Vector3 toTarget)
        {
            var toTargetRotation = Quaternion.LookRotation(toTarget);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                toTargetRotation,
                360 * Time.deltaTime); 
                
            m_EnemyController.StopFollowTarget();
            m_Animator.SetTrigger(HashAttack);
        }

        private void FollowTarget()
        {
            m_Animator.SetBool(HashInPursuit, true);
            m_EnemyController.FollowTarget(_FollowTarget.transform.position);
        }

        private void CheckIfNearBase()
        {
            Vector3 toBase = originPosition - transform.position;
            toBase.y = 0;

            bool nearBase = toBase.magnitude < 0.01f;
            m_Animator.SetBool(HashNearBase, nearBase);

            if (nearBase)
            {
                Quaternion targetRotation = Quaternion.RotateTowards(
                    transform.rotation,
                    originRotation,
                    360 * Time.deltaTime);

                transform.rotation = targetRotation;
            }
        }

        private IEnumerator WaitBeforeReturn()
        {
            yield return new WaitForSeconds(timeToWaitOnPursuit);
     
            m_EnemyController.FollowTarget(originPosition);
        }

   

        
    }
}

