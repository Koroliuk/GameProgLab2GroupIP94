using UnityEngine;

public class Coin : MonoBehaviour
{
    [Range(1, 5)]
    [SerializeField] private int value = 1;
    
    private ScoreManager _scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        if (!other.gameObject.CompareTag("Player")) return;
        _scoreManager.Add(value);
        Destroy(gameObject);
    }
}
