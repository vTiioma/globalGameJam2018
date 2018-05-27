using SonicBloom.Koreo;
using UnityEngine;

public class TargetParent : MonoBehaviour {
    [EventID]
    public string showID;
    private Transform[] patterns;

    private void Awake() {
        Observer.onRestart += OnRestart;
        Observer.onGameOver += OnGameOver;
    }

    private void Start() {
        Koreographer.Instance.RegisterForEvents(showID, FindPattern);
        patterns = Resources.LoadAll<Transform>("Target Formations");
    }

    private void OnDestroy() {
        
    }

    private void OnRestart() {

    }

    private void OnGameOver() {

    }

    private void FindPattern(KoreographyEvent e) {
        int index = Random.Range(0, patterns.Length);
        Transform pattern = patterns[index];
        Observer.OnPatternSelected(pattern.GetComponentsInChildren<Transform>());

        transform.localEulerAngles = Vector3.forward * Random.Range(0, 360);
    }
}
