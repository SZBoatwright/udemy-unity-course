using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    [SerializeField] float rcsThrust = 250f;
    [SerializeField] float mainThrust = 750f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip death;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip levelStart;

    Rigidbody rigidBody;
    AudioSource audioSource;

    enum State { Alive, Dying, Transcending };
    State state = State.Alive;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(levelStart);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(state == State.Alive)
        {
            RespondToThrustInput();
            RespondToRotateInput();
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
            case "Finish":
                StartSuccessSequence();
                break;
            case "Fuel":
                print("Fuel up bby ;)");
                break;
            default:
                StartDeathSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        state = State.Transcending;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        Invoke("LoadNextLevel", 1f); // parameterise time
    }

    private void StartDeathSequence()
    {
        state = State.Dying;
        audioSource.Stop();
        audioSource.PlayOneShot(death);
        Invoke("LoadFirstLevel", 1f); // parameterise time
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(1); // todo allow for more than 2 level
    }

    private void RespondToThrustInput()
    {

        float translationThisFrame = mainThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust(translationThisFrame);
        }
        else
        {
            audioSource.Stop(); //todo this conflicts with the level-start audio
        }
    }

    private void ApplyThrust(float translationThisFrame)
    {
        rigidBody.AddRelativeForce(Vector3.up * translationThisFrame);
        if (audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(mainEngine);
        }
    }

    private void RespondToRotateInput()
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