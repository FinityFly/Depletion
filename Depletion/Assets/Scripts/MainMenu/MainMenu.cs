using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	[SerializeField]
    public string startingScene = "Winter";
	public GameObject loadingScreenCanvas;
	public Loading loadingScript;

	public void PlayGame()
	{
		Debug.Log("started");
		loadingScreenCanvas.SetActive(true);
		Loading.Instance.setVars(GameObject.Find("Percentage").GetComponent<Text>(), GameObject.Find("Loading Screen").GetComponent<Animator>());
		Loading.Instance.Show(SceneManager.LoadSceneAsync(startingScene));
		loadingScreenCanvas.SetActive(false);
		Debug.Log("finished");
	}

	public void QuitGame()
	{
		Debug.Log("Applications has quit. MainMenu.cs");
		Application.Quit();
	}
}
