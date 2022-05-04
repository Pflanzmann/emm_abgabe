using UnityEngine;

/// <summary>
/// This class moves its GameObejct to a random position nearby,
/// with a random wait time after it reached the position
///
/// <param name="idleMovementSpeed">The speed the GameObject walks when in idle</param>
/// <param name="idleMovementRadius">The distance the GameObjects goes again when it idles </param>
/// <param name="minIdleTimer">The min time between idle operations</param>
/// <param name="maxIdleTimer">The max time between idle operations</param>
/// </summary>
public class IdleOperator : MonoBehaviour {
    [SerializeField] private int idleMovementSpeed = 10;
    [SerializeField] private int idleMovementRadius = 1;
    [SerializeField] private float minIdleTimer = 1;
    [SerializeField] private float maxIdleTimer = 1;

    private Vector3 idleMovementLocation;
    private float currentTimer;

    private void Start() {
        idleMovementLocation = transform.position;
        currentTimer = Random.Range(minIdleTimer, maxIdleTimer);
    }

    private void Update() {
        if(Vector3.Distance(transform.position, idleMovementLocation) > 0.5f) {
            Transform transform1;
            (transform1 = transform).LookAt(new Vector3(idleMovementLocation.x, transform1.position.y, idleMovementLocation.z));
            transform1.position += (idleMovementLocation - transform1.position).normalized * (Time.deltaTime * idleMovementSpeed);
        } else {
            if(currentTimer > 0) {
                currentTimer -= Time.deltaTime;
            } else {
                currentTimer = Random.Range(minIdleTimer, maxIdleTimer);
                idleMovementLocation = transform.position +
                                       new Vector3(
                                           Random.Range(-idleMovementRadius, idleMovementRadius + 1),
                                           0,
                                           Random.Range(-idleMovementRadius, idleMovementRadius + 1)
                                       );
            }
        }
    }
}