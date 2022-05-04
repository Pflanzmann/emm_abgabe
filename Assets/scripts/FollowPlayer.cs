using UnityEngine;

/// <summary>
/// This class moves the camera to a predefined destination
/// and moves it smoothly
///
/// <param name="cameraPos">The target position to follow</param>
/// <param name="player">The object to fix the camera onto</param>
/// <param name="maxDistance">The max distance between the cameraPos and the camera</param>
/// <param name="maxSpeed">The following max speed of the camera</param>
/// <param name="playerOffset">The offset for the camera that gets added to the player position</param>
/// </summary>
public class FollowPlayer : MonoBehaviour {
    [SerializeField] private GameObject cameraPos;
    [SerializeField] private GameObject player;
    [SerializeField] private float maxDistance = 0.2f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float playerOffset = 2f;

    private void LateUpdate() {
        var speed = maxSpeed * (maxDistance / 100f * Vector3.Distance(transform.position, cameraPos.transform.position));
        if(Vector3.Distance(transform.position, cameraPos.transform.position) > .5f)
            transform.position += (cameraPos.transform.position - transform.position).normalized * (Time.deltaTime * speed);
        transform.LookAt(player.transform.position + Vector3.up * playerOffset);
    }
}