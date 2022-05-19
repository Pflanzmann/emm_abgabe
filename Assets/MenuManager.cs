using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour {
    [SerializeField] private GameObject pauseMenu;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(!pauseMenu.activeSelf) {
                PauseGame();
            } else {
                UnpauseGame();
            }
        }
    }

    public void PauseGame() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnpauseGame() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void DoRestartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}