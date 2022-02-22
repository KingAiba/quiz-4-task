using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionScript : MonoBehaviour
{
    private Button button;
    public Sprite background;
    int level;
    private GameManager gameManger;
    void Start()
    {
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SelectLevel);
    }

    
    void Update()
    {
        
    }

    void SelectLevel()
    {
        gameManger.StartGame(level, background);
    }
}
