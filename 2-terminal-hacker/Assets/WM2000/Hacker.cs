using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	// Game state
	int level;
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
	}

	void RunMainMenu (string input) {
		if (input == "1") {
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
