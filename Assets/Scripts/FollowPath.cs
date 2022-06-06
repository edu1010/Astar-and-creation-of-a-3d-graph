using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AStarCreatePath))]
public class FollowPath : MonoBehaviour
{
    [SerializeField]
    NodePath m_start, m_end;
    [SerializeField]
    float m_speed =2f;
    AStarCreatePath m_createPath;
    List<NodePath> m_path;
    [SerializeField]
    float m_distanceToArrive = 0.5f;
    int m_index = 0;
    bool m_pathFinished = true;
    Vector3 m_dir;
    public bool m_StartPath = false;
    bool m_first = true;
    // Start is called before the first frame update
    void Awake()
    {
        m_createPath = GetComponent<AStarCreatePath>();
    }
    void CalculateDir()
    {
        m_dir = (m_path[m_index].transform.position - transform.position).normalized;
    }
    void Move()
    {
        if(Vector3.Distance(transform.position, m_path[m_index].transform.position)<m_distanceToArrive)
        {
            m_index += 1;
            if(m_index > m_path.Count - 1)
            {
                m_pathFinished = true;
            }
        }
        transform.position += m_dir * m_speed * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (m_StartPath)
        {
            if (m_first) { 
                StartPath();
                m_first = false;
            }
            
            if (m_pathFinished == false)
            {
                CalculateDir();
                Move();

            }
        }
      
    }
    public void StartPath()
    {
        m_path = m_createPath.Inizialize(m_start, m_end);
        m_pathFinished = false;
    }
}
