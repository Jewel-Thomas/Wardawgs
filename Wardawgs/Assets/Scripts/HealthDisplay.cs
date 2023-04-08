using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    private TextMeshProUGUI healthText;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = player.GetHealth().ToString();
    }
}
