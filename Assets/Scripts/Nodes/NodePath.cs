using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class NodePath : MonoBehaviour
{
    public List<NodePath> m_Conections = new List<NodePath>();
    public float cost = 1f;
    public void AddConection(NodePath nodePath)
    {
        m_Conections.Add(nodePath);
        m_Conections.Distinct();
       
    }
}
