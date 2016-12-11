using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	[SerializeField]
    private String sceneName;
    [SerializeField]
    private GameObject faderCanvas;
    [SerializeField]
    private float delay = 1f;

    public int sceneNumber = 1;
    
    public void ChangeScene()
    {
        DontDestroyOnLoad(gameObject);
        faderCanvas.GetComponentInChildren<Animator>().SetTrigger("FadeIn");
        Invoke("ChangeSceneBro", delay);
    }

    void ChangeSceneBro()
    {
        SceneManager.LoadScene(sceneNumber);
        faderCanvas.GetComponentInChildren<Animator>().SetTrigger("FadeOut");
        sceneNumber++;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            ChangeScene();
        }
    }
}
