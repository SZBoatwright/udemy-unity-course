using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    [SerializeField] float rcsThrust = 250f;
    [SerializeField] float mainThrust = 750f;

    Rigidbody rigidBody;
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Thrust();
        Rotate();
	}

    void OnCollisionEnter(Collision collision) // a variable called collision of type Collision
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("this object luvs u :)"); //TODO remove this line
                break;
            case "Fuel":
                print("Fuel up bby ;)");
                break;
            case "Finish":
                print("You beat the level!");
                SceneManager.LoadScene(1);
                break;
            default:
                print("U R DED :((((((");
                SceneManager.LoadScene(0);
                break;
        }
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