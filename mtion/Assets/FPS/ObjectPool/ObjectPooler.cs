using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Unity.FPS.Game
{
    public class ObjectPooler : MonoBehaviour
    {
        //Shared Instance
        private static ObjectPooler instance;
        public static ObjectPooler Instance {get {return instance;}}

        //Object pool list
        private List<GameObject> projectiles;

        //Public Components Parameters
        public GameObject projectilePrefab;
        public int projectileAmount = 10;

        void Awake()
        {
            instance = this;
            projectiles = new List<GameObject>(projectileAmount);

            // pool object in background
            for (int i = 0; i < projectileAmount; i++){
                GameObject prefabInstance = Instantiate(projectilePrefab);
                prefabInstance.transform.SetParent(transform);
                prefabInstance.SetActive(false);

                projectiles.Add(prefabInstance);
            }
        }

        // Update is called once per frame
        public GameObject GetProjectile()
        {
            //Iterate and activating object if not already active
            foreach (GameObject projectile in projectiles) {
                if (!projectile.activeInHierarchy) {
                    projectile.SetActive(true);
                    return projectile;
                }
            } 

            // GameObject projectile = projectiles.Dequeue();
            // if (!projectile.activeInHierarchy) {
            //     projectile.SetActive(true);
            //     projectiles.Enqueue(projectile);
            //     return projectile;
            // } else {
            //     projectiles.Enqueue(projectile);
            //     return null;
            // }

            // create new instance when object pool used up
            GameObject prefabInstance = Instantiate(projectilePrefab);
            prefabInstance.transform.SetParent(transform);
            projectiles.Add(prefabInstance);

            return prefabInstance;
        }
    }
}
