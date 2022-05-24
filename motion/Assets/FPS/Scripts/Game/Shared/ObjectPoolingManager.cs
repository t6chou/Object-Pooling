using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Unity.FPS.Game
{
    public class ObjectPoolingManager : MonoBehaviour
    {
        //Shared Instance
        private static ObjectPoolingManager instance;
        public static ObjectPoolingManager Instance {get {return instance;}}

        //Object pool list
        private List<GameObject> bullets;

        //Public Components Parameters
        public GameObject bulletPrefab;
        public Transform m_SpawnTransform; 
        public int bulletAmount = 5;

        void Awake()
        {
            instance = this;
            bullets = new List<GameObject>(bulletAmount);

            // pool object in background
            for (int i = 0; i < bulletAmount; i++){
                GameObject prefabInstance = Instantiate(bulletPrefab);
                prefabInstance.transform.SetParent(transform);
                prefabInstance.SetActive(false);

                bullets.Add(prefabInstance);
            }
        }

        // Update is called once per frame
        public GameObject GetBullet()
        {
            foreach (GameObject bullet in bullets) {
                if (!bullet.activeInHierarchy) {
                    bullet.SetActive(true);
                    return bullet;
                }
            } 

            GameObject prefabInstance = Instantiate(bulletPrefab);
            prefabInstance.transform.SetParent(transform);
            bullets.Add(prefabInstance);

            return prefabInstance;
        }
    }
}
