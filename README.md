# COMP3180-final-project

Included is a rough timeline below. Fill this in from week to week to show your progress throughout semester.

## Week 1 - Selecting a Project

Complete the "Choose a Topic" survey in iLearn and paste the details here.

**Topic Details - Procedural Generation (ProcGen):**

*Initial Description* - I want to create a procedurally generated dungeon which feels recative to certain player conditions, making the player feel like the dungeon is crafted to their specific scenario rather than random every time.

*Initial Research Interests*:
* Basic procedural generation algorithms used in games.
* Item and enemy procedural generation.
* Distributed biome generation.
* Dungeon generation tools.
* Seed generation and uses - WTF is a seed and how do they work

*Potential Project 1:*

A dungeon generation algorithm which randomly generates a dungeon (Different everytime) based on a rigid set of rules. However, the dungeon should/could generate differently based on changing variables relatated to the player's situation (Reactive). This way the generated dungeon feels like it has been crafted to challenge/reward the player rather than feeling random all of the time.

*Potential Project 2:*

A dungeon building tool which contains a database of room layouts and creates a random dungeon using those rooms. Additionally it lets the user create rooms and add them to the database by providing different parameters such as chance weights and rules.

*Initial Findings:*

Begin by creating an algortihm that generates a floor plan without thinking about special rooms, objects or rules (Creates a tree/graph). Then utilize the product to add the special rooms and rules that fit your purpose (Rewards & Advancement rooms).

## Week 2 - Familiarising yourself with the tools

You need to have accepted this assignment repo and made a post here identifying a resource relevant to your topic.

**Initial Project Stages / Roadmap:**

*Stage 1:*

Research & prototype a few common dungeon generating algoriths and choose the one I feel will be more useful for my porpuses. This will be based on how well I underatnd it, how well I can modify it, and how scalable it is.

*Stage 2:*

Develop a simple difficulty statistic and the element system. Perhaps develop a small player stat system so that other variables can influence the level generation (Such as health, currency & items --- if diffulty == hard -> needed resource = hard to find).

*Stage 3:*

Utilise the difficulty and element systems to populate the dungeon that gets generated, based on the chosen element and current difficulty stat. E.G: 
* Fire Element + Hard Difficulty = More Water Hazards
* Water Element + Easy Difficulty = More Fire Hazards
* Grass Element + Neutral Difficulty = Mix of Neutral Hazards

*Stage 4:*

Thorougly test the systems in place and the project at this point in development. If errors are encountered, fix them here before continuing.

*Stage 5 (if time allows):*

Utilise the other player stats to populate the dugeon with special rooms in a manner which purposely help or hurt the player depending on the difficulty stat. This means more locked doors when higher difficulty and low in keys, or more healing rooms when low in health and easy difficulty.

**Things to look into:**

DDA - Dinamyc difficulty adjustment  bc

**IDEAS from this week**:

A dungeon in an elemental driven game where difficulty is a stat and chnages in this stat drive the enemy generation which would contrast the player's chosen element.

**What to Come Up With:**

Keep coming up with ways to influence the level generation in a manner which makes the levels feel reactive to the player's situation.



## Week 3 - Reading and prototyping

**Main Relevant Source:**

*A Hybrid Approach to Procedural Generation of Roguelikes Video Game Levels* - Article by Alexander Gellel & Penny Sweetser:

https://openresearch-repository.anu.edu.au/bitstream/1885/205015/5/FDG20_PCG-submitted.pdf


**Result From Source:**

As a result fo the source above, I've started to get a clear idea on how to tackle and structure my project. I've been summarising and document the stuff I find useful fomr the article within a document in the repo "Approaches to Proc Gen", for further information refer to that document.

**Final Project Idea** - *(As of Now)*:

To create an algorithm which procedurally generates a dungeon for an elemental driven game where difficulty is an ever changing statistic which is influenced by the players' actions. The algorithm will utilise the player's chosen element and combine it with the difficulty statistic to generate the level in a manner which creates a reactive feel to the gameplay.

*Example:*

If the player is utilising the FIRE element, the game would use a simple *Rock, Paper, Scissor* system to match the difficulty stat to the chosen element and generate the level accordingly. So if the difficulty stat were to be higher, then the algorithm would spawn more WATER obtacles and enemies since fire is weak to water.


