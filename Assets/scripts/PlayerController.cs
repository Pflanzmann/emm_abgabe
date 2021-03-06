using UnityEngine;
/// <summary>
/// This class controls the player character via different input types.
///
/// <param name="moveSpeed">The speed the player moves with</param>
/// <param name="rotationAmount">The speed the player rotates around his y axes</param>
/// <param name="mouseRotationMultiplicator">The speed the player rotates around his y axes</param>
///
/// <param name="TouchControlPresenter">The class that gives visual feedback for touch input</param>
/// </summary>
public class PlayerController : MonoBehaviour {
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float rotationAmount = 0.01f;
    [SerializeField] private float mouseRotationMultiplicator = 10;

    [SerializeField] private GameObject projectile;

    private Vector3 mouseDragPosition = Vector3.zero;
    private bool projectileSpawnLeft;
    float angle = 0;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(projectileSpawnLeft) {
                var obj = Instantiate(projectile, transform);
                obj.transform.parent = null;
                obj.transform.position += Vector3.left * 0.6f;
            } else {
                var obj = Instantiate(projectile, transform);
                obj.transform.parent = null;
                obj.transform.position += Vector3.right * 0.6f;
            }

            projectileSpawnLeft = !projectileSpawnLeft;
        }

        if(Input.GetMouseButtonDown(0)) {
            mouseDragPosition = Input.mousePosition;
        }


        if(Input.GetMouseButton(0)) {
            var pos = (mouseDragPosition - Input.mousePosition).normalized;

            transform.Translate(0, 0, Time.deltaTime * moveSpeed * -pos.y);
            transform.Rotate(Vector3.down * (pos.x * 10 * mouseRotationMultiplicator * Time.deltaTime));
            return;
        }

        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        transform.Translate(0, 0, Time.deltaTime * moveSpeed * moveVertical);
        transform.Translate(Time.deltaTime * moveSpeed * moveHorizontal, 0, 0);

        if(Input.GetKey(KeyCode.Q)) {
            angle -= rotationAmount * Time.deltaTime;
        } else if(Input.GetKey(KeyCode.E)) {
            angle += rotationAmount * Time.deltaTime;
        }

        var targetDirection = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        transform.rotation = Quaternion.LookRotation(targetDirection);
    }
}