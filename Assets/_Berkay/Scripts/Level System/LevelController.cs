using System;
using System.Collections;
using System.Collections.Generic;
using _Berkay.Scripts.Level_System;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelObject level1;
    [SerializeField] private LevelObject level2;
    [SerializeField] private LevelObject level3;
    [SerializeField] private SceneLoadingShadow _sceneLoadingShadow;
    [SerializeField] private CatController _cat;
    

    private void Start()
    {
        level1.OnLevelCompleted += OnLevelCompleted;
        level2.OnLevelCompleted += OnLevelCompleted;
        level3.OnLevelCompleted += OnLevelCompleted;
    }

    private void OnDestroy()
    {
        level1.OnLevelCompleted -= OnLevelCompleted;
        level2.OnLevelCompleted -= OnLevelCompleted;
        level3.OnLevelCompleted -= OnLevelCompleted;
    }

    private void OnLevelCompleted(int levelNum)
    {
        switch (levelNum)
        {
            case 1:
                StartCoroutine(OnLevelCompleteRoutine(level1, level2));
                break;
            case 2:
                StartCoroutine(OnLevelCompleteRoutine(level2, level3));
                break;
            case 3:
                break;
        }
    }

    private IEnumerator OnLevelCompleteRoutine(LevelObject old, LevelObject newO)
    {
        _sceneLoadingShadow.Close();
        yield return new WaitForSeconds(2.5f);
        old.gameObject.SetActive(false);
        newO.gameObject.SetActive(true);
        newO.MovePlayerToSpawnPoint();
        _cat.transform.position = newO.GetSpawnPoint().position;
        yield return new WaitForSeconds(.5f);
        _sceneLoadingShadow.Open();
    }
}
