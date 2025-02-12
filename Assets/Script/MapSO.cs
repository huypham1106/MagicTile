using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Map", menuName = "Map SO")]
public class MapSO : ScriptableObject
{
    public new int level;
    public int start1;
    public int start2;
    public int start3;
    public float speedFall;
    public float speedScroll;
    public float totalTime;
    public List<NodeData> nodeDataList;

    [ContextMenu ("Generate Index Node")]
    private void UpdateIndexNode()
    {
        nodeDataList[0].touchIndex = 0;
        nodeDataList[0].id = 0;
        int index = 0;
        for(int i=1; i<nodeDataList.Count;i++)
        {
            NodeData nodeBefore = nodeDataList[i-1];
            NodeData node = nodeDataList[i];
            if(nodeBefore.time != node.time)
            {
                index++;
            }
            node.touchIndex = index;
            node.id = i;
        }
        start3 = (nodeDataList.Count * 3 ) - 20;
        start1 = (start3 / 3 ) - 20;
        start2 = (start3 - start1)-20;

#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }
}

[Serializable]
public class NodeData
{
    public int id;
    public List<int> line;
    public TypeNode type;
    public float time;
    public float height;
    public int touchIndex;

}


