using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Text healthtext;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        healthtext = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        healthtext.text = player.GetHealth().ToString();
    }
}
