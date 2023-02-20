using UnityEngine;
using UnityEditor;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private ScoreSO _scoreSO;
    public TextMeshProUGUI[] scoreText;

    private void Awake()
    {
        _scoreSO.ResetScore();
    }

    private void Update()
    {
        //EditorUtility.SetDirty(_scoreSO);

        scoreText[0].SetText("Score: " + _scoreSO.CurrentScore);

        for (int i = 1; i < scoreText.Length; i++)
        {
            scoreText[i].SetText("Highest Score: " + _scoreSO.HighestScore);
        }

        if (_scoreSO.CurrentScore > _scoreSO.HighestScore)
        {
            _scoreSO.SetHighestScore(_scoreSO.CurrentScore);
        }
    }
}