## Week 4 - Reading and prototyping

**Focus For the Week:**

This week I will focus in beggining to attempt to protype some different algorithms to see how well I can understand them and implement them. This should help me discover which algortihm I wish to use and expand on it.

**Initial Prototypes:**

To begin this process, I reserached how the original 'Binding of Isaac' did it and attempted to recreate the basic algorithm (Check unity project for progress). I utilised an online article which goes in depth on how the original flash game did it.

*Article:* https://www.boristhebrave.com/2020/09/12/dungeon-generation-in-binding-of-isaac/

As I began to attempt my implementation, I quickly felt like I was overcomplicating things, which was slowing down my prgress, and thus decided to research a bit more. By doing so I stumbled upon a youtube tutorial which goes over how to generate a level of similar nature to the binding of isaac. I followed the simple tutorial to get me started and now plan on altering the algorithm to make it fit my requirements.

*Video:* https://www.youtube.com/watch?v=qAf9axsyijY&t=3s

As a result of both the video and the article I now have a prototype which generates a very simple dungeon in steps. We'll call this prototype the 'Isaac' prototype. The prototype works in the following manner:

* Firstly the protoype functions around having a database of possible rooms with dfferent door locations. These roms are created in unity and each room is of the same size. Additionally, each door within the room has a spawn point which will be responsible of generating the connecting room.

* Upon start each spawn point has an opening direction which corresponds to the direction in which the new room would need an opening (this connects two rooms together). The algorithm then takes this opening direction and utilises it to randomly select one of the rooms in the database which has an opening in that direction.

* Once a room is selected, that room is instantiated at the position of the spawn point. This means that the spawnpoint has done its job.

* As a result of a new room being instatiated, if the chosen room has more than the one opening, this also means that a new spawn point is instatiated and thus this spawnpoint will choose a new room and repeat the process.

**Thoughts on Algorithm:**

Initially, this algorithm seems to be incredibly simple and effective. It gets the job done and it does it in a relativelly simple manner. However, there are various problems which concern me.

*Problems:*
 nk


## Week 5 - Presentations

## Week 6 - Presentations

## Week 7 - Finalising your Research Report

Its been a few weeks since I last documented any progress, so here is what I've been working on:

*Part One - Presentation:*

Firstly I focused on getting my presesntation video going. To do this I focused on reflecting on my work and previous discussions. This helped me rescope and narrow down my project idea.

For more on this check the preso in the documentation folder.

*Part Two - Messing Around With My Learnings:*

After the presentations, I had a deadline for another project (COMP3151) which was apporaching fast. I saw this as an opportunity to try and use some of my learnings and utilise them to create some procedural level generation which was kinda similar to what I want to produce.

During this week, I worked together with one of my team memeber to get proc gen working. This was increadibly helpful as my team member had some previous experience with the topic and we were able to work together to create a working algortihm.

The algorithm is basic and unrefined, but it accomplished our goals. However, as relevance to this project goes only the framework applies here, as the goals of that algorithm are different to what I plan to achieve.

For more information, check the COMP3151 repository, and the added screenshots within the documentation folder. **Add Screeenies to the folder**

*Part Three - Research Report:*

Finally, I've been working on taking on the feedback recieved during my presentation, and do a bit more research to fill in my research report. 

The goal here is to find a few more quality sources that will help me understand a couple more techniques for achieving proc gen, and to use this new knowledge as well as the feedback I got to create a more refined goal with specific deliverables.

This should help me to get a clear roadmap, and then development will begin.

## Mid-semster break 1

## Mid-semster break 2
During this time, I utilised the opportunity of the MACS GameJam to attempt and create some algorithm that procedurally generate mazes and levels. I got most of them working just need to connect the grid algorithm and fix the infinite spawning of the maze algorithm. For better checks look at game jam repo.

## Week 8 - Developing your Project

## Week 9 - Developing your Project

## Week 10 - Developing your Project

## Week 11 - Evaluation

**Things to Rememeber**

Try and find developers to test my tool

Need humna evaluation for everyone to be happy



## Week 12 - Evaluation

## Week 13 - Finalising your Project Report and Deliverables

