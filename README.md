# Unity-Create-with-Code

This is the respository that holds all the code I've written while taking Unity's Create with Code courses as a part of the [Junior Programmer pathway!](https://learn.unity.com/pathway/junior-programmer)

The 5 Prototypes are based off the tutorials that the course provides, as well as the Mod the Cube, Counting Prototype, and Debug Project. I plan on publishing all of these projects to the 

Star Baker, however, is a game I created myself as I took the course. You can play it on itch.io here: https://grachay.itch.io/star-baker

##### Table of Contents  
[Star Baker](#star-baker)  
[Counting Prototype](#counting)
[Prototype 1](#1)
[Prototype 2](#2)
[Prototype 3](#3)
[Prototype 4](#4)
[Prototype 5](#5)
[Debugging Project](#debug)
[Mod the Cube](#mod)

<a name="star-baker"/>
## Star Baker

Here's a screenshot of gameplay:
![image](https://user-images.githubusercontent.com/50962446/224832525-49abb61d-6b2c-4af5-bfec-17c857a0e088.png)

This game is an action side-scroller where the player controls the astronaut with the arrow keys and has to avoid randomly generated asteroids that spawn from off-screen. I faced a lot of challenges while coding this project, which are listed below.

### The Rotation
It was really hard to get the objects to rotate across the screen in a satisfying way while also making sure that they didn't stray from their intended paths. My first instinct with this was to apply transform.Rotate with a randomly generated vector to each object, but when I did this, the objects rotated off the screen. I reasoned that this was happening because the vector was generated when the objects were created, and thus they were rotating around that point instead of rotating while moving through space.

Instead of using transform.Rotate, I was able to reach my desired effect by applying a torque force instead. I was still able to use a randomly generated vector to create different forces for each object, and I think it looks pretty good.

### The Stardust Bug
While I was testing the game, I found that if a player tried to grab a stardust powerup while they still had a stardust powerup active, the second one typically would not activate. This was a huge problem, as stardust is important to the game in order to destroy the asteroids, especially on harder difficulties.

I realized that the reason this was happening was because the stardust powerup was kept track of via a boolean and a Coroutine. The boolean would be set to true, the Coroutine would start and would wait for 4 seconds (the length of the powerup), and then the boolean would be set to false. If the powerup was activated while the Coroutine was waiting, it would set to false before the second powerup ended. 

I fixed this by stopping and restarting the Coroutine whenever a new powerup is activated. This doesn't work always, and I'd like to go back in and fix it soon, but it works most of the time.

All of the assets from the game were downloaded for free from the Unity Asset Store.

<a name="counting"/>
## Counting Prototype
This counting prototype was completed as part of the final mission checkpoint for the Create with Code course on Unity. We were given a box that counts items put inside of it and tasked with creating a game that includes counting in its functionality.

My idea was to create a game in which ingredients fell from above the screen, and the player has to sort them into different bowls. This simulates baking. The counting could come in when only a certain number of each ingredient is required for a recipe, so the extra ingredients have to go in the trash.

Because it would take me a while to find nice assets for this project, I began by creating a simple prototype that I call "Color Sort." In Color Sort, the player simply has to put the colored balls in the corresponding container, and the count for each container will go up as they do so. The game ends when a ball is sorted into the wrong colored container.

In the near future, I will go back in and finish this prototype, but I wanted to finish the Junior Programmer course instead of getting bogged down in assets.

You can play Color Sort here: https://play.unity.com/mg/other/v1-x5cl1l

<a name="1"/>
## Prototype 1

<a name="2"/>
## Prototype 2

<a name="3"/>
## Prototype 3

<a name="4"/>
## Prototype 4

<a name="5"/>
## Prototype 5

<a name="debug"/>
## Debug Project

You can check out my finished debug project here: https://play.unity.com/mg/other/build-9tb

<a name="mod"/>
## Mod the Cube

Thanks for reading!
