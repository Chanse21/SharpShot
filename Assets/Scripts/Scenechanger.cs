using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scenechanger : MonoBehaviour
{
    public void LoadLevelScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}