using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
public class CreateGraph : MonoBehaviour
{
    [SerializeField]
    GameObject m_node;
    [SerializeField]
    Transform m_StartPosition;
    [SerializeField]
    float m_SeperationBetweenNodes = 0.5f;
    [SerializeField]
    float m_VerticaLength = 20;
    [SerializeField]
    float m_HorizontaLength = 25;
    int counter = 0;
    
    public  bool prefabSuccess;
    private void Start()
    {
        SpawnNodes();
    }
    void SpawnNodes()
    {
        
        int l_quantity = (int)((m_VerticaLength / m_SeperationBetweenNodes) * (m_VerticaLength / m_SeperationBetweenNodes) * (m_VerticaLength / m_SeperationBetweenNodes));
        int l_quantityForRow = (int)(m_VerticaLength / m_SeperationBetweenNodes);
        int l_quantityForCol = (int)(m_HorizontaLength / m_SeperationBetweenNodes);
        for (int z = 0; z < l_quantityForCol; z++)//Pos z
        {
            for (int y = 0; y < l_quantityForRow; y++)
            {
                for (int x = 0; x < l_quantityForCol; x++)
                {
                    Vector3 l_pos = m_StartPosition.position + new Vector3(x * m_SeperationBetweenNodes, y * m_SeperationBetweenNodes, z * m_SeperationBetweenNodes);
                    GameObject go = Instantiate(m_node, l_pos, Quaternion.identity, m_StartPosition);
                    go.name = counter.ToString();
                    counter++;
                }
            }
        }
#if UNITY_EDITOR
        StartCoroutine(CreatePrefab());//We wait one second to allow nodes calculate their conections and store this info also in the prefab
#endif
    }

    IEnumerator CreatePrefab()
    {
        yield return new WaitForSeconds(1f);
        if (!Directory.Exists("Assets/Prefabs"))
        {
            AssetDatabase.CreateFolder("Assets", "Prefabs");
        }
        string localPath = "Assets/Prefabs/" + m_StartPosition.name + ".prefab";
        // Make sure the file name is unique, in case an existing Prefab has the same name.
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
        // Create the new Prefab and log whether Prefab was saved successfully.
        bool l_prefabSuccess;
        PrefabUtility.SaveAsPrefabAsset(m_StartPosition.gameObject, localPath, out l_prefabSuccess);
        if (l_prefabSuccess == true)
            Debug.Log("Prefab was saved successfully");
        else
            Debug.Log("Prefab failed to save" + l_prefabSuccess);
    }
}
