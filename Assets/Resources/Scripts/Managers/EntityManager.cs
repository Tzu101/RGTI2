using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityManager : MonoBehaviour {

    private static GameObject frog;
    private static GameObject lilypadFlower;
    private static GameObject lilypadGreen;
    private static GameObject lilypadOrange;
    private static GameObject lilypadRed;
    private static GameObject firefly;
    private static GameObject fireflyQueen;

    public static GameObject frogs;
    private static GameObject[,] lilypads;
    private static GameObject[,] fireflies;

    public static Vector3 lilypadCenter = new Vector3(0, 0, 0);

    public static AudioManager AudioManager;
        
    void Awake() {
        EntityManager.AudioManager = (AudioManager) GameObject.Find("AudioManager").GetComponent<AudioManager>();

        EntityManager.AudioManager.playFly();

        lilypadCenter = new Vector3(0, 0, 0);

        EntityManager.frog = Resources.Load("Prefabs/Frog") as GameObject;
        EntityManager.lilypadFlower = Resources.Load("Prefabs/LilypadFlower") as GameObject;
        EntityManager.lilypadGreen = Resources.Load("Prefabs/LilypadGreen") as GameObject;
        EntityManager.lilypadOrange = Resources.Load("Prefabs/LilypadOrange") as GameObject;
        EntityManager.lilypadRed = Resources.Load("Prefabs/LilypadRed") as GameObject;
        EntityManager.firefly = Resources.Load("Prefabs/Firefly") as GameObject;
        EntityManager.fireflyQueen = Resources.Load("Prefabs/FireflyQueen") as GameObject;

        EntityManager.frogs = Instantiate(EntityManager.frog, new Vector3(LevelManager.currentLevel.start.x * World.gridToUnit, 0, LevelManager.currentLevel.start.y * World.gridToUnit), Quaternion.identity);
        EntityManager.lilypads = new GameObject[World.width, World.height];
        EntityManager.fireflies = new GameObject[World.width, World.height];

        int lilypadCount = 0;
        for (int x=0; x < World.width; x++) {
            for (int z=0; z < World.height; z++) {

                if (World.hasLilypad(x, z)) {
                    lilypadCount++;
                    Vector3 lilypadPosition = new Vector3(x, 0, z);
                    EntityManager.lilypadCenter += lilypadPosition;

                    GameObject lilypad = EntityManager.lilypadGreen;

                    switch (World.lilypadType(x, z)) {
                        case 1:
                            lilypad = EntityManager.lilypadRed;
                            break;

                        case 2:
                            lilypad = EntityManager.lilypadOrange;
                            break;
                    }

                    EntityManager.lilypads[x, z] = Instantiate(lilypad, lilypadPosition * World.gridToUnit, Quaternion.identity);
                }

                if (World.hasFireflyQueen(x, z)) {
                    EntityManager.fireflies[x, z] = Instantiate(EntityManager.fireflyQueen, new Vector3(x * World.gridToUnit, 2, z * World.gridToUnit), Quaternion.identity);
                }
                else if (World.hasFirefly(x, z)) {
                    EntityManager.fireflies[x, z] = Instantiate(EntityManager.firefly, new Vector3(x * World.gridToUnit, 2, z * World.gridToUnit), Quaternion.identity);
                }
            }
        }
        EntityManager.lilypadCenter /= lilypadCount;

        for (int i = 0; i < World.width*World.height; i++) {

            int posX = Random.Range(-World.width / 2 - 1, World.width + World.width / 2 + 1);
            int posZ = Random.Range(-World.height / 2 - 1, World.height + World.height / 2 + 1);

            if ((posX < -1 || posX > World.width) && (posZ < -1 || posZ > World.height)) {
                Instantiate(EntityManager.lilypadFlower, new Vector3(posX, 0, posZ) * World.gridToUnit, Quaternion.identity);
            }
        }
    }

    public static void updateFirefly(int posX, int posZ) {
        if (EntityManager.fireflies[posX, posZ].name == "FireflyQueen(Clone)") {
           Level.completed[LevelManager.currentLevel.id] = '1';
           Level.updateCompleted();
           LevelManager.currentLevel = null;
           SceneManager.LoadScene("Title");
        }
        if (EntityManager.fireflies[posX, posZ]) {
            Object.Destroy(EntityManager.fireflies[posX, posZ]);
            EntityManager.fireflies[posX, posZ] = null;
            EntityManager.AudioManager.playCrunch();
        }
    }

    public static void updateLilypad(int posX, int posZ) {

        if (EntityManager.lilypads[posX, posZ] && World.lilypads[posX, posZ] == 2) {
            Object.Destroy(EntityManager.lilypads[posX, posZ]);
            EntityManager.lilypads[posX, posZ] = Instantiate(EntityManager.lilypadOrange, new Vector3(posX, 0, posZ) * World.gridToUnit, Quaternion.identity);
        }

        if (EntityManager.lilypads[posX, posZ] && World.lilypads[posX, posZ] == 1) {
            Object.Destroy(EntityManager.lilypads[posX, posZ]);
            EntityManager.lilypads[posX, posZ] = Instantiate(EntityManager.lilypadRed, new Vector3(posX, 0, posZ) * World.gridToUnit, Quaternion.identity);
        }

        if (EntityManager.lilypads[posX, posZ] && World.lilypads[posX, posZ] <= 0) {
            Object.Destroy(EntityManager.lilypads[posX, posZ]);
            EntityManager.lilypads[posX, posZ] = null;
        }
    }
}
