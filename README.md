# PaddleWars
Breakout[^1] style videogame developed in Unity using Unity's physics engine, 2D animation system and Scriptable objects. As the original Breakout game the goal is to remove all the colored bricks from the level by hitting them with a ball. A paddle is located in the lower part of the screen, to hit the bricks move the paddle to intersect the ball, collect powerUps such as: Multiball, StickyBall, LargePaddle, SmallPaddle, Barrier, and MegaBall to help and change the game progression.
 
![paddleWars](https://github.com/MethodCa/PaddleWars/assets/15893276/c8b6dc1a-7d94-4664-a0e9-8f522f5d4dd3)

> [!NOTE]
> - Use keyboard left, right / A, D to control the paddle.
> - Press space bar to release the ball from the paddle
> - Press and maintain space bar to move the paddle faster.

The game was developed with the mindset of maximum optimisation, CPU-intensive code was structured in the best possible way and Sprites[^2] were created from a single texture atlas; the entire game uses 3 draw calls only.

 <img src="https://github.com/MethodCa/PaddleWars/assets/15893276/4cbcf886-a4da-405e-aaa5-522dcd3107e8" width="400" height="400">

Animations were created using Unity's animation system and managed through Animators[^3].

![AnimationPaddle](https://github.com/MethodCa/PaddleWars/assets/15893276/76ab825b-b3d2-485d-a33a-c7a00a8572be)


![AnimatorsPaddle](https://github.com/MethodCa/PaddleWars/assets/15893276/20e8a792-57c2-438a-8282-bd991c88f364)


New powerUps were created for Paddlewars such as the MegaBall!

![megaBall](https://github.com/MethodCa/PaddleWars/assets/15893276/882c6f85-cc99-4595-b979-d36d2353bab1)
> [!TIP]
> New powerUps are in development (shoot and laser), you can try them by pressing the keys Z or X respectively.


> [!CAUTION]
> This video game is still under development and could contain bugs/errors.

[^1]: Atari 1976 [Breakout](https://en.wikipedia.org/wiki/Breakout_(video_game)).
[^2]: Unity Scripting API [Sprite](https://docs.unity3d.com/ScriptReference/Sprite.html)
[^2]: Unity Scripting API [Animator](https://docs.unity3d.com/ScriptReference/Animator.html)

 
