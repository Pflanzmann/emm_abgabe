using UnityEngine;

/// <summary>
/// This class controls the monster and how it interacts when the collider detects the player.
/// This script also requires an IdleOperator on the same GameObject.
///
/// This class tracks the player when he is inside the collider
/// and follows him with its GameObject
///
/// <param name="speed">The speed the monster moves with</param>
/// <param name="collisionDistance">The distance when the monster collides with the player</param>
/// <param name="damage">The damage the monster does to the player</param>
/// </summary>
[RequireComponent(typeof(IdleOperator))]
public class Monster : MonoBehaviour {
    [SerializeField] private float speed = 10;
    [SerializeField] private float collisionDistance = 1;
    [SerializeField] private int damage = 1;

    private IdleOperator idleOperator;

    private GameObject player;
    private Animation animationComponent;
    private bool hasPlayer;

    private void Start() {
        hasPlayer = player != null;
        player = null;
        idleOperator = GetComponent<IdleOperator>();
        animationComponent = GetComponent<Animation>();
    }

    private void Update() {
        if(hasPlayer) {
            HasPlayer();
        }
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Projectile") {
            if(Vector3.Distance(other.transform.position, transform.position) < collisionDistance) {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            player = other.gameObject;
            hasPlayer = true;
            idleOperator.enabled = false;

            animationComponent.Play();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") {
            player = null;
            hasPlayer = false;
            idleOperator.enabled = true;
        }
    }

    private void HasPlayer() {
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

        transform.position += (player.transform.position - transform.position).normalized * (Time.deltaTime * speed);

        if(Vector3.Distance(player.transform.position, transform.position) < collisionDistance) {
            Destroy(gameObject);
        }
    }
}