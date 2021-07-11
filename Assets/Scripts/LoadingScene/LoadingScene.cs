using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public Transform Enemy;
    public Transform Stars;

    void Start()
    {
        Enemy.DOScale(Enemy.lossyScale + Vector3.one / 10, 0.7f).SetLoops(-1, LoopType.Yoyo);
        Stars.DOScale(Stars.lossyScale + Vector3.one / 10, 0.7f).SetLoops(-1, LoopType.Yoyo);
        StartCoroutine(LoadScene(Random.Range(1, 2f)));
    }

    private IEnumerator LoadScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadSceneAsync("Menu");
    }
}
