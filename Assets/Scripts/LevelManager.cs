using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    private int _blocksCount;
    public event Action OnAllBlocksDestroyed;

    private void Awake()
    {
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
        FindObjectOfType<GameManager>().AddScore(point);
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
}