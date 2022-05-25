using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolStandard : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public float bulletDuration = 2f;

    private float timer;
    // Start is called before the first frame update
     void OnEnable() {
        timer = bulletDuration;
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;

        timer -= Time.deltaTime;
        if (timer <= 0f) {
            gameObject.SetActive(false);
        }
    }
}
