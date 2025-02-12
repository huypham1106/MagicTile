using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool, this.gameObject.transform);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.transform.SetParent(this.transform);
        obj.transform.localPosition = Vector3.zero;
        obj.SetActive(false);
    }

    public void ReturnAllObjectToPool()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            pooledObjects[i].transform.SetParent(this.transform);
            pooledObjects[i].SetActive(false);
        }
    }
}
