using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Score : MonoBehaviour {
    private TextMeshProUGUI text;
    private int score = 0;

    private void Awake() {
        Observer.onGetPoints += OnGotPoints;
        Observer.onRestart += OnRestart;
    }

    private void Start() {
        text = GetComponent<TextMeshProUGUI>();
        text.text = score.ToString();
    }

    private void OnDestroy() {
        Observer.onGetPoints -= OnGotPoints;
        Observer.onRestart -= OnRestart;
    }

    private void OnGotPoints(int points) {
        score += points;
        text.text = score.ToString();
    }

    private void OnRestart() {
        score = 0;
        text.text = score.ToString();
    }
}
