using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooled : MonoBehaviour {

    public static BulletPooled instance;
    public GameObject pooledBullet;

    public int pooledAmount = 30;
    public bool willGrow = false;

    List<GameObject> pooledBullets;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pooledBullets = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledBullet);
            obj.transform.parent = GameObject.Find("Dynamic").transform;
            obj.SetActive(false);
            pooledBullets.Add(obj);
        }
    }

    public GameObject GetPooledBullet()
    {
        for (int i = 0; i < pooledBullets.Count; i++)
        {
            if (!pooledBullets[i].activeInHierarchy)
            {
                return pooledBullets[i];
            }
        }

        if (willGrow)
        {
            GameObject obj = Instantiate(pooledBullet);
            pooledBullets.Add(obj);
            return obj;
        }

        return null;
    }
}
