using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	public GameObject gameOver;
	// Use this for initialization
	void Start () 
	{
		gameOver.SetActive(false);
	}
	
	// Update is called once per frame
	public void playerDied () 
	{
		gameOver.SetActive(true);
	}

	public void retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void quit()
	{
		Application.Quit();
	}
}
