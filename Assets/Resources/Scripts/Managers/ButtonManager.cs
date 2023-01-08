using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour{

    public static string currentLevel = "1";

    public void startGame(){
        currentLevel = EventSystem.current.currentSelectedGameObject.name.ToString();
        //Debug.Log(currentLevel);
        restartGame();
    }
    public void restartGame(){
        //Debug.Log(currentLevel);
        switch(currentLevel){
            case "1":
                LevelManager.loadLevel(Levels.l1);
            break;
            case "2":
                LevelManager.loadLevel(Levels.l2);
            break;
            case "3":
                LevelManager.loadLevel(Levels.l3);
            break;
            case "4":
                LevelManager.loadLevel(Levels.l4);
            break;
            case "5":
                LevelManager.loadLevel(Levels.l5);
            break;
            case "6":
                LevelManager.loadLevel(Levels.l6);
            break;
            case "7":
                LevelManager.loadLevel(Levels.l7);
            break;
            case "8":
                LevelManager.loadLevel(Levels.l8);
            break;
            case "9":
                LevelManager.loadLevel(Levels.l9);
            break;
            case "10":
                LevelManager.loadLevel(Levels.l10);
            break;
            case "11":
                LevelManager.loadLevel(Levels.l11);
            break;
            case "12":
                LevelManager.loadLevel(Levels.l12);
            break;
            case "13":
                LevelManager.loadLevel(Levels.l13);
            break;
            case "14":
                LevelManager.loadLevel(Levels.l14);
            break;
            case "15":
                LevelManager.loadLevel(Levels.l15);
            break;
            case "16":
                LevelManager.loadLevel(Levels.l16);
            break;
            case "17":
                LevelManager.loadLevel(Levels.l17);
            break;
            case "18":
                LevelManager.loadLevel(Levels.l18);
            break;
            case "19":
                LevelManager.loadLevel(Levels.l19);
            break;
            case "20":
                LevelManager.loadLevel(Levels.l20);
            break;
        }      
    }
    public void levelSelect(){
        SceneManager.LoadScene("LevelSelect");        
    }
    public void newStuff(){
        SceneManager.LoadScene("New"); 
    }
    public void instructions(){
        SceneManager.LoadScene("Help"); 
    }
    public void backToMain(){
        SceneManager.LoadScene("Title");         
    }
    public void exit(){
        Application.Quit();
    }
}

