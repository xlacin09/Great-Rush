using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class button_click : MonoBehaviour {

	GameObject gameobject_main;
	GameObject gameobject_settings;
	GameObject gameobject_graphics;
	GameObject gameobject_sound;
	GameObject gameobject_controls;
	GameObject gameobject_movement;
	GameObject gameobject_actions;
	GameObject gameobject_inventory;
	GameObject gameobject_controls_default;
	GameObject gameobject_newgame;
	GameObject gameobject_newgame_story;
	GameObject gameobject_newgame_story_areyousure;

	Text textui_main_caption;//Main caption on the screen
	Text textui_resumegame;//
	public byte byte_menu_mode;//Checks state what menu is in now. 0=Main;1=Settings;2=Graphics;3=Sound;4=Controls;5=Movement;6=Actions;7=Inventory;8=ResetControls;9=New Game;10=New game Story Slot Selection;11=AreYouSureNewStory...

	public bool bool_in_menu = true;

	byte byte_newgame_story_slot=0;

	Settings settings;

	void Start() {
		settings = GameObject.Find ("Settings").GetComponent<Settings> ();

		gameobject_main = GameObject.Find ("buttons_main");
		gameobject_settings = GameObject.Find("buttons_settings");
		gameobject_graphics = GameObject.Find("buttons_graphics");
		gameobject_sound = GameObject.Find("buttons_sound");
		gameobject_controls = GameObject.Find("buttons_controls");
		gameobject_movement = GameObject.Find("buttons_movement");
		gameobject_actions = GameObject.Find ("buttons_actions");
		gameobject_inventory = GameObject.Find("buttons_inventory");
		gameobject_controls_default = GameObject.Find("buttons_controls_default");
		gameobject_newgame = GameObject.Find ("buttons_newgame");
		gameobject_newgame_story = GameObject.Find("buttons_newgame_story");
		gameobject_newgame_story_areyousure = GameObject.Find("buttons_newgame_story_areyousure");


		textui_main_caption = GameObject.Find("caption_main").GetComponent<Text>();
		textui_resumegame = GameObject.Find("Text_button_main_resume").GetComponent<Text>();

		//On Application startup Main Screen is initialized 
		bool_in_menu = GetComponent<new_load_game_manag> ()._Check_Menu();
		if (bool_in_menu) {
			textui_resumegame.text="";
		} else {
			textui_resumegame.text="Resume game";
		}


		_Button_Settings_Back ();
	}
		

	void Update () {
		if (Input.anyKeyDown) {
			if (Input.GetKey (KeyCode.Escape)) {
				switch (byte_menu_mode) {
				case 0:
					_Button_Main_Continue ();
					break;
				case 1:
				case 9:
					_Button_Settings_Back ();
					break;
				case 2:
				case 3:
				case 4:
					_Button_Main_Settings ();
					break;
				case 5:
				case 6:
				case 7:
				case 8:
					GetComponent<input_manag>()._Back_Check_Zero();
					break;
				case 10:
					_Button_Main_New ();
					break;
				case 11:
					_Button_New_Story_AreYouSure_No ();
					break;
				}
			}
		}
	}



	public void _Button_Main_Continue () {
		//Resumes game if scene was assynced
		if ( !bool_in_menu ) {
			//GetComponent<input_manag> ()._Send_Controls ();

			GetComponent<new_load_game_manag> ()._Unload_Menu();

			if (!settings.inventory_opened) {
				Time.timeScale = 1;
			}

			if (menu_loader.instance != null) {
				if (menu_loader.instance.on_after_menu_call_back != null) {
					menu_loader.instance.on_after_menu_call_back.Invoke ();
				}
			}
			if (inventory.instance != null) {
				if (inventory.instance.on_item_changed_call_back != null) {
					inventory.instance.on_item_changed_call_back.Invoke ();
				}
			}

		}
	}


	//Main Screen buttons
	public void _Button_Main_New(	)
	{
		/*
		//Makes Main Screen appear
		GameObject.Find("buttons_main").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_settings").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_graphics").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_sound").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_movement").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_actions").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_inventory").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls_default").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame").transform.localScale = new Vector3(1, 1, 1);
		GameObject.Find("buttons_newgame_story").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story_areyousure").transform.localScale = new Vector3(0, 0, 0);
		*/
		gameobject_main.SetActive(false);
		gameobject_settings.SetActive(false);
		gameobject_graphics.SetActive(false);
		gameobject_sound.SetActive(false);
		gameobject_controls.SetActive(false);
		gameobject_movement.SetActive(false);
		gameobject_actions.SetActive(false);
		gameobject_inventory.SetActive(false);
		gameobject_controls_default.SetActive(false);
		gameobject_newgame.SetActive(true);
		gameobject_newgame_story.SetActive(false);
		gameobject_newgame_story_areyousure.SetActive(false);


		textui_main_caption.text = "New Game";
		byte_menu_mode = 9;
	}		
	public void _Button_Main_Load()
	{
		//TODO
	}

	public void _Button_Main_Settings()
	{
		//Makes Settings screen appear
		/*
		GameObject.Find("buttons_main").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_settings").transform.localScale = new Vector3(1, 1, 1);
		GameObject.Find("buttons_graphics").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_sound").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_movement").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_actions").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_inventory").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls_default").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story_areyousure").transform.localScale = new Vector3(0, 0, 0);
		*/

		gameobject_main.SetActive(false);
		gameobject_settings.SetActive(true);
		gameobject_graphics.SetActive(false);
		gameobject_sound.SetActive(false);
		gameobject_controls.SetActive(false);
		gameobject_movement.SetActive(false);
		gameobject_actions.SetActive(false);
		gameobject_inventory.SetActive(false);
		gameobject_controls_default.SetActive(false);
		gameobject_newgame.SetActive(false);
		gameobject_newgame_story.SetActive(false);
		gameobject_newgame_story_areyousure.SetActive(false);

		textui_main_caption.text = "Settings";
		byte_menu_mode = 1;
	}
		
	public void _Button_Main_Quit()
	{
		//Quits the game
		Application.Quit();
	}
		
	//Settings Screen buttons

	public void _Button_Settings_Graphics()
	{
		//Makes Graphics screen appear
		/*
		GameObject.Find("buttons_main").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_settings").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_graphics").transform.localScale = new Vector3(1, 1, 1);
		GameObject.Find("buttons_sound").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_movement").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_actions").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_inventory").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls_default").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story_areyousure").transform.localScale = new Vector3(0, 0, 0);
		*/

		gameobject_main.SetActive(false);
		gameobject_settings.SetActive(false);
		gameobject_graphics.SetActive(true);
		gameobject_sound.SetActive(false);
		gameobject_controls.SetActive(false);
		gameobject_movement.SetActive(false);
		gameobject_actions.SetActive(false);
		gameobject_inventory.SetActive(false);
		gameobject_controls_default.SetActive(false);
		gameobject_newgame.SetActive(false);
		gameobject_newgame_story.SetActive(false);
		gameobject_newgame_story_areyousure.SetActive(false);

		textui_main_caption.text = "Graphics";
		byte_menu_mode = 2;
	}

	public void _Button_Settings_Sound()
	{
		//Makes Sound screen appear
		/*
		GameObject.Find("buttons_main").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_settings").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_graphics").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_sound").transform.localScale = new Vector3(1, 1, 1);
		GameObject.Find("buttons_controls").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_movement").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_actions").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_inventory").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls_default").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story_areyousure").transform.localScale = new Vector3(0, 0, 0);
		*/

		gameobject_main.SetActive(false);
		gameobject_settings.SetActive(false);
		gameobject_graphics.SetActive(false);
		gameobject_sound.SetActive(true);
		gameobject_controls.SetActive(false);
		gameobject_movement.SetActive(false);
		gameobject_actions.SetActive(false);
		gameobject_inventory.SetActive(false);
		gameobject_controls_default.SetActive(false);
		gameobject_newgame.SetActive(false);
		gameobject_newgame_story.SetActive(false);
		gameobject_newgame_story_areyousure.SetActive(false);

		textui_main_caption.text = "Sound";
		byte_menu_mode = 3;
	}

	public void _Button_Settings_Controls()
	{
		//Makes Sound screen appear
		/*
		GameObject.Find("buttons_main").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_settings").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_graphics").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_sound").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls").transform.localScale = new Vector3(1, 1, 1);
		GameObject.Find("buttons_movement").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_actions").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_inventory").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls_default").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story_areyousure").transform.localScale = new Vector3(0, 0, 0);
		*/

		gameobject_main.SetActive(false);
		gameobject_settings.SetActive(false);
		gameobject_graphics.SetActive(false);
		gameobject_sound.SetActive(false);
		gameobject_controls.SetActive(true);
		gameobject_movement.SetActive(false);
		gameobject_actions.SetActive(false);
		gameobject_inventory.SetActive(false);
		gameobject_controls_default.SetActive(false);
		gameobject_newgame.SetActive(false);
		gameobject_newgame_story.SetActive(false);
		gameobject_newgame_story_areyousure.SetActive(false);

		textui_main_caption.text = "Controls";
		byte_menu_mode = 4;
	}

	public void _Button_Settings_Back()
	{
		//Makes Main screen appear
		/*
		GameObject.Find("buttons_main").transform.localScale = new Vector3(1, 1, 1);
		GameObject.Find("buttons_settings").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_graphics").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_sound").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_movement").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_actions").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_inventory").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls_default").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story_areyousure").transform.localScale = new Vector3(0, 0, 0);
		*/

		gameobject_main.SetActive(true);
		gameobject_settings.SetActive(false);
		gameobject_graphics.SetActive(false);
		gameobject_sound.SetActive(false);
		gameobject_controls.SetActive(false);
		gameobject_movement.SetActive(false);
		gameobject_actions.SetActive(false);
		gameobject_inventory.SetActive(false);
		gameobject_controls_default.SetActive(false);
		gameobject_newgame.SetActive(false);
		gameobject_newgame_story.SetActive(false);
		gameobject_newgame_story_areyousure.SetActive(false);

		textui_main_caption.text = "The Great Rush";
		byte_menu_mode = 0;
	}
		

	public void _Button_Controls_Movement()
	{
		//Makes Main screen appear
		/*
		GameObject.Find("buttons_main").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_settings").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_graphics").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_sound").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_movement").transform.localScale = new Vector3(1, 1, 1);
		GameObject.Find("buttons_actions").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_inventory").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls_default").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story_areyousure").transform.localScale = new Vector3(0, 0, 0);
		*/

		gameobject_main.SetActive(false);
		gameobject_settings.SetActive(false);
		gameobject_graphics.SetActive(false);
		gameobject_sound.SetActive(false);
		gameobject_controls.SetActive(false);
		gameobject_movement.SetActive(true);
		gameobject_actions.SetActive(false);
		gameobject_inventory.SetActive(false);
		gameobject_controls_default.SetActive(false);
		gameobject_newgame.SetActive(false);
		gameobject_newgame_story.SetActive(false);
		gameobject_newgame_story_areyousure.SetActive(false);

		textui_main_caption.text = "Movement";
		byte_menu_mode = 5;
	}

	public void _Button_Controls_Actions()
	{
		//Makes Main screen appear
		/*
		GameObject.Find("buttons_main").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_settings").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_graphics").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_sound").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_movement").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_actions").transform.localScale = new Vector3(1, 1, 1);
		GameObject.Find("buttons_inventory").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls_default").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story_areyousure").transform.localScale = new Vector3(0, 0, 0);
		*/

		gameobject_main.SetActive(false);
		gameobject_settings.SetActive(false);
		gameobject_graphics.SetActive(false);
		gameobject_sound.SetActive(false);
		gameobject_controls.SetActive(false);
		gameobject_movement.SetActive(false);
		gameobject_actions.SetActive(true);
		gameobject_inventory.SetActive(false);
		gameobject_controls_default.SetActive(false);
		gameobject_newgame.SetActive(false);
		gameobject_newgame_story.SetActive(false);
		gameobject_newgame_story_areyousure.SetActive(false);

		textui_main_caption.text = "Actions";
		byte_menu_mode = 6;
	}

	public void _Button_Controls_Inventory()
	{
		//Makes Main screen appear
		/*
		GameObject.Find("buttons_main").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_settings").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_graphics").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_sound").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_movement").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_actions").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_inventory").transform.localScale = new Vector3(1, 1, 1);
		GameObject.Find("buttons_controls_default").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story_areyousure").transform.localScale = new Vector3(0, 0, 0);
		*/

		gameobject_main.SetActive(false);
		gameobject_settings.SetActive(false);
		gameobject_graphics.SetActive(false);
		gameobject_sound.SetActive(false);
		gameobject_controls.SetActive(false);
		gameobject_movement.SetActive(false);
		gameobject_actions.SetActive(false);
		gameobject_inventory.SetActive(true);
		gameobject_controls_default.SetActive(false);
		gameobject_newgame.SetActive(false);
		gameobject_newgame_story.SetActive(false);
		gameobject_newgame_story_areyousure.SetActive(false);

		textui_main_caption.text = "Inventory";
		byte_menu_mode = 7;
	}

	public void _Button_Controls_Default()
	{
		//Makes Main screen appear
		/*
		GameObject.Find("buttons_main").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_settings").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_graphics").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_sound").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_movement").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_actions").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_inventory").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls_default").transform.localScale = new Vector3(1, 1, 1);
		GameObject.Find("buttons_newgame").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story_areyousure").transform.localScale = new Vector3(0, 0, 0);
		*/

		gameobject_main.SetActive(false);
		gameobject_settings.SetActive(false);
		gameobject_graphics.SetActive(false);
		gameobject_sound.SetActive(false);
		gameobject_controls.SetActive(false);
		gameobject_movement.SetActive(false);
		gameobject_actions.SetActive(false);
		gameobject_inventory.SetActive(false);
		gameobject_controls_default.SetActive(true);
		gameobject_newgame.SetActive(false);
		gameobject_newgame_story.SetActive(false);
		gameobject_newgame_story_areyousure.SetActive(false);

		textui_main_caption.text = "Are you sure?";
		byte_menu_mode = 8;
	}

	public void _Button_NewGame_Tutorial () {
		GetComponent<new_load_game_manag> ()._Start_Tutorial();

	}


	public void _Button_NewGame_New_Story(	)
	{
		//Makes Main screen appear
		/*
		GameObject.Find("buttons_main").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_settings").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_graphics").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_sound").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_movement").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_actions").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_inventory").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls_default").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story").transform.localScale = new Vector3(1, 1, 1);
		GameObject.Find("buttons_newgame_story_areyousure").transform.localScale = new Vector3(0, 0, 0);
		*/

		gameobject_main.SetActive(false);
		gameobject_settings.SetActive(false);
		gameobject_graphics.SetActive(false);
		gameobject_sound.SetActive(false);
		gameobject_controls.SetActive(false);
		gameobject_movement.SetActive(false);
		gameobject_actions.SetActive(false);
		gameobject_inventory.SetActive(false);
		gameobject_controls_default.SetActive(false);
		gameobject_newgame.SetActive(false);
		gameobject_newgame_story.SetActive(true);
		gameobject_newgame_story_areyousure.SetActive(false);

		textui_main_caption.text = "New Story mode";
		byte_menu_mode = 10;

		GetComponent<new_load_game_manag> ()._New_Game_Story_Slots_Init();

	}

	public void _Button_New_Story_Slot1 () {
		//Checks if slot is occupied and if it is, it makes Are You Sure screen appear

		byte_newgame_story_slot = 1;

		if (!GetComponent<new_load_game_manag> ().bool_newgame_slot1_empty) {
			//Are You Sure?
			New_Story_AreYouSure();

		} else {
			_Button_New_Story_AreYouSure_Yes ();
			//Start
		}
	}

	public void _Button_New_Story_Slot2 () {
		//Checks if slot is occupied and if it is, it makes Are You Sure screen appear

		byte_newgame_story_slot = 2;

		if (!GetComponent<new_load_game_manag> ().bool_newgame_slot2_empty) {
			//Are You Sure?
			New_Story_AreYouSure();

		} else {
			_Button_New_Story_AreYouSure_Yes ();
			//Start
		}
	}

	public void _Button_New_Story_Slot3 () {
		//Checks if slot is occupied and if it is, it makes Are You Sure screen appear

		byte_newgame_story_slot = 3;

		if (!GetComponent<new_load_game_manag> ().bool_newgame_slot3_empty) {
			//Are You Sure?
			New_Story_AreYouSure();

		} else {
			_Button_New_Story_AreYouSure_Yes ();
			//Start
		}
	}

	public void _Button_New_Story_Slot4 () {
		//Checks if slot is occupied and if it is, it makes Are You Sure screen appear

		byte_newgame_story_slot = 4;

		if (!GetComponent<new_load_game_manag> ().bool_newgame_slot4_empty) {
			//Are You Sure?
			New_Story_AreYouSure();

		} else {
			_Button_New_Story_AreYouSure_Yes ();
			//Start
		}
	}

	public void _Button_New_Story_Slot5 () {
		//Checks if slot is occupied and if it is, it makes Are You Sure screen appear

		byte_newgame_story_slot = 5;

		if (!GetComponent<new_load_game_manag> ().bool_newgame_slot5_empty) {
			//Are You Sure?
			New_Story_AreYouSure();

		} else {
			_Button_New_Story_AreYouSure_Yes ();
			//Start
		}
	}

	public void _Button_New_Story_Slot6 () {
		//Checks if slot is occupied and if it is, it makes Are You Sure screen appear

		byte_newgame_story_slot = 6;

		if (!GetComponent<new_load_game_manag> ().bool_newgame_slot6_empty) {
			//Are You Sure?
			New_Story_AreYouSure();

		} else {
			_Button_New_Story_AreYouSure_Yes ();
			//Start
		}
	}

	void New_Story_AreYouSure () {
		//Makes Are You sure screen appear
		/*
		GameObject.Find("buttons_main").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_settings").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_graphics").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_sound").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_movement").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_actions").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_inventory").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_controls_default").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("buttons_newgame_story_areyousure").transform.localScale = new Vector3(1, 1, 1);
		*/

		gameobject_main.SetActive(false);
		gameobject_settings.SetActive(false);
		gameobject_graphics.SetActive(false);
		gameobject_sound.SetActive(false);
		gameobject_controls.SetActive(false);
		gameobject_movement.SetActive(false);
		gameobject_actions.SetActive(false);
		gameobject_inventory.SetActive(false);
		gameobject_controls_default.SetActive(false);
		gameobject_newgame.SetActive(false);
		gameobject_newgame_story.SetActive(false);
		gameobject_newgame_story_areyousure.SetActive(true);

		textui_main_caption.text = "Are you sure?";
		byte_menu_mode = 11;
	}

	public void _Button_New_Story_AreYouSure_Yes () {
		//Rewrites old save and starts new game
		_Button_Settings_Back ();
		GetComponent<new_load_game_manag> ()._Story_NewGame_Start (byte_newgame_story_slot);
	}

	public void _Button_New_Story_AreYouSure_No () {
		//Returns to New Game Story slot selection

		byte_newgame_story_slot = 0;
		_Button_NewGame_New_Story ();


	}



}
