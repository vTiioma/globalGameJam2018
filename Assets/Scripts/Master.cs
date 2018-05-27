using SonicBloom.Koreo;
using UnityEngine;

public class Master : MonoBehaviour {
    [EventID]
    public string gameOverEventID;
    public AudioSource music;
    public GameObject startGameScreen;
    public GameObject gameOverScreen;
    public GameObject scoreText;
    private Camera cam;

    private static Master reference;
    public static Master instance {
        get {
            if (!reference) {
                reference = FindObjectOfType<Master>();
            }
            return reference;
        }
    }

    private void Awake() {
        Application.targetFrameRate = 60;
        Input.multiTouchEnabled = false;
        reference = FindObjectOfType<Master>();
    }

    private void Start() {
        cam = Camera.main;
        Observer.onGotEnemy += OnGotEnemy;
        Koreographer.Instance.RegisterForEvents(gameOverEventID, GameOver);
        gameOverScreen.SetActive(false);
        scoreText.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

        if (Input.GetMouseButtonDown(0)) {
            Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            Observer.OnTap(pos);
        }
    }

    private void OnDestroy() {
        reference = null;
    }

    private void OnGotEnemy(Enemy enemy) {
        Observer.onGotEnemy -= OnGotEnemy;
        music.Play();
        startGameScreen.SetActive(false);
        scoreText.SetActive(true);
    }

    public void Restart() {
        music.Play();
        gameOverScreen.SetActive(false);
        scoreText.SetActive(true);
    }

    private void GameOver(KoreographyEvent e) {
        music.Stop();
        gameOverScreen.SetActive(true);
        scoreText.SetActive(false);
    }
}
