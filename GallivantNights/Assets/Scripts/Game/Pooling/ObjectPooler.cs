using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {
   
    [System.Serializable]
    public class Pool {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton
    public static ObjectPooler Pooler_Instance;

    private void Awake() {
        Pooler_Instance = this;      
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> pool_dictionary;

    void Start() {
        pool_dictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools) {
            Queue<GameObject> object_pool = new Queue<GameObject>();

            for (int i = 0; i<pool.size; i++) {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                object_pool.Enqueue(obj);
            }
            pool_dictionary.Add(pool.tag, object_pool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation) {

        if(!pool_dictionary.ContainsKey(tag)) {
            Debug.LogWarning("Pool with tag: "+tag+" does not exist.");
            return null;
        }

        GameObject object_to_spawn = pool_dictionary[tag].Dequeue();
        object_to_spawn.SetActive(true);
        object_to_spawn.transform.position = position;
        object_to_spawn.transform.rotation = rotation;

        I_PooledObject pooled_obj = object_to_spawn.GetComponent<I_PooledObject>();

        pool_dictionary[tag].Enqueue(object_to_spawn);

        return object_to_spawn;
    }
    
}
