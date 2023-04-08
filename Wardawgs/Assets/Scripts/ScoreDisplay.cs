using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    public static float score;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        var scoreValue = score;
        scoreText.text = scoreValue.ToString();
    }
}
