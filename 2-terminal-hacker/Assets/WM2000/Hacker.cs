// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	// Game Configuration Data
	string[] level1Passwords = {"password", "cats", "java", "dogs", "fish", "username"};
	string[] level2Passwords = {"prisoner", "handcuffs", "jailcell", "policebrutality", "donuts"};

	// Game state
	int level;
	string password;
	enum Screen {MainMenu, Password, Win};
	Screen currentScreen;

	// Use this for initialization
	void Start () {
		ShowMainMenu();
	}

	void ShowMainMenu () {
		currentScreen = Screen.MainMenu;
		Terminal.ClearScreen();
		Terminal.WriteLine("Hello, Zach");
		Terminal.WriteLine("L33T H3CK0r 3000");
		Terminal.WriteLine("WH3T D0 U W3NN3 H3K IN2???:");
		Terminal.WriteLine("1 - Miss Edge's laptop");
		Terminal.WriteLine("2 - Popo station");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnUserInput(string input)
	{
		if (input == "menu") { //We can always go to the main menu
			ShowMainMenu();
		}
		else if (currentScreen == Screen.MainMenu) {
			RunMainMenu(input);
		}
		else if (currentScreen == Screen.Password) {
			CheckPassword(input);
		}
	}

	void RunMainMenu (string input) {
		bool isValidLevelNumber = (input == "1" || input == "2");
		if (isValidLevelNumber) {
			level = int.Parse(input);
			StartGame();
		}
		else if (input == "poop") {
			Terminal.WriteLine("💩");
		}
		else {
			Terminal.WriteLine("Please select a level");
		}
	}

	void CheckPassword (string input) {
		if (input == password) {
			Terminal.WriteLine ("Access Granted.");
		}
		else {
			Terminal.WriteLine ("Access Denied.");
		}
	}

	void StartGame() {
		Terminal.ClearScreen();
		currentScreen = Screen.Password;
		switch(level) {
			case 1:
				password = level1Passwords[Random.Range(0, level1Passwords.Length)];
				break;
			case 2: 
				password = level2Passwords[Random.Range(0, level2Passwords.Length)];
				break;
			default: 
				Debug.LogError("Invalid level number");
				break;
		}
		Terminal.WriteLine("Please enter the password.");
	}
}
