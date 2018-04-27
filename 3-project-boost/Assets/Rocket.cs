using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    [SerializeField] float rcsThrust = 250f;
    [SerializeField] float mainThrust = 750f;

    Rigidbody rigidBody;
    AudioSource audioSource;

    enum State { Alive, Dying, Transcending };
    State state = State.Alive;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // todo stop sound on death
        if(state == State.Alive)
        {
            Thrust();
            Rotate();
        }
	}

    void OnCollisionEnter(Collision collision) // a variable called collision of type Collision
    {
        if(state != State.Alive){return;}

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("this object luvs u :)"); //TODO remove this line
                break;
            case "Fuel":
                print("Fuel up bby ;)");
                break;
            case "Finish":
                state = State.Transcending;
                Invoke("LoadNextLevel", 1f); // parameterise time
                break;
            default:
                state = State.Dying;
                Invoke("LoadFirstLevel", 1f); // parameterise time
                break;
        }
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(1); // todo allow for more than 2 level
    }

    private void Thrust()
    {

        float translationThisFrame = mainThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * translationThisFrame);
            if (audioSource.isPlaying == false)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; // This takes control of the rotation

        float roationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * roationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * roationThisFrame);
        }

        rigidBody.freezeRotation = false; // Hands rotation of rigid body back to physics engine
    }

}