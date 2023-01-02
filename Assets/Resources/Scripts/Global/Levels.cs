using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Level {

    public static char[] completed;
    private static string path = "Assets/Resources/Data/levelsComplete.txt";

    static Level() {
        StreamReader reader = new StreamReader(Level.path);
        Level.completed = reader.ReadToEnd().ToCharArray();
        reader.Close();
    }

    public static void updateCompleted() {
        StreamWriter writer = new StreamWriter(Level.path, false);
        writer.Write(new string(Level.completed));
        writer.Close();
    }
    
    public int id;
    public int width;
    public int height;
    public Vector2 start;
    public int[,] lilypads;
    public int[,] fireflies;

    public Level(int id, int width, int height, Vector2 start, int[,] lilypads, int[,] fireflies) {
        this.id = id;
        this.width = width;
        this.height = height;
        this.start = start;
        this.lilypads = lilypads;
        this.fireflies = fireflies;
    }
}

public class Levels {

    public static Level test = new Level(0,
        3, 3,
        new Vector2(0, 0),
        new int[,] { 
            { 2, 2, 1 },
            { 2, 2, 0 },
            { 1, 0, 0 },
        },
        new int[,] { 
            { 0, 0, 1 },
            { 0, 2, 0 },
            { 1, 0, 0 },
        }
    );
}
