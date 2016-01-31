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
	public IEnumerator playerDied () 
	{
		gameOver.SetActive(true);
		yield return new WaitForSeconds(2);
		Camera.main.backgroundColor = Color.black;
		Camera.main.cullingMask = 1 << LayerMask.NameToLayer("UI");
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
