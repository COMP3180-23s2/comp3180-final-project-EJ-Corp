**ALGORITHM EXPLANATION**

*Component Description:*
* Grid:
    * Holds Reference to middle cell

Step 1 - Generate a Grid: 

* Algorithm takes a grid width & height within the inspector
* Before generating the grid the middle position of the grid is found by diving both the
 	  width and height in half - producing the middle coordinate.
* Once middle found the algorithm generates a cell at 0,0 and names the cell with it's 	  	  
	  position within the grid.
* After this the process is repeated in a loop generating all of the cells within a 	   	  
      coloumn (based from the height input) and then moving unot the next column up until the 	  
      algortihm reaches the width input provided.
* NOTE: if the coordinate matches the middle position the cell gets stored as a variable to be used during the next step.

Step 2 - Spawn First Room:

* First instatiate the the spawn room (+ room) in the middle position stored form step 1.
* Once instatiated, tell the cell the room is on that that cell is now occupied, and that the cell contains a room.
* Let the spawn room store the current grid.

Step 3 - Choose First Path (Recursion Starts):

* 