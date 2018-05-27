using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour {
    public float travelTime = 0.075f;
    private SpriteRenderer rend;
    private bool canMove = true;

    private static Player reference;
    public static Player instance {
        get {
            if (!reference) {
                reference = FindObjectOfType<Player>();
            }
            return reference;
        }
    }

    private void Awake() {
        reference = FindObjectOfType<Player>();
        Observer.onRestart += OnRestart;
        Observer.onGameOver += OnGameOver;

        Observer.onGotEnemy += OnGotEnemy;
    }

    private void Start() {
        rend = GetComponent<SpriteRenderer>();
    }

    private void OnDestroy() {
        reference = null;
        Observer.onRestart -= OnRestart;
        Observer.onGameOver -= OnGameOver;

        Observer.onGotEnemy -= OnGotEnemy;
    }

    private void OnRestart() {
        transform.position = Vector2.zero;
        canMove = true;
    }

    private void OnGameOver() {
        LeanTween.cancel(gameObject);
    }

    private void OnGotEnemy(Enemy enemy) {
        if (!canMove) return;
        LeanTween.move(gameObject, enemy.transform.position, travelTime * Mathf.Clamp01(Vector2.Distance(transform.position, enemy.transform.position)))
                 .setEase(LeanTweenType.easeInOutQuad)
                 .setOnStart(() => {
                     canMove = false;
                 }).setOnComplete(() => {
                     canMove = true;
                     enemy.gameObject.SetActive(false);
                     Observer.OnGetPoints(1);
                 });
    }
}
