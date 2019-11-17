using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField]
    private string nextScene;

    public void PlayNext()
    {
        SceneManager.LoadScene(nextScene);
    }
}
