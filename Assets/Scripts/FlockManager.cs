using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlockManager : MonoBehaviour {

    public static FlockManager Instance;
    public GameObject boidPrefab;
    public int numBoid = 20;
    public GameObject[] allBoid;
    public Vector3 limits = new Vector3(5.0f, 5.0f, 5.0f);
    public Vector3 goalPos = Vector3.zero;
    public float avoidanceThreshold = 1.0f;

    [Header("Boid Settings")]
    [Range(0f, 60f)] public float minSpeed;
    [Range(0f, 60f)] public float maxSpeed;
    [Range(0.1f, 10f)] public float neighbourDistance;
    [Range(1.0f, 25f)] public float rotationSpeed;

    void Start() {

        allBoid = new GameObject[numBoid];

        for (int i = 0; i < numBoid; ++i) {

            Vector3 pos = this.transform.position + new Vector3(
                Random.Range(-limits.x, limits.x),
                Random.Range(-limits.y, limits.y),
                Random.Range(-limits.z, limits.z));

            allBoid[i] = Instantiate(boidPrefab, pos, Quaternion.identity);
        }

        Instance = this;
        goalPos = transform.position;
    }


    void Update() {

        if (Random.Range(0, 100) < 10) {

            goalPos = this.transform.position + new Vector3(
                Random.Range(-limits.x, limits.x),
                Random.Range(-limits.y, limits.y),
                Random.Range(-limits.z, limits.z));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireCube(transform.position, limits * 2);
    }
}