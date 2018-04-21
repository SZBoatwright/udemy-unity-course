// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	// Game Configuration Data
	const string menuHint = "You may type menu at any time";
	string[] level1Passwords = {"password", "cats", "java", "dogs", "fish", "username"};
	string[] level2Passwords = {"prisoner", "handcuffs", "jailcell", "policebrutality", "donuts"};
	string[] level3Passwords = {"nebula", "shootingstars", "europa", "spaceship", "aerodynamics"};

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
		Terminal.WriteLine("What system would you like to hack in to?");
		Terminal.WriteLine("1 - Miss Edge's laptop");
		Terminal.WriteLine("2 - Popo station");
		Terminal.WriteLine("3 - NASA");
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
		bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
		if (isValidLevelNumber) {
			level = int.Parse(input);
			AskForPassword();
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
			DisplayWinScreen();
		}
		else {
			AskForPassword();
		}
		Terminal.WriteLine(menuHint);
	}

	void DisplayWinScreen () {
		currentScreen = Screen.Win;
		Terminal.ClearScreen();
		ShowLevelReward();
	}

	void ShowLevelReward() {
		switch (level) {
			case 1:
				Terminal.WriteLine("There's just a lot of kittens...");
				ShowKitten();
				break;
			case 2:
				Terminal.WriteLine("You released all of the prisoners!!!");
				ShowRunningMan();
				break;
			case 3:
				Terminal.WriteLine("You launched a space ship!!!!");
				ShowSpaceShip();
				break;
			default: 
				Debug.LogError("not a valid argument!");
				break;
		}
	}

	void AskForPassword() {
		Terminal.ClearScreen();
		currentScreen = Screen.Password;
		SetRandomPassword();
		Terminal.WriteLine("Enter the password. Hint:" + password.Anagram());
	}

	void SetRandomPassword() {
		switch(level) {
			case 1:
				password = level1Passwords[Random.Range(0, level1Passwords.Length)];
				break;
			case 2: 
				password = level2Passwords[Random.Range(0, level2Passwords.Length)];
				break;
			case 3: 
				password = level3Passwords[Random.Range(0, level3Passwords.Length)];
				break;
			default: 
				Debug.LogError("Invalid level number");
				break;
		}
	}

	// ASCII Art
	void ShowRunningMan() {
						Terminal.WriteLine(@"
                _
              _( }
    -=   _  <<  \
        `.\__/`/\\
  -=      '--'\\  `
       -=     //
   -==        \)

				");
	}
	void ShowKitten() {
						Terminal.WriteLine(@"
    /\**/\
   ( o_o  )_)
   ,(u  u  ,),
				");
	}
	void ShowSpaceShip() {
						Terminal.WriteLine(@"
   __
   \ \_____
###[==_____>
   /_/      __
            \ \_____
         ###[==_____>
            /_/
				");
	}

}
