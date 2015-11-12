using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextCtrl : MonoBehaviour {

	public Text text;
	private enum States {
		cell, mirror, lock_0, sheet_0, lock_1, sheet_1, cell_mirror, 
		corridor_0,
		stair_0, floor, closet_door,
		corridor_1, stair_1, in_closet,
		corridor_2, stair_2,
		corridor_3, countyard

	};
	private States myState;
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if (myState == States.cell)               {cell ();} 
		else if (myState == States.sheet_0)       {sheet_0();} 
		else if (myState == States.lock_0)        {lock_0();} 
		else if (myState == States.sheet_1)       {sheet_1();} 
		else if (myState == States.lock_1)        {lock_1();} 
		else if (myState == States.mirror)        {mirror();} 
		else if (myState == States.cell_mirror)   {cell_mirror();} 
		else if (myState == States.corridor_0)    {corridor_0();} 
		else if (myState == States.stair_0)       {stair_0();} 
		else if (myState == States.floor)         {floor();} 
		else if (myState == States.closet_door)   {closet_door();} 
		else if (myState == States.corridor_1)    {corridor_1();} 
		else if (myState == States.in_closet)     {in_closet();} 
		else if (myState == States.stair_1)       {stair_1();} 
		else if (myState == States.corridor_2)    {corridor_2();} 
		else if (myState == States.stair_2)       {stair_2();} 
		else if (myState == States.corridor_3)    {corridor_3();} 
		else if (myState == States.countyard)     {courtyard();} 

	}

	void cell () {
		text.text = "Press S to Sheet -- M to Mirror -- L to Lock \n";
		if (Input.GetKeyDown(KeyCode.S))      {myState = States.sheet_0;} 
		else if (Input.GetKeyDown(KeyCode.M)) {myState = States.mirror;} 
		else if (Input.GetKeyDown(KeyCode.L)) {myState = States.lock_0;} 
	}

	void sheet_0 () {
		text.text = "Press R to Cell \n";
		if (Input.GetKeyDown(KeyCode.R))      {myState = States.cell;} 
	}

	void lock_0 () {
		text.text = "Press R to Cell \n";
		if (Input.GetKeyDown(KeyCode.R))      {myState = States.cell;} 
	}

	void sheet_1 () {
		text.text = "Press R to Cell \n";
		if (Input.GetKeyDown(KeyCode.R))      {myState = States.cell_mirror;} 
	}
	
	void lock_1 () {
		text.text = "Press R to Cell - O to Open \n";
		if (Input.GetKeyDown(KeyCode.O))      {myState = States.corridor_0;} 
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell_mirror;} 
	}

	void mirror () {
		text.text = "Press R to Cell -- T to Mirror \n";
		if (Input.GetKeyDown(KeyCode.R))      {myState = States.cell;} 
		else if (Input.GetKeyDown(KeyCode.T)) {myState = States.cell_mirror;} 
	}
	
	void cell_mirror () {
		text.text = "Press S to Sheet -- L to Lock \n";
		if (Input.GetKeyDown(KeyCode.S))      {myState = States.sheet_1;} 
		else if (Input.GetKeyDown(KeyCode.L)) {myState = States.lock_1;} 
	}

	void corridor_0 () {
		text.text = "You are in Corridor (freedom)! " + 
			        "Press S to Stair -- F to Floor -- C to Closet \n";
		if (Input.GetKeyDown(KeyCode.S))           {myState = States.stair_0;} 
		else if (Input.GetKeyDown(KeyCode.F))      {myState = States.floor;} 
		else if (Input.GetKeyDown(KeyCode.C))      {myState = States.closet_door;} 
	}

	void stair_0 () {
		text.text = "Press R to Return \n";
		if (Input.GetKeyDown(KeyCode.R))           {myState = States.corridor_0;} 
	}

	void floor () {
		text.text = "Press R to Return -- H to Corridor \n";
		if (Input.GetKeyDown(KeyCode.R))           {myState = States.corridor_0;} 
		else if (Input.GetKeyDown(KeyCode.H))      {myState = States.corridor_1;} 
	}

	void closet_door () {
		text.text = "Press R to Return \n";
		if (Input.GetKeyDown(KeyCode.R))           {myState = States.corridor_0;} 
	}

	void corridor_1 () {
		text.text = "Press S to Stair -- P to Closet \n";
		if (Input.GetKeyDown(KeyCode.S))           {myState = States.stair_1;} 
		else if (Input.GetKeyDown(KeyCode.P))      {myState = States.in_closet;} 
	}

	void stair_1 () {
		text.text = "Press R to Corridor \n";
		if (Input.GetKeyDown(KeyCode.R))           {myState = States.corridor_1;} 
	}

	void in_closet () {
		text.text = "Press R to Corridor -- D to Corridor \n";
		if (Input.GetKeyDown(KeyCode.R))           {myState = States.corridor_2;} 
		else if (Input.GetKeyDown(KeyCode.D))      {myState = States.corridor_3;} 
	}

	void corridor_2 () {
		text.text = "Press B to Closet -- S to Stair \n";
		if (Input.GetKeyDown(KeyCode.B))           {myState = States.in_closet;} 
		else if (Input.GetKeyDown(KeyCode.S))      {myState = States.stair_2;} 

	}

	void stair_2 () {
		text.text = "Press R to Corridor \n";
		if (Input.GetKeyDown(KeyCode.R))           {myState = States.corridor_2;} 
	}

	void corridor_3 () {
		text.text = "Press U to Closet -- S to Courtyard \n";
		if (Input.GetKeyDown(KeyCode.U))           {myState = States.in_closet;} 
		else if (Input.GetKeyDown(KeyCode.S))      {myState = States.countyard;} 
	}

	void courtyard () {
		text.text = "You dressed as the normal people! " + 
			        "Press P to Play again \n";
		if (Input.GetKeyDown(KeyCode.P))           {myState = States.cell;} 
	}
}
