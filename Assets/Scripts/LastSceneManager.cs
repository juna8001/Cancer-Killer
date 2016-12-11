using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LastSceneManager : MonoBehaviour {

    [SerializeField]
    Image PoziomPierwszyUkonczony;
    [SerializeField]
    AudioClip MuzykaMapy;
    [SerializeField]
    Image Mapa0, Mapa1;
    [SerializeField]
    GameObject Kolko;
    [SerializeField]
    Image Poziom1Ukonczony;
    [SerializeField]
    GameObject krok0, krok1, krok2, krok3;
    [SerializeField]
    GameObject Kolko2;
    [SerializeField]
    Image Misja2;
    [SerializeField]
    GameObject Credits;

    void Start()
    {
        StartCoroutine(go());
    }

    IEnumerator go()
    {
        // Pierwszy napis

        for(float i = 0; i < 60; i++)
        {
            PoziomPierwszyUkonczony.color = new Color(1, 1, 1, i / 60f);
            yield return new WaitForSeconds(1f/60f);
        }
        yield return new WaitForSeconds(3f);
        for (float i = 0; i < 60; i++)
        {
            PoziomPierwszyUkonczony.color = new Color(1, 1, 1, 1 - i / 60f);
            yield return new WaitForSeconds(1f / 60f);
        }
        yield return new WaitForSeconds(0.5f);

        // Mapa 0
        for (float i = 0; i < 60; i++)
        {
            Mapa0.color = new Color(1, 1, 1, i / 60f);
            yield return new WaitForSeconds(1f / 60f);
        }
        yield return new WaitForSeconds(0.5f);

        // Mapa 1
        for (float i = 0; i < 60; i++)
        {
            Mapa1.color = new Color(1, 1, 1, i / 60f);
            yield return new WaitForSeconds(1f / 60f);
        }
        yield return new WaitForSeconds(0.5f);

        // Kółko i flaga
        for (float i = 0; i < 60; i++)
        {
            Poziom1Ukonczony.color = new Color(1, 1, 1, i / 60f);
            yield return new WaitForSeconds(1f / 60f);
        }
        yield return new WaitForSeconds(0.2f);
        krok0.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        krok1.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        krok2.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        krok3.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Kolko2.SetActive(true);
        for (float i = 0; i < 60; i++)
        {
            Misja2.color = new Color(1, 1, 1, i / 60f);
            yield return new WaitForSeconds(1f / 60f);
        }


    }


}
