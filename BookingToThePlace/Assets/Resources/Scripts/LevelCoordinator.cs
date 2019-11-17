using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCoordinator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform winLine, loseLine;

    [SerializeField]
    private string sceneName, nextSceneName;

    [SerializeField]
    private float LevelTime;

    [SerializeField]
    private TextMeshProUGUI timerSign;

    private float timer;

    private void Start()
    {
        timer = LevelTime;
    }


    void Update()
    {
        timer -= Time.deltaTime;

        timerSign.text = "Time left: " + timer;

        if (player.position.y >= winLine.position.y)
        {
            Debug.Log("You Win!!");
            SceneManager.LoadScene(nextSceneName);
        }

        if (player.position.y <= loseLine.position.y || timer < 0)
        {
            Debug.Log("You lost :'(");
            SceneManager.LoadScene(sceneName);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
