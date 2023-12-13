using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManagement : MonoBehaviour
{
     public void Retry()
     {
	SceneManager.LoadScene("Scene Week 1");
     }

     public void LoadMainMenu()
     {
	SceneManager.LoadScene("main menu");
     }
}
