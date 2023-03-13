using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text pointsLabelText;
    public TMP_Text pointsNumText;
    public TMP_Text lvlHiScoreLabelText;
    public TMP_Text lvlHiScoreNumText;
    public TMP_Text overallHiScoreNumText;

    // Start is called before the first frame update
    void Start()
    {
        if(StaticFields.levelNum == 1)
        {
            pointsLabelText.text = "Level 1 Score:";
            lvlHiScoreLabelText.text = "Level 1 High Score:";
            if (StaticFields.pointsNum >= StaticFields.lvlOneHiScore)
            {
                StaticFields.lvlOneHiScore = StaticFields.pointsNum;
            }
            lvlHiScoreNumText.text = StaticFields.lvlOneHiScore.ToString();
        }
        else if (StaticFields.levelNum == 2)
        {
            pointsLabelText.text = "Level 2 Score:";
            lvlHiScoreLabelText.text = "Level 2 High Score:";
            if (StaticFields.pointsNum >= StaticFields.lvlTwoHiScore)
            {
                StaticFields.lvlTwoHiScore = StaticFields.pointsNum;
            }
            lvlHiScoreNumText.text = StaticFields.lvlTwoHiScore.ToString();
        }
        else if (StaticFields.levelNum == 3)
        {
            pointsLabelText.text = "Level 3 Score:";
            lvlHiScoreLabelText.text = "Level 3 High Score:";
            if (StaticFields.pointsNum >= StaticFields.lvlThreeHiScore)
            {
                StaticFields.lvlThreeHiScore = StaticFields.pointsNum;
            }
            lvlHiScoreNumText.text = StaticFields.lvlThreeHiScore.ToString();
        }

        pointsNumText.text = StaticFields.pointsNum.ToString();
        if(StaticFields.pointsNum >= StaticFields.overallHiScore)
        {
            StaticFields.overallHiScore = StaticFields.pointsNum;
        }
        overallHiScoreNumText.text = StaticFields.overallHiScore.ToString();
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
