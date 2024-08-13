www.linkedin.com/in/samuel-sátiro
<h1>Card Game - Job Test</h1>
<h3>Unity 2022.3.40 or higher</h3>

<br>

![Media 13_08_2024 12-09-23](https://github.com/user-attachments/assets/adb5d8dd-a12a-4ac1-ac8c-ee19f54b2d86)

<h2>How to initialize?</h2>
In the project there is no need to start with a specific scene, it has scripts that manage the correct initialization of the scenes. <br>

![Media 13_08_2024 10-53-22](https://github.com/user-attachments/assets/cfef4a4f-fe67-45a1-895e-5d07ade7d803)

This script is responsible for loading the <b>GameManager scene (persistent)</b> after pressing PLAY.
![Media 13_08_2024 10-54-00](https://github.com/user-attachments/assets/09ab9eea-8aad-44c1-8151-605ece398cdb)

After loading the <b>GameManager (persistent)</b> scene, it has scripts that will load the other scenes.
![Media 13_08_2024 10-54-36](https://github.com/user-attachments/assets/6a72a00c-5e2b-4874-9ae1-976d1dd0d1b6)

<h2>How to add a card to the deck?</h2>

![Media 13_08_2024 12-00-57](https://github.com/user-attachments/assets/72da6b11-6dda-4336-85df-a217c0e967e8)

<h2>How to create a new deck?</h2>

![Media 13_08_2024 12-05-49](https://github.com/user-attachments/assets/61585067-f323-47ca-aaf7-e278078567ec)

<h2>How to change the rotation of the card when placed?</h2>

![Media 13_08_2024 12-12-09](https://github.com/user-attachments/assets/9c4b1564-23a5-481b-b51c-d89310c4342f)

<h2>Script information</h2>

Scripts responsible for checking feedback and activating events. (For example: when a card is added, when the game starts...)

![Media 13_08_2024 12-15-17](https://github.com/user-attachments/assets/2c5ab955-9745-4f58-bac2-e5a1a276e32f)

Script responsible for creating a singleton of ScriptableObjects, allowing access to information from ScriptableObjects directly, without the need to declare reference variables.

![Media 13_08_2024 12-15-43](https://github.com/user-attachments/assets/67f276f8-293a-41bb-b64a-aac041389338)

These scripts allow you to create items for your game; in this project, for example, an item was created for a card. In addition, you can also display information from ScriptableObjects in the user interface (UI).

![Media 13_08_2024 12-16-09](https://github.com/user-attachments/assets/5a331b5a-06a4-4b6b-b4e4-f40c10ace292)

This script is responsible for loading the GameManager scene.

![Media 13_08_2024 12-16-27](https://github.com/user-attachments/assets/3393876e-263f-4ae7-8e4f-2c59f7ad99a2)

Scripts used as tools, based on ScriptableObject, to facilitate various modifications in the game, such as rotating cards and loading scenes, among others.

![Media 13_08_2024 12-16-48](https://github.com/user-attachments/assets/8a468bfb-de1d-40fa-ac11-064e16785114)

Interface used to reset the game.

![Media 13_08_2024 12-17-02](https://github.com/user-attachments/assets/b5d8150a-9000-46de-a0e3-2296a6e493f6)

Pooling system that can be applied to any type of class; in this project, it is used to generate cards.

![Media 13_08_2024 12-17-16](https://github.com/user-attachments/assets/5a0edb35-05be-4faf-81e8-9cb4bf217d31)

