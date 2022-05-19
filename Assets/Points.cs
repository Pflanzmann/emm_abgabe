using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour {
    [SerializeField] private Text text;

    private int points = 0;

    public void AddPoint() {
        points++;

        text.text = "points: " + points;
    }
}