using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public Rigidbody2D ball;
    public Rigidbody2D platform;
    public GameObject PauseScreen;
    bool paused = false;
    public void Pause()
    {
        Debug.Log("pause");
        if(!paused)
        {
            ball.simulated = false;
            platform.simulated = false;
            PauseScreen.SetActive(true);
        } else
        {
            ball.simulated = true;
            platform.simulated = true;
            PauseScreen.SetActive(false);
        }
        paused = !paused;
    }



}
