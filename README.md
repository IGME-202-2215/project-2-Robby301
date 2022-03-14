# Project Asteroid / SHMUP

### Student Info

-   Name: Robert Gregory Disbrow
-   Section: 02

### Description

This project involves trying to create my own version of the video game Asteroids using no assistance from Unity's default methods. That just means that I did not use Unity's hit detection method(s), instead creating my own using the AABB (axis aligned bounding box) method. I also created custom acceleration and decelleration for the ship. Everything else trys to replicate the original game as close as possible. The goal is to try to get a high score by shooting the asteroids while avoiding the asteroids. Lose three lives and the game is over.

### User Responsibilities

-   Use either the Up-Arrow or the W key to move the ship forward
-   Use either the Right-Arrow or the D key to rotate the ship clockwise
-   Use either the Left-Arrow or the A key to rotate the ship counter-clockwise
-   Use the space bar to shoot bullets at the asteroids

### Known Issues

The hit box seems pretty unfair when it comes to the large sized asteroids, but that could just be because of the AABB collision type (or my implementation of it at least).

### Requirements not completed

-   The bullets aren't necessarily on a timer, instead the game restricts there being more than 2 bullets on the screen at one time. So you could still probably spam bullets if you're close enough to an asteroid
-   The asteroids don't have two stages, there are three stages. And when you go from one stage to the next, I programmed the spawning asteroids to not follow the original path of the parent asteroid. Instead the newly spawned asteroids choose a random 360 degree rotation and move in that direction (I did this because it seemed more like an explosion which I liked, but I was unsure if it breaks requirements for the assignment).
-   There is only one image of the asteroid, no different variations. The only difference between the stages is that they are scaled to different sizes.
-   Because I have three stages instead of two I have changed how the points work. The largest asteroid gives 10 points, the middle gives 20 then the smallest gives 30.
-   In regards to my sources, I downloaded the ship and asteroid from a website that had both of them in it. Now I can't find that website, so I can't list them in my sources.
-   No comments within code

### Sources

-   Bullets: https://assetstore.unity.com/packages/2d/textures-materials/abstract/warped-shooting-fx-195246
