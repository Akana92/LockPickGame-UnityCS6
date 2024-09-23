# Lock Pick Game

This is a simple lock-picking game made with Unity. The goal of the game is to align the pins to the correct positions within a limited amount of time using different tools. The player wins if all pins are aligned before the timer runs out. If the time reaches zero and the pins are not aligned, the player loses.

## Features
- **Timer**: A countdown timer starts when the game begins. The player must unlock the lock before the timer reaches zero.
- **Pins**: There are three pins with values that need to be set to the target value (e.g., 5). The initial values of the pins are random.
- **Tools**: The player can use three different tools (drill, hammer, and picklock) to manipulate the values of the pins:
  - **Drill**: Increases the value of the first pin by 1, decreases the value of the second pin by 1, and keeps the third pin unchanged.
  - **Hammer**: Decreases the first pin by 1, increases the second pin by 2, and decreases the third pin by 1.
  - **Picklock**: Decreases the first pin by 1, increases the second pin by 1, and increases the third pin by 1.
- **Restart Button**: After winning or losing, a pop-up screen appears with the option to restart the game.

## How to Play
1. Start the game and observe the values of the three pins.
2. Use the tools (drill, hammer, picklock) to adjust the pins' values.
3. The goal is to set all three pins to the target value (e.g., 5) before the timer reaches zero.
4. If all pins are set to the target value, you win. Otherwise, if the timer reaches zero, you lose.
5. After the game ends, you can restart by clicking the "Restart" button on the pop-up screen.
