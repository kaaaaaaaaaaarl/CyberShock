using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChaingeScene : MonoBehaviour
{
    public string sceneName;
    public string sceneName1;
    public string sceneName2;
    public void ChaingeScenes()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ChaingeScenes1()
    {
        SceneManager.LoadScene(sceneName1);
    }
    public void ChaingeScenes2()
    {
        SceneManager.LoadScene(sceneName2);
    }
}
