using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager {

    public static Level currentLevel = null;
    
    public static void loadLevel(Level level) {
        LevelManager.currentLevel = level;
        World.width = level.width;
        World.height = level.height;
        World.lilypads = level.lilypads.Clone() as int[,];
        World.fireflies = level.fireflies.Clone() as int[,];
        SceneManager.LoadScene("Level");
    }

    public static void reloadLevel() {
        LevelManager.loadLevel(LevelManager.currentLevel);
    }
}
