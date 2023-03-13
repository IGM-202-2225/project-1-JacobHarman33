using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    public List<GameObject> lives = new List<GameObject>();
    public int numOfLives;

    // Start is called before the first frame update
    void Start()
    {
        numOfLives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        switch (numOfLives)
        {
            case 2:
                if (lives[2] != null)
                {
                    Destroy(lives[2]);
                }
                break;
            case 1:
                if(lives[1] != null)
                {
                    Destroy(lives[1]);
                }
                break;
            case 0:
                if (lives[0] != null)
                {
                    Destroy(lives[0]);
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }
    }
}
