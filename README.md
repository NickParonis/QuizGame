# QuizGame
 a quiz game made for Unity learning purposes

## Overview
QuizGame is an interactive quiz application developed in Unity. Players can test their knowledge on various topics by answering multiple-choice questions. The game features a scoring system, a timer for each question, and progress tracking.

## Features
- Multiple-choice questions
- Scoring system to track correct answers
- Timer for each question
- Progress bar to indicate quiz completion
- Responsive UI using Unity's UI toolkit

## Getting Started

### Prerequisites
To run this project, you'll need the following software installed on your machine:
- [Unity Hub](https://unity3d.com/get-unity/download) (version [insert version here])
- [Visual Studio Code](https://code.visualstudio.com/) (optional for code editing)
- [Git](https://git-scm.com/) (for version control and cloning the repository)

### Installation
1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/QuizGame.git
2. Open the project in Unity Hub.
3. Select the project and click on **Open** to launch it in Unity.

### Usage
- Play the game by clicking on the **Play** button in the Unity Editor.
- Answer the questions by selecting one of the answer buttons.
- The score will be displayed after each question, along with the correct answer.

### Customization
- You can add new questions by creating new `QuestionSO` ScriptableObject instances:
  1. Right-click in the **Project** window.
  2. Go to **Create** > **Scriptable Objects** > **QuestionSO**.
  3. Fill in the question text, possible answers, and the index of the correct answer.
- Adjust game settings, such as timer duration and UI elements, within the Unity Editor.

## Contributing
Contributions are welcome! If you'd like to contribute to this project, please follow these steps:
1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make your changes and commit them.
4. Push to your branch and create a pull request.