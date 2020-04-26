# Testing

## Manual Testing
We did a few different tests on our own that were not code based but they were user based testing. So for one we had our weapon in the game to be a bow and arrow however sometimes its quite hard to hit the enemy each time. So we implemented a gun that shot completely straight to make sure that the targets were being hit properly and taking the right amount of damage. The other thing we were able to do inside unity was to simply hit the play button and be able to use a FPS mode which allowed us to test the game from the computer instead of strapping on all the VR equipment and testing out the game.

## Unit Tests
With our game we used a game engine, Unity and then we used Visual Studio to write the code portion of our game. Unity allowed us to be able to set up our game environment and to setup how our game objects acted in the environment. With Unity there are a lot of different ways to tweak our different components and how they interact in game.



### Test 1
With the majority of our tests we used coroutines to mirror how the game was acting with the given code and then to go back and test and make sure that the game was acting how we wanted it to. The first one that we will be talking about is testing that the rotating enemies died upon getting hit with our bow. Within this we used a method to check and see if the enemy was taking damage from the event of being hit with a arrow.

### Test 2
With our game having multiple stages we needed to check that when the enemies were all dead so that we can advance to the next stage. So we made a Unit test to test to test for this and the way we did it was that we checked all of our rotating enemies took damage from the event of getting shot. Then we had a method that checked if the enemies are alive or not so then we checked to see if they were alive and if they were all dead then we would advance them onto the next stage.

### Test 3
For the third test we wanted to make sure that the arrows were hitting the kill box for the enemies. So we added a kill box variable to see if the arrows were colliding with our rotating enemies.

### Test 4
The next test we wanted to run was to make sure that the enemies were actually cleared from the game environment and that they were not just invisible. So we added instances for all 4 of our rotating enemies and then we check to see if they took damage from the arrows and if they did then we checked to see if they were still alive which meant that they were no longer in the environment and that they were completely removed from the game space.

### Test 5
For our last test we wanted to make sure that the when the enemies died that the score was being added to our score. So we made instances of the enemies and once they died we checked to see if they score had been added to the players score.