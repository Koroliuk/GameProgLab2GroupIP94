using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int _score;

    private void Awake()
    {
        SetScoreText();
    }

    public void Add(int amount)
    {
        _score += amount;
        SetScoreText();
    }

    private void SetScoreText()
    {
        scoreText.text = $"Score: {_score}";
    }
}
