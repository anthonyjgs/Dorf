# Dorf
## Play: https://anthonygs.itch.io/dorf

## Summary:
Dorf is a 2D wave-defence platform fighter hybrid. Players control a fantasy dwarven hero that is defending a dwarven train from attacking goblins. The game is inspired by platform fighters like Brawlhalla, and was an exercise in replicating some of the mechanics for a small singleplayer game.

I also took this game project as an opportunity to experiment with being as modular as I could and learn more about creating reusable components that could be applied to different objects to share functionality, instead of using inheritance. Because of this, the player and the ai use the exact same components for movement, attacking, and health, requiring only adjustments to the variables made visible in the editor for them. Theoretically, this should make it more efficient to add additional enemy types.

This game was made in Unity as my final project for CS50's introduction to game development class. This was a completely solo project, so outside of the engine itself and its provided components, all code, art, and music were created by me.

## What I Would Change:
Through experimentation, I have learned a lot from this project. I can also see now many ways to improve. My state machine was intended to be modular, and in a way it was, but I see a refactor for the player's state manager and the goblin's state manager would allow me to clean up the code of the actual states themselves. Likewise, I avoided global variables because I know they can often create big problems, but I do see that making something like the game state itself into a global variable would make for slightly more optimal code.

I also learned that modularity, while it is a lot of fun, its added complexity is time consuming. I knew that I would likely not have time enough to include multiple enemy types, but I designed the code around this expectation anyway. This decision taught me a lot, which was the primary goal, but if I were to focus on simply making the best game I could within the time constraints, like for game jam, then I would have avoid the additional complexity of modularizing everything, saving it for simple cases or only that which I knew I would get good use out of. The time saved would've perhaps allowed me to improve other aspects of the game, like giving the enemies a good option for fighting the player in the air (which they are extremely limited to do in this build), or saving high scores.
