using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World {
    public static int width = 0;
    public static int height = 0;

    public static float gridToUnit = 7.5f;

    public static int[,] lilypads = new int[,] {};
    public static int[,] fireflies = new int[,] {};

    public static bool hasLilypad(int posX, int posZ) {

        if (posX < 0 || posX >= World.width || posZ < 0 || posZ >= World.height) {
            return false;
        }

        return World.lilypads[posX, posZ] > 0;
    }

    public static int lilypadType(int posX, int posZ) {

        return World.lilypads[posX, posZ];
    }

    public static bool hasFirefly(int posX, int posZ) {

        if (posX < 0 || posX >= World.width || posZ < 0 || posZ >= World.height) {
            return false;
        }

        return World.fireflies[posX, posZ] > 0;
    }

    public static bool hasFireflyQueen(int posX, int posZ) {

        if (posX < 0 || posX >= World.width || posZ < 0 || posZ >= World.height) {
            return false;
        }

        return World.fireflies[posX, posZ] > 1;
    }

    public static void jumpedFrom(int posX, int posZ) {
        if (World.lilypads[posX, posZ] > 0) {
            World.lilypads[posX, posZ] -= 1;
            EntityManager.updateLilypad(posX, posZ);
        }
    }

    public static void landedOn(int posX, int posZ) {
        if (World.fireflies[posX, posZ] > 0) {
            World.fireflies[posX, posZ] -= 1;
            EntityManager.updateFirefly(posX, posZ);
        }
    }

    public static int fireflyCount() {

        int count = 0;
        for (int x=0; x < World.width; x++) {
            for (int z=0; z < World.height; z++) {
                
                if (World.fireflies[x, z] == 1) {
                    count += 1;
                }
            }
        }

        return count;
    }
}
