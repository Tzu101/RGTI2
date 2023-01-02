using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    void OnMouseDown() {
       LevelManager.loadLevel(Levels.test);
   }
}
