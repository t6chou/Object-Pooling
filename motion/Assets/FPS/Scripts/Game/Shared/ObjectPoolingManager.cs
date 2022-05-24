using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Unity.FPS.Game
{
    public class ObjectPoolingManager : MonoBehaviour
    {
        private static ObjectPoolingManager instance;
        public static ObjectPoolingManager Instance {get {return instance;}}

        private List<GameObject> bullets;
        public GameObject bulletPrefab;
        public Transform m_SpawnTransform; 
        public int bulletAmount = 20;

        // Start is called before the first frame update
        void Awake()
        {
            instance = this;
            bullets = new List<GameObject>(bulletAmount);

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

            GameObject prefabInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            prefabInstance.transform.SetParent(transform);
            bullets.Add(prefabInstance);

            return prefabInstance;
        }
    }
}
