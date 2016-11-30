using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class logger : MonoBehaviour {

	public bool loggingEnabled;
	public int confirmationTime;//Number of seconds you have to hold the stop button

	private bool tableL = false;
	private bool tableC = false;
	private bool tableR = false;

	private float startTime;
	private float endTime;

	bool cooldown = true;

	private KeyCode resetScene = KeyCode.Space;

	void Start () {
	
	}
	

	void Update () {
		if(Input.GetKeyDown(resetScene)){
			SceneManager.LoadScene("scene1");
		}
		if (Input.GetKeyDown (KeyCode.N)) {
			if (loggingEnabled) {
				Debug.Log ("Logging disabled. End of test");
				writeToLog ("End of test @ " + (System.DateTime.Now.ToString()));
				loggingEnabled = false;
			} else {
				Debug.Log ("Logging enabled. Start of test");
				writeToLog ("Test @ " + (System.DateTime.Now.ToString()));
				loggingEnabled = true;
			}
		}
		if (loggingEnabled) {
			if (Input.GetKeyDown (KeyCode.L) && !tableL) {
				
				if (tableL || tableR || tableC) {
					Debug.Log ("Timer already running. Press \"Q\" to cancel current timer");
				} else {
					tableL = true;
					startTime = Time.time;
					Debug.Log ("Started timer for left table");
					cooldown = false;
					StartCoroutine ("_cooldown");
				}
				
			}

			if (Input.GetKey (KeyCode.L) && tableL && cooldown) {
				Debug.Log ("Ĺogger end sequence initiated. Hold button for " + confirmationTime + " seconds to confirm");
				endTime = Time.time;
				cooldown = false;
				StartCoroutine (countAndLog (KeyCode.L, confirmationTime));
			}

			if (Input.GetKeyDown (KeyCode.R) && !tableL) {
				if (tableL || tableR || tableC) {
					Debug.Log ("Timer already running. Press \"Q\" to cancel current timer");
				} else {
					tableR = true;
					startTime = Time.time;
					Debug.Log ("Started timer for right table");
					cooldown = false;
					StartCoroutine ("_cooldown");
				}

			}

			if (Input.GetKey (KeyCode.R) && tableR && cooldown) {
				Debug.Log ("Ĺogger end sequence initiated. Hold button for " + confirmationTime + " seconds to confirm");
				endTime = Time.time;
				cooldown = false;
				StartCoroutine (countAndLog (KeyCode.R, confirmationTime));
			}

			if (Input.GetKeyDown (KeyCode.C) && !tableC) {
				if (tableL || tableR) {
					Debug.Log ("Timer already running. Press \"Q\" to cancel current timer");
				} else {
					tableC = true;
					startTime = Time.time;
					Debug.Log ("Started timer for center table");
					cooldown = false;
					StartCoroutine ("_cooldown");
				}

			}

			if (Input.GetKey (KeyCode.C) && tableC && cooldown) {
				Debug.Log ("Ĺogger end sequence initiated. Hold button for " + confirmationTime + " seconds to confirm");
				endTime = Time.time;
				cooldown = false;
				StartCoroutine (countAndLog (KeyCode.C, confirmationTime));
			}

			if (Input.GetKeyDown (KeyCode.Q)) {
				Debug.Log ("Timer canceled");
				tableC = false;
				tableL = false;
				tableR = false;
			}

		}
	}



	public IEnumerator countAndLog(KeyCode k, int seconds){
		bool cancel = false;
		for (int i = seconds; i > 0; i--) {
			Debug.Log ("" + i);
			if (!Input.GetKey (k)) {
				Debug.Log ("Timer stop canceled at: " + (endTime - startTime));
				cancel = true;
				break;
			}
			yield return new WaitForSeconds (1);
		}

		if (Input.GetKey (k) && !cancel) {
			Debug.Log ("Timer stopped at: " + (endTime - startTime));
			if (tableC) {
				writeToLog ("TableC: " + (endTime - startTime));
			}else if(tableL){
				writeToLog ("TableL: " + (endTime - startTime));
				}else{
				writeToLog ("TableR: " + (endTime - startTime));
				}
			tableL = false;
			tableR = false;
			tableC = false;
		}

		cooldown = true;
	}

	private IEnumerator _cooldown(){
		yield return new WaitForSeconds (1);
		cooldown = true;
	}

	private void writeToLog(string s){
		Debug.Log ("Logging :" + s);
		string filePath = Application.dataPath + "/data/log.txt";
		System.IO.File.AppendAllText (filePath, s+System.Environment.NewLine);
	}
}
