# Unity-SimpleTestingGame
Simple testing game where I apply some good code practices like heritance, polymorfism, a singleton pattern, etc.

## Compatible Platforms
- PC, Mac & Linux Standalone.

## Controls
- Start/Resume game: **[Enter]**.
- Exit/Pause game: **[Scape]**.
- Shoot: **[Left Mouse Button]**.
- Look/Aim: **[Mouse Movement]**.
- Change weapon: **[Space]**.

## Main Features
- Project created with **Unity 2018.4.18f1**.
- The game consists of defending a position from the attack of some evil cubes, for a certain time.
- The player will be at a central point on the scenary, and will be able to look around, but not move.
- The player will have a sight to aim at, and will be able to shoot with the left button.
- The player will have a 'mirror', with which he will see what is happening behind his back.
- The stage is composed of an open environment with a floor where the player is placed. Enemy cubes will come from far away, appearing gradually and in the direction of the player.
- The cubes, depending on the type, will have a colour, a size, a behaviour and a life points. As the player takes life from the cubes, the colour of the cubes will get darker and then they will explode.
- If a cube reaches the player, it will explode and cause the player to lose a variable amount of life, depending on the type of cube.
- The following types of cubes will exist:
<br>**Simple Cubes**: Medium size and medium speed. They advance towards the player in a straight line. They have an average amount of life and take an average amount of life away.
<br>**Jumping Cubes**: Small, lifeless cubes that do little damage, but are occasionally capable of jumping.
<br>**Zig-zag Cubes**: They advance a number of steps towards the player, change direction to the left or right (alternating each time), and after another number of steps in that direction, they continue to advance towards the player, and repeat the sequence. Average lifespan, average speed, and average damage.
<br>**Big Cubes**: Bigger, slower, more alive, and will do more damage.
<br>**Titan cubes**: Huge, very slow, and very much alive. Only one of these can appear at a time, and after eliminating a certain number of the other cubes. It will do a lot of damage.
- Each type of cube will have a probability of appearance, except the Titan, which will be based on cube eliminations. There will be an interval of appearances, and a maximum of live cubes on the screen.
- The player will have 3 types of weapons:
<br>**Machine gun**: High firing rate, each projectile does low damage, medium projectile dispersion.
<br>**Sniper**: Low rate of fire, each projectile deals high damage, very low dispersion of projectiles.
<br>**Shotgun**: Medium firing rate, fires several projectiles per shot, medium projectile damage, high projectile dispersion.
- You can change weapons using the space bar.
- The game ends when the player loses all his life or resists until time runs out.
- The application will have an initial menu, where you can start the game or exit the application.
- There will be a menu during the game, which will be invoked by pressing the Escape key, which will pause the game, and allow you to resume it, or leave it and return to the initial menu.
- The player, during the game, will have a HUD in which he can see the time remaining, the life he has and the weapon selected.

## Screenshots
![Screenshot1](https://github.com/santiandrade/Unity-SimpleTestingGame/blob/master/Screenshots/Gameplay.png?raw=true)
