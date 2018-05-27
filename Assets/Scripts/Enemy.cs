using SonicBloom.Koreo;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour {
    [EventID]
    public string showID;
    [EventID]
    public string hideID;

    private SpriteRenderer rend;

    private void Awake() {
        Observer.onRestart += OnRestart;
        Observer.onGameOver += OnGameOver;

        Observer.onTap += OnTap;
        Observer.onPattrenSelected += OnPattrenSelected;
    }

    private void Start() {
        rend = GetComponent<SpriteRenderer>();
        Koreographer.Instance.RegisterForEvents(showID, ShowSelf);
        Koreographer.Instance.RegisterForEvents(hideID, HideSelf);
        if (transform.localPosition == Vector3.zero) {
            gameObject.SetActive(false);
        }

    }

    private void OnDestroy() {
        Observer.onRestart -= OnRestart;
        Observer.onGameOver -= OnGameOver;

        Observer.onTap -= OnTap;
        Observer.onPattrenSelected -= OnPattrenSelected;
    }

    private void OnTap(Vector2 pos) {
        if (!gameObject.activeSelf) {
            return;
        }
        if (Vector2.Distance(pos, transform.position) < 1f) {
            Observer.OnGotEnemy(this);
        }
    }

    private void OnPattrenSelected(Transform[] pattern) {
        Transform item = pattern.FirstOrDefault(x => x.name == transform.name);
        if (item == null) {
            transform.position = Vector2.one * 1000;
        } else {
            transform.localPosition = item.localPosition;
        }
    }

    private void OnRestart() {
        gameObject.SetActive(false);
    }

    private void OnGameOver() {
        
    }

    private void ShowSelf(KoreographyEvent e) {
        gameObject.SetActive(true);
    }

    private void HideSelf(KoreographyEvent e) {
        gameObject.SetActive(false);
    }
}
