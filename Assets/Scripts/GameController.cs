using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * No actual use yet. Idk what to do with it for now.                   *
 * Only holds the world and instaniates the crosshair inside the world. */
public class GameController : MonoBehaviour {

    public static GameController instance = null;
    public World world;
    public CinemachineVirtualCamera vCam;
    public Crosshair crosshair;
    public DreamBar dreamBar;

    private int maxLevel;
    private int levelCounter;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    private void Start() {
        if (world == null) {
            world = Instantiate(world, transform.position, transform.rotation);
        }

        crosshair = Instantiate(crosshair, world.transform);

        levelCounter = 1;
        maxLevel = 1;
    }

    public void Captured(float amount) {
        dreamBar.Fill(amount);
    }

    public void Full(bool isFull) {
        if (isFull && levelCounter >= maxLevel) {
            SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
        } else {
            //TODO Move to next level
        }
    }

    public void PlayerDead(bool isDead) {
        if (isDead) {
            world.Clean();
            world.currentPlayer = null;
            SceneManager.LoadScene("LoseScene", LoadSceneMode.Single);
        }
    }
}
