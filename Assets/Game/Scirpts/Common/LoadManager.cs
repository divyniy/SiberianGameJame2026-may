using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public static class SceneManagerManager
{
    public static Color alpha = new Color(0,0,0,0);
    
    public static void ChangeScene(int id)
    {
        GameConfig cfg = Resources.Load<GameConfig>("GameConfig");
        GameObject obj = GameObject.Instantiate(cfg.SceneTransition);
        obj.GetComponentInChildren<Image>().color = alpha;
        obj.GetComponentInChildren<Image>().DOFade(1, 2.5f).SetDelay(0.4f).onComplete += () => {SetScene(id);};
    }
    public static void ChangeScene(string name)
    {
        GameConfig cfg = Resources.Load<GameConfig>("GameConfig");
        GameObject obj = GameObject.Instantiate(cfg.SceneTransition);
        obj.GetComponentInChildren<Image>().color = alpha;
        obj.GetComponentInChildren<Image>().DOFade(1, 2.5f).SetDelay(0.4f).onComplete += () => {SetScene(name);};
    }

    public static void LoadScene()
    {
        GameConfig cfg = Resources.Load<GameConfig>("GameConfig");
        GameObject obj = GameObject.Instantiate(cfg.SceneTransition);
        obj.GetComponentInChildren<Image>().DOFade(0, 2.5f).SetDelay(0.4f).onComplete += () => {GameObject.Destroy(obj);};
    }
    private static void SetScene(int id)
    {
        SceneManager.LoadScene(id);
    }
    private static void SetScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
