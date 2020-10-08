using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void PlayGame()
	{
		SceneManager.LoadScene("Winter"); // Replace this with future save system.
	}
	public void QuitGame()
	{
		Debug.Log("Applications has quit. MainMenu.cs");
		Application.Quit();
	}
}
