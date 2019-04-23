using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {
    public static ObjectPooler current;
    public GameObject pooled_object;
    public int pooled_capacity;
    public bool should_expand = true;

    List<GameObject> pooled_objects;

    void Awake() {
        current = this;
    }

    // Use this for initialization
    void Start() {
        pooled_objects = new List<GameObject>();
        for (int i = 0; i < pooled_capacity; i++) {
            GameObject obj = (GameObject)Instantiate(pooled_object);
            obj.SetActive(false);
            pooled_objects.Add(obj);
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < pooled_objects.Count; i++) {
            if (!pooled_objects[i].activeInHierarchy) {
                return pooled_objects[i];
            }
        }
        if (should_expand) {
            GameObject obj = (GameObject)Instantiate(pooled_object);
            pooled_objects.Add(obj);
            return obj;
        }
        return null;
    }
}
