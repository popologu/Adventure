using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneController : MonoBehaviour {

    [Header("Game")] 
    public Player player;

    [Header("UI")]
    public Text healthText;
       

	void Start () {
		
	}
	

	void Update () {
        if (player != null) {
            healthText.text = "Health: " + player.health;
            } else {
            healthText.text = "Health: 0";
            }
        
	}
}
