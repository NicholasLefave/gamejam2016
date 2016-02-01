using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	public GameObject gameOver;
	public AudioSource source;
	public AudioClip clip;
	// Use this for initialization
	void Start () 
	{
		gameOver.SetActive(false);
	}

	// Update is called once per frame

	void Update()
	{
		if(gameOver.activeSelf)
		{
			if(Input.GetButtonDown("Retry"))
				retry();
			if(Input.GetButtonDown("Quit"))
				quit();
		}

	}

	public IEnumerator playerDied () 
	{
		yield return new WaitForSeconds(2);
		Camera.main.backgroundColor = Color.black;
		Camera.main.cullingMask = 1 << LayerMask.NameToLayer("UI");
		source.Stop ();
		source.PlayOneShot (clip);
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
