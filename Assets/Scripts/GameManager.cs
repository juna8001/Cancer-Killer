using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    [SerializeField]
    Scene intro, lvl1, lvl2, map, credits;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
