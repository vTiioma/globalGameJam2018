using System;
using UnityEngine;

public class Observer : MonoBehaviour {
    public static event Action onRestart;
    public static event Action onGameOver;
     
    public static event Action<Vector2> onTap;
    public static event Action<Enemy> onGotEnemy;

    public static event Action<int> onGetPoints;

    public static event Action<Transform[]> onPattrenSelected;

    public static event Action onRevealEnemies;
    public static event Action onShowEnemies;
    public static event Action onPrepEnemies;
    public static event Action onHideEnemies;

    public static void OnRestart() {
        if (onRestart != null) {
            onRestart();
        }
    }

    public static void OnGameOver() {
        if (onGameOver != null) {
            onGameOver();
        }
    }

    public static void OnTap(Vector2 pos) {
        if (onTap != null) {
            onTap(pos);
        }
    } 

    public static void OnGotEnemy(Enemy enemy) {
        if (onGotEnemy != null) {
            onGotEnemy(enemy);
        }
    }

    public static void OnGetPoints(int points) {
        if (onGetPoints != null) {
            onGetPoints(points);
        }
    }

    public static void OnPatternSelected(Transform[] items) {
        if (onPattrenSelected != null) {
            onPattrenSelected(items);
        }
    } 

    public static void OnRevealEnemies() {
        if (onRevealEnemies != null) {
            onRevealEnemies();
        }
    }

    public static void OnShowEnemies() {
        if (onShowEnemies != null) {
            onShowEnemies();
        }
    }

    public static void OnPrepEnemies() {
        if (onPrepEnemies != null) {
            onPrepEnemies();
        }
    }

    public static void OnHideEnemies() {
        if (onHideEnemies != null) {
            onHideEnemies();
        }
    }
}
