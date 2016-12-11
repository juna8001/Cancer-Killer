using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	[SerializeField]
    private String sceneName;
    [SerializeField]
    private GameObject faderCanvas;
    [SerializeField]
    private float delay = 0.5f;
    
    public void ChangeScene()
    {
        DontDestroyOnLoad(gameObject);
        faderCanvas.GetComponentInChildren<Animator>().SetTrigger("FadeIn");
        Invoke("ChangeSceneBro", delay);
    }

    void ChangeSceneBro()
    {
        SceneManager.LoadScene(sceneName);
        faderCanvas.GetComponentInChildren<Animator>().SetTrigger("FadeOut");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            ChangeScene();
        }
    }
}
