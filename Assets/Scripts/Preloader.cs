﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour {

    private IEnumerator Start() {
        // The Application loads the Scene in the background at the same time as the current Scene.
        //This is particularly good for creating loading screens. You could also load the Scene by build //number.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        //Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }
}
