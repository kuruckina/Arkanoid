using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levels;
    [SerializeField] private GameObject _gameCompleted;
    private int _blocksCount;
    public event Action OnAllBlocksDestroyed;

    private void Awake()
    {
        LoadLevel();
        Block.OnCreated += BlockCreated;
        Block.OnDestroved += BlockDestroyed;
    }

    private void OnDestroy()
    {
        Block.OnDestroved -= BlockDestroyed;
        Block.OnCreated -= BlockCreated;
    }

    private void BlockDestroyed(Block block, int point)
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.AddScore(point);
        }

        _blocksCount--;

        if (_blocksCount == 0)
        {
            OnAllBlocksDestroyed?.Invoke();
        }
    }

    private void BlockCreated(Block block)
    {
        _blocksCount++;
    }

    public void LoadLevel()
    {
        int _randLevel = (int) Random.Range(0, _levels.Count);
        _levels[_randLevel].SetActive(true);
        DeleteLevel(_randLevel);
    }

    private void DeleteLevel(int level)
    {
        _levels.RemoveAt(level);
        if (_levels.Count == 0 && _blocksCount == 0)
        {
            _gameCompleted.SetActive(true);
        }
    }
}