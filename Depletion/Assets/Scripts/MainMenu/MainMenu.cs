using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[SerializeField]
    public string startingScene = "Winter";

	public void PlayGame()
	{
		Debug.Log("started");
		Loading.Instance.Show(SceneManager.LoadSceneAsync(startingScene));
		Debug.Log("finished");
	}
	public void QuitGame()
	{
		Debug.Log("Applications has quit. MainMenu.cs");
		Application.Quit();
	}
}
