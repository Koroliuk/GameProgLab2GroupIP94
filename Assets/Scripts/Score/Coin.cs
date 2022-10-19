using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    [Range(1, 10)]
    [SerializeField] private int value = 1;
    
    private ScoreManager _scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        _scoreManager = FindObjectOfType<ScoreManager>();

        if (other.gameObject.CompareTag("Player"))
        {
            _scoreManager.IncreaseScore(value);
            Destroy(gameObject);
        }
    }
}
