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
    [SerializeField] private float rotationAmount = 10;
    [SerializeField] private float mouseRotationMultiplicator = 10;

    [SerializeField] private GameObject projectile;

    private Vector3 mouseDragPostion = Vector3.zero;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            var obj = Instantiate(projectile, transform);
            obj.transform.parent = null;
        }

        if(Input.GetMouseButtonDown(0)) {
            mouseDragPostion = Input.mousePosition;
        }


        if(Input.GetMouseButton(0)) {
            var pos = (mouseDragPostion - Input.mousePosition).normalized;

            transform.Translate(0, 0, Time.deltaTime * moveSpeed * -pos.y);
            transform.Rotate(Vector3.down * (pos.x * 10 * mouseRotationMultiplicator * Time.deltaTime));
            return;
        }

        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        transform.Translate(0, 0, Time.deltaTime * moveSpeed * moveVertical);
        transform.Translate(Time.deltaTime * moveSpeed * moveHorizontal, 0, 0);

        if(Input.GetKey(KeyCode.Q)) {
            transform.Rotate(Vector3.down * (rotationAmount * 10 * Time.deltaTime));
        } else if(Input.GetKey(KeyCode.E)) {
            transform.Rotate(Vector3.up * (rotationAmount * 10 * Time.deltaTime));
        }
    }
}