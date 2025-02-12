using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNode : MonoBehaviour
{
    [SerializeField] private ObjectPool poolShortNode;
    [SerializeField] private ObjectPool poolLongNode;
    public int ID;

    public void SpawnRealNode(NodeData nodeData, float speelFall, float speedScroll)
    {
        if(nodeData.type == TypeNode.ShortNode)
        {
            var shortNode = poolShortNode.GetPooledObject().GetComponent<ShortNode>();
            shortNode.InitData(nodeData.id,true, speelFall);
        }  
        else if(nodeData.type == TypeNode.LongNode)
        {
            var longNode = poolLongNode.GetPooledObject().GetComponent<LongNode>();
            longNode.InitData(nodeData.id,true, speelFall, speedScroll);
        }    
    }   
    public void SpawnFakeNode(NodeData nodeData, float speelFall, float speedScroll)
    {
        if (nodeData.type == TypeNode.ShortNode)
        {
            var shortNode = poolShortNode.GetPooledObject().GetComponent<ShortNode>();
            shortNode.InitData(nodeData.id,false, speelFall);
        }
        else if (nodeData.type == TypeNode.LongNode)
        {
            var longNode = poolLongNode.GetPooledObject().GetComponent<LongNode>();
            longNode.InitData(nodeData.id, false, speelFall, speedScroll);
        }
    }    

    public void ResetNode()
    {
        poolShortNode.ReturnAllObjectToPool();
        poolLongNode.ReturnAllObjectToPool();
    }    

    public void PauseNode()
    {
        for(int i = 0; i< poolShortNode.pooledObjects.Count; i++)
        {
            poolShortNode.pooledObjects[i].GetComponent<ShortNode>().PauseNode();
            poolLongNode.pooledObjects[i].GetComponent<LongNode>().PauseNode();
        }    
    }    
}
