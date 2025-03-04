using UnityEngine;

public class GameManager : MonoBehaviour {
    public int framerate = 60;

    private void Start() {
        Application.targetFrameRate = framerate;
    }
}