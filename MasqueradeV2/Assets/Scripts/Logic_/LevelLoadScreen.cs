using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoadScreen : MonoBehaviour
{
    public GameObject loadingScreen;
    private Image image;
    [SerializeField] Sprite[] animSprites;
    int sprite = 0;
    [SerializeField] float wait;

    public void Start()
    {
        image = loadingScreen.GetComponent<Image>();
    }
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        //animacion play()

        while (!operation.isDone)// || !X)
        {
            //La animacion de la pantalla de carga por ahora va aca en la corrutina porque
            //Si no el juego no la reproduce por cargar el nivel, y eso que aveces aun no se
            //reproduce bien. La anim por animator esta lista, es solo activar el componente en Image
            //So, si alguno de videojuegos lo quiere arreglar then there's the stuff.
            /*image.sprite = animSprites[sprite];
            sprite++;
            if (sprite >= 8) sprite = 0;
            yield return new WaitForSeconds(wait);*/

            //float progress = Mathf.Clamp01(operation.progress / 0.9f);
            //Debug.Log(progress);

            /*
            if (cuando termine la animacion)
                X = true;    
            */
            yield return null;
        }
    }
}
