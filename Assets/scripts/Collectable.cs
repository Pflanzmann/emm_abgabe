using UnityEngine;

public class Collectable : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            GameObject.Find("Canvas").GetComponent<Points>().AddPoint();
            Destroy(gameObject);
        }
    }
}