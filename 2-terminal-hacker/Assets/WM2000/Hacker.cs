using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	// Game state
	int level;
	enum Screen {MainMenu, Password, Win};
	Screen currentScreen = Screen.MainMenu;

	// Use this for initialization
	void Start () {
		ShowMainMenu();
	}

	void ShowMainMenu () {
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
		if (input == "menu") {
			ShowMainMenu();
			currentScreen = Screen.MainMenu;
		}
		// TODO handle differently depending on screen
		else if (input == "1") {
			Terminal.WriteLine("Attempting to hack into Miss Edge's ");
			Terminal.WriteLine("laptop... ");
			Terminal.WriteLine("... (this should be easy) ...");
			level = 1;
			startGame();
		}
		else if (input == "2") {
			Terminal.WriteLine("Attempting to hack into the popo");
			Terminal.WriteLine("station...");
			level = 2;
			startGame();
		}
		else if (input == "poop") {
			Terminal.WriteLine("💩");
		}
		else {
			Terminal.WriteLine("Please select a level");
		}
	}

	void startGame() {
		Terminal.WriteLine("You have chosen level " + level);
		currentScreen = Screen.Password;
	}
}
