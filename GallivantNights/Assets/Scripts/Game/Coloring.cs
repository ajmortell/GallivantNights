using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coloring : MonoBehaviour {

    Color RED;
    Color YELLOW;
    Color LEMON;
    Color BLUE;
    Color GREEN;
    Color LIME;
    Color PURPLE;
    Color ORANGE;
    Color BLACK;
    Color WHITE;
    Color GREY;
    Color LIGHT_GREY;
    Color DARK_GREY;
    Color LIGHT_BLUE;
    Color HOT_RED;
    Color CLEAR;
    Color WHITE_LOW_ALPHA;
    // Use this for initialization
    void Awake() {
        // R G B A
        RED = new Color32(255, 12, 0, 255);//
        YELLOW = new Color32(255, 200, 0, 255);//
        LEMON = new Color32(255, 255, 25, 255);//
        BLUE = new Color32(0, 100, 255, 255);//
        GREEN = new Color32(75, 255, 75, 255);//
        LIME = new Color32(175, 255, 25, 255);//
        PURPLE = new Color32(75, 50, 255, 255);//
        ORANGE = new Color32(255, 125, 0, 255);//
        BLACK = new Color32(0, 0, 0, 254);//
        WHITE = new Color32(255, 255, 255, 255);//
        GREY = new Color32(100, 100, 100, 255);
        LIGHT_GREY = new Color32(175, 175, 175, 255);
        DARK_GREY = new Color32(50, 50, 50, 255);
        LIGHT_BLUE = new Color32(50, 200, 225, 255);//
        HOT_RED = new Color32(230, 32, 50, 255);//
        CLEAR = new Color32(0, 0, 0, 0);
        WHITE_LOW_ALPHA = new Color32(0,0,0,100);
    }

    public Color32 SelectColor (string _color) {
        Color selected_color = new Color32(0, 0, 0, 255);
        
        switch (_color) {
            case "RED":
                selected_color = RED;
                break;
            case "YELLOW":
                selected_color = YELLOW;
                break;
            case "LEMON":
                selected_color = LEMON;
                break;
            case "BLUE":
                selected_color = BLUE;
                break;
            case "GREEN":
                selected_color = GREEN;
                break;
            case "LIME":
                selected_color = LIME;
                break;
            case "PURPLE":
                selected_color = PURPLE;
                break;
            case "ORANGE":
                selected_color = ORANGE;
                break;
            case "BLACK":
                selected_color = BLACK;
                break;
            case "WHITE":
                selected_color = WHITE;
                break;
            case "GREY":
                selected_color = GREY;
                break;
            case "LIGHT_GREY":
                selected_color = LIGHT_GREY;
                break;
            case "DARK_GREY":
                selected_color = DARK_GREY;
                break;
            case "LIGHT_BLUE":
                selected_color = LIGHT_BLUE;
                break;
            case "HOT_RED":
                selected_color = HOT_RED;
                break;
            case "CLEAR":
                selected_color = CLEAR;
                break;
            case "WHITE_LOW_ALPHA":
                selected_color = WHITE_LOW_ALPHA;
                break;
        }
        return selected_color;
    }
}
