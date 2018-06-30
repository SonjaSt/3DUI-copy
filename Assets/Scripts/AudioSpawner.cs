using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpawner : MonoBehaviour {

    public GameObject prefab;
    public Transform spawnTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("j"))
        {
            Instantiate(prefab, spawnTransform.position, spawnTransform.rotation);
        }
	}
}
