using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {
    private static ObjectPooler instance;
    public static ObjectPooler Instance {
        get { return instance; }
    }

    public GameObject bulletPrefab;
    public int bulletAmount = 20;

    private List<GameObject> bullets;

    // Start is called before the first frame update
    void Awake() {
        instance = this;
        this.GetBullet();
        bullets = new List<GameObject>(bulletAmount);

        for (int i = 0; i < bulletAmount; i++){
            GameObject prefabInstance = Instantiate(bulletPrefab);
            prefabInstance.transform.SetParent(transform);
            prefabInstance.SetActive(false);

            bullets.Add(prefabInstance);

        }
    }

    // Update is called once per frame
    public GameObject GetBullet() {
        Debug.Log("Hello!");
        return null;

        // foreach (GameObject bullet in bullets) {
        //     if (bullet.activeInHierarchy) {
        //         bullet.SetActive(true);
        //         return bullet;
        //     }
        // } 

        // GameObject prefabInstance = Instantiate(bulletPrefab);
        // prefabInstance.transform.SetParent(transform);
        // bullets.Add(prefabInstance);

        // return prefabInstance;
    }   
}
