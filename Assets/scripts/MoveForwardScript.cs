using System;
using UnityEngine;
public class MoveForwardScript : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private float despawnTime = 5;

    private float timer = 0;

    private void Update() {
        timer += Time.deltaTime;
        if(timer >= despawnTime) {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() {
        transform.position += transform.forward * (Time.deltaTime * speed);
    }
}