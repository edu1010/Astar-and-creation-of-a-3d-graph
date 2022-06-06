using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectOtherNodesTrigger : MonoBehaviour
{
    NodeChecker m_nodeChecker;
    SphereCollider m_collider;
    private void Awake()
    {
        m_nodeChecker = GetComponentInParent<NodeChecker>();
        m_collider = GetComponent<SphereCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        NodePath l_node = other.gameObject.GetComponentInParent<NodePath>();
        if (l_node != null)
        {
            m_nodeChecker.CheckPossibleConection(l_node, m_collider.radius);
        }
    }
}
