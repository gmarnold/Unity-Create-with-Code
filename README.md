# Unity-Create-with-Code

This is the respository that holds all the code I've written while taking Unity's Create with Code courses as a part of the [Junior Programmer pathway!](https://learn.unity.com/pathway/junior-programmer)

The 5 Prototypes are based off the tutorials that the course provides, as well as the Mod the Cube, Counting Prototype, and Debug Project. I plan on publishing all of these projects to Unity so that I can provide gameplay links here soon.

Star Baker, however, is a game I created myself as I took the course. You can play it on itch.io here: https://grachay.itch.io/star-baker

## Star Baker

Here's a video of gameplay:

https://user-images.githubusercontent.com/50962446/232926442-03b4d9b5-d7b7-4594-8013-80ce042cbcd1.mp4

This game is an action side-scroller where the player controls the astronaut with the arrow keys and has to avoid randomly generated asteroids that spawn from off-screen. I faced a lot of challenges while coding this project, which are listed below.

### Rotation
It was really hard to get the objects to rotate across the screen in a satisfying way while also making sure that they didn't stray from their intended paths. My first instinct with this was to apply transform.Rotate with a randomly generated vector to each object, but when I did this, the objects rotated off the screen. I reasoned that this was happening because the vector was generated when the objects were created, and thus they were rotating around that point instead of rotating while moving through space.

Instead of using transform.Rotate, I was able to reach my desired effect by applying a torque force instead. I was still able to use a randomly generated vector to create different forces for each object, and I think it looks pretty good.

### The Stardust Bug
While I was testing the game, I found that if a player tried to grab a stardust powerup while they still had a stardust powerup active, the second one typically would not activate. This was a huge problem, as stardust is important to the game in order to destroy the asteroids, especially on harder difficulties.

I realized that the reason this was happening was because the stardust powerup was kept track of via a boolean and a Coroutine. The boolean would be set to true, the Coroutine would start and would wait for 4 seconds (the length of the powerup), and then the boolean would be set to false. If the powerup was activated while the Coroutine was waiting, it would set to false before the second powerup ended. 

I fixed this by stopping and restarting the Coroutine whenever a new powerup is activated. This doesn't work always, and I'd like to go back in and fix it soon, but it works most of the time.

### Flipping Animation
A similar problem occurred when the player crashed into an asteroid immediately after crashing into one - the flipping animation that plays wouldn't always trigger. I thought this was caused by the same problem at first, as a Coroutine starts when the player crashes into an asteroid, but implementing the same fix by stopping and restarting the Coroutine when the player crashes into an asteroid didn't seem to completely fix the problem.

After doing some research online and playing around with the animation itself, I found that unchecking the "exit time" box on the transition from the Running to the Flipping animation fixed the problem. This was because it was running through the entire Running animation before transitioning to the Flipping animation, but the Running animation is rather long. So sometimes, the Flipping animation wouldn't get to run before the Coroutine was done, and it wouldn't happen at all.

All of the assets from the game were downloaded for free from the Unity Asset Store.

## Counting Prototype

![colorsort](https://user-images.githubusercontent.com/50962446/232927417-7c770c9e-52d7-49e0-87e7-182e0030c9fa.PNG)

This counting prototype was completed as part of the final mission checkpoint for the Create with Code course on Unity. We were given a box that counts items put inside of it and tasked with creating a game that includes counting in its functionality.

My idea was to create a game in which ingredients fell from above the screen, and the player has to sort them into different bowls. This simulates baking. The counting could come in when only a certain number of each ingredient is required for a recipe, so the extra ingredients have to go in the trash.

Because it would take me a while to find nice assets for this project, I began by creating a simple prototype that I call "Color Sort." In Color Sort, the player simply has to put the colored balls in the corresponding container, and the count for each container will go up as they do so. The game ends when a ball is sorted into the wrong colored container.

In the near future, I will go back in and finish this prototype, but I wanted to finish the Junior Programmer course instead of getting bogged down in assets.

You can play Color Sort here: https://play.unity.com/mg/other/v1-x5cl1l

## Prototype 1 - The Driver's Seat

![driversseat](https://user-images.githubusercontent.com/50962446/232928344-d880d533-97f4-4043-ba6a-0fec9678151b.png)

This is a game where you play as a driver of a red truck! We used this project to gain understanding of the camera, player controls, and using Unity assets.

## Prototype 2 - Food Fight!

![foodfight](https://user-images.githubusercontent.com/50962446/232928365-e4cff361-b92c-497d-9658-b91ddc942019.png)

This is a top-down view game where the player shoots cookies at animals coming from the top of the screen in order to feed them. In this project, I learned basic gameplay features, randomly generating game objects, and collision detection. 

## Prototype 3 - Running Through the Forest

![frunning](https://user-images.githubusercontent.com/50962446/232928389-f442e4f2-392a-4d59-b21b-8ddb04617f32.png)

This is a side-scrolling game where the player has to jump to avoid obstacles that approach from the right-side of the screen. Here, I learned about using audio and particle effects to enhance gameplay, as well as making the background repeating.

## Prototype 4 - Luigi Wins by Doing Nothing

![image](https://user-images.githubusercontent.com/50962446/232928168-0503f301-a270-41c6-a7eb-c72cf4b21136.png)

In this game, the camera follows the player, who is represented as a ball that has to avoid oncoming waves of enemy balls without falling off the edge of the map. Throughout this project I learned about gameplay mechanics like increasing difficulty through waves, powerups, and better camera control.

## Prototype 5 - Clicky Mouse

![clickymouse](https://user-images.githubusercontent.com/50962446/232928398-9df71a45-d57e-4d65-90c0-eb49031be874.png)

This game requires the player to tap the foods that jump up from the bottom of the screen - and avoid the skulls. This project was my favorite as I learned about UI, menus, difficulty settings, and keeping score.

## Debug Project
This was a simple project where we were provided buggy code that we had to fix. I had fun with this one, as simple as it was!

You can check out my finished debug project here: https://play.unity.com/mg/other/build-9tb

## Mod the Cube
In this project, the cube's features like rotation and color change over time. This was a simpler, more self-guided project.

Thanks for reading!
