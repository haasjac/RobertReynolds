using System;
using UnityEngine;
//Unity's standard follow script
    public class Camera2DFollow : MonoBehaviour
    {
        public Vector3 target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;

        // Use this for initialization
        private void Start()
        {
            target = Top.S.transform.position;
            m_LastTargetPosition = target;
            m_OffsetZ = (transform.position - target).z;
            transform.parent = null;
        }


        // Update is called once per frame
        private void Update()
        {
            if (UI.S.together)
            {
                target = Top.S.transform.position;
            }
            else
            {
                target = (Top.S.transform.position + Bottom.S.transform.position / 2f);
            }
        // only update lookahead pos if accelerating or changed direction
        float xMoveDelta = (target - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target + m_LookAheadPos + Vector3.forward*m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

            transform.position = newPos;

            m_LastTargetPosition = target;
    }
}
