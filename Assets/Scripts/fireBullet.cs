using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour {

    public GameObject bullet;
    public Transform spawnPoint; 

	void FixedUpdate () {
        //Fire if left clicked
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        }
	}
}
