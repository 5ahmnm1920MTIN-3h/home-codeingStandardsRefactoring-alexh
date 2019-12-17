# home-codeingStandardsRefactoring-alexh

## Was versteht man unter dem Begriff „Refactoring“?
Beim Refactoring oder Refaktorieren des Quellcodes geht es darum diesen zu „bereinigen“. Das heißt diesen richtig zu formatieren und dabei diverse Coding Standards und Naming Conventions zu beachten. Wichtig ist, dass der Code weiterhin problemlos seine bisherige Funktion ausführt. Dadurch ist der Code leserlicher und somit zugänglicher für andere und einfacher in Zukunft damit weiterzuarbeiten. 

## Welche Vorteile/Nachteile birgt Refactoring?
Vorteile sind die bessere Lesbarkeit, Verständlichkeit Wartbarkeit und Erweiterbarkeit, zusätzlich wird der Aufwand von zukünftigen Fehleranalysen und Erweiterungen gesenkt. 
Ein Nachteil ist der Arbeitsaufwand der mit dem Refactoring kommt, außerdem könnte es passieren, dass man etwas falsch macht und der Code nicht mehr so funktioniert wie vorher.

## Welche Schritte sind beim Refactoring zu beachten?
1. Testcase definieren
2. Den definierten Testcase vor dem Refactor überprüfen, diesen Stand commiten
3. Nur eine einzelne Änderung (Refactor) vornehmen
4. Überprüfen ob der besagte Testcase nach wie vor problemlos funktioniert
5. Falls ja, dann Änderung commiten

## Was sind die Prinzipien von „gutem“ Code?
**1. DRY - Don’t Repeat Yourself**  
Falls mein einen Block von Code mehrmals ausführt, ist es besser diesen in eine Methode zu verpacken, und dann nur auf diese Methode zu verweisen.  
**2. KISS - Keep it Simple, Stupid**  
Am besten ist es, wenn man den einfachsten Weg zum Ziel wählt, also unnötige Komplexität vermeiden. So ist es einfacher später sich im Code wieder einzufinden.  
**3. YAGNI - You Ain’t Gonna Need It**  
Variablen und Methoden die man nicht braucht, weglöschen, ansonsten wird der Code nur unübersichtlicher.    
**4. Principle of least Astonishment**  
Benenne Variablen und Methoden so, dass es klar ist welche Aufgabe diese erfüllen.    
**5. SoC - Separation of Concerns**  
Codeblöcke sollten beispielweise mit einer leeren Zeile logisch getrennt werden.    
Bespiel:  
```c#
private string menuScene;
private string mainScene;
private string endScene;
// Hier die Leerzeile
private float moveSpeed;
private float obstacleSpeed;
private float scrollSpeed;
```
## Was versteht man unter Code Smell?
Ein Quellcode der unter „Code Smell“ leidet funktioniert zwar, ist aber simpel ausgedrückt schlecht strukturiert und schlecht formatiert.

## Beschreibung von 10 Code Smells
### 1. Unnötige Namespaces   
Namespaces die im Code nicht benötigt werden können problemlos gelöscht werden. Beispiel: System.Collections wird bei den meisten C# Scripts für Unity nicht gebraucht, und kann somit gelöscht werden.  
```c#
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
```
### 2. Ungebrauchte Variablen  
Variablen die deklariert werden aber niemals verwendet werden, sollte gelöscht werden.  
```c#
[SerializeField] private GameObject canvasObjectOut;
[SerializeField] private CanvasGroup canvasOut;
private float startAlphaOut;
private float endAlphaOut;
private float durationOut;

// sollte am Ende gelöscht werden
public string testDebugMessage = "Hello World";
``` 
### 3. Unnötige Debug Logs 
Konsolennachrichten die nicht mehr gebraucht werden, sollten gelöscht werden, da ansonsten die Konsole unnötig zugemüllt wird. Vorallem bei einem Debug.Log in einer Update Methode die bei jedem Frame ausgeführt werden, wird die Konsole extrem voll und andere einmalige Konsoleneinträge gehen in der Menge unter.  
```c#
private void DebugTest() 
{
	Debug.Log(testDebugMessage);
}
``` 
### 4. Unnötige Methoden
Methoden die im gesamten Code nicht einmal ausgeführt werden, sollten gelöscht werden.  
```c#
// Wird am Ende nicht mehr gebraucht, sollte also gelöscht werden
public void ExampleDelay()
{
	StartCoroutine(Example());
}

// Wird am Ende nicht mehr gebraucht, sollte also gelöscht werden
IEnumerator Example()
{
	print(Time.time);
	yield return new WaitForSeconds(2);
	print(Time.time);
}
``` 
### 5. Magical String
Ein String Wert der mitten im Code verwendet wird sollte zuvor als eigene Variable deklariert werden. Im Code sollte diese Variable verwendet werden. Vor allem wenn dieser String öfters verwendet wird ist dies von Vorteil, da man so den Wert als Variable nur einmal ändern muss und nicht überall einzeln.  
```c#
public void LoadScene()
{
	SceneManager.LoadScene("MainScene");
}
```
Sollte so gelöst werden:  
```c#
private string mainSceneName = "MainScene";

public void LoadScene()
{
	SceneManager.LoadScene(mainSceneName);
}
```
### 6. Magical Number 
Ein numerischer Wert (Bsp: int, float, …) der mitten im Code verwendet wird sollte zuvor als eigene Variable deklariert werden. Im Code sollte diese Variable verwendet werden. Vor allem wenn dieser Wert öfters verwendet wird ist dies von Vorteil, da man so den Wert als Variable nur einmal ändern muss und nicht überall einzeln.  
```c#
public void playAnimationAufbauDelayed()
{
	lockedButton.interactable = false;
	Invoke("playAnimationAufbau", 2);
	StartCoroutine(enableButtonWait());
}
```
Sollte so gelöst werden:  
```c#
private void int animationAufbauDelay = 2;

public void playAnimationAufbauDelayed()
{
	lockedButton.interactable = false;
	Invoke("playAnimationAufbau", animationAufbauDelay);
	StartCoroutine(enableButtonWait());
}
```
### 7. Poor formating  
Ein schlecht formatierter Code ist unangenehm zu lesen und nachzuvollziehen, vor allem für andere. Beispiele sind unnötige Leerzeichen oder zu wenig oder zu viele Tabulatorstopps.  
```c#
IEnumerator Start()
    {   

            while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
                CloneRaindrop();
			}  


		}

private void CloneRaindrop()
{
        float raindropSize = Random.Range(raindropMinSize, raindropMaxSize);

    CollectibleRaindrop raindropClone = (CollectibleRaindrop)Instantiate(raindropPrefab, transform.position, transform.rotation);


        raindropClone.transform.SetParent(raindropParent.transform);
    raindropClone.transform.localPosition = new Vector3(Random.Range(xMinPos, xMaxPos), yPos, 0f);
        raindropClone.transform.localScale = new Vector3(raindropSize, raindropSize, 0);
        raindropClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Random.Range(yMaxSpeed, yMinSpeed));
    }
    }
```
### 8. Falsche Variablen Benennung   
Variablen müssen stets im camelCase benennt werden. Heißt ohne jegliche Leerzeichen, der erste Buchstabe klein und alle anderen eigentlich eigenständigen Wörter beginnen groß. Dies ist Teil von den Coding Standards.  
```c#
[SerializeField] float MinSpawnDelay = 1.0f;
[SerializeField] float MaxSpawnDelay = 5.0f;
``` 
Sollte so gelöst werden:
```c#
[SerializeField] float minSpawnDelay = 1.0f;
[SerializeField] float maxSpawnDelay = 5.0f;
```
### 9. Falsche Methoden Benennung  
Methoden müssen stets im PascalCase benennt werden. Heißt ohne jegliche Leerzeichen, der erste Buchstabe groß und alle anderen eigentlich eigenständigen Wörter beginnen ebenfalls groß. Dies ist Teil von den Coding Standards.  
```c#
private void move()
{
		var deltaX = Input.GetAxis(AXISHORIZONTAL) * Time.deltaTime * moveSpeed;
		var newPosX = Mathf.Clamp(transform.position.x + deltaX, boundaryLeft, boundaryRight);

		transform.position = new Vector2(newPosX, transform.position.y);
}
```
Sollte so gelöst werden: 
```c#
private void Move()
{
		var deltaX = Input.GetAxis(AXISHORIZONTAL) * Time.deltaTime * moveSpeed;
		var newPosX = Mathf.Clamp(transform.position.x + deltaX, boundaryLeft, boundaryRight);

		transform.position = new Vector2(newPosX, transform.position.y);
}
```
### 10. Unperformante IF-Statements 
Falls man mehrere zusammenhängende IF Fälle auflistet sollten diese mit if, if else und else zusammengekettet werden. So bricht der Computer beim Durchgehen der verschiedenen Fälle vorzeitig ab, sobald er den zutreffenden Fall gefunden hat. Wenn man allerdings alle Fälle als einzelne IF Statements schreibt, geht der Computer alle durch, auch wenn bereits der zutreffende gefunden wurde. Heißt der Computer verschwendet ünnötige Rechenleistung.
Alternative könnte man auch falls es sich anbietet ein Switch Statement verwenden, dies benötigt weniger Code.
```c#
public void SetQuality(float sliderIndex)
{
	int qualityIndex;
	qualityIndex = Mathf.RoundToInt(sliderIndex);
	QualitySettings.SetQualityLevel(qualityIndex);

	if (qualityIndex == 0)
	{
		label.text = "SEHR NIEDRIG";
	}

	if (qualityIndex == 1)
	{
		label.text = "NIEDRIG";
	}

	if (qualityIndex == 2)
	{
		label.text = "MITTEL";
	}

	if (qualityIndex == 3)
	{
		label.text = "HOCH";
	}

	if (qualityIndex == 4)
	{
		label.text = "SEHR HOCH";
	}

	if (qualityIndex == 5)
	{
		label.text = "ULTRA";
	}
}
```
Sollte so gelöst werden: 
```c#
public void SetQuality(float sliderIndex)
{
	int qualityIndex;
	qualityIndex = Mathf.RoundToInt(sliderIndex);
	QualitySettings.SetQualityLevel(qualityIndex);

	switch (qualityIndex)
	{
		case 0:
			label.text = "SEHR NIEDRIG";
			break;
		case 1:
			label.text = "NIEDRIG";
			break;
		case 2:
			label.text = "MITTEL";
			break;
		case 3:
			label.text = "HOCH";
			break;
		case 4:
			label.text = "SEHR HOCH";
			break;
		case 5:
			label.text = "ULTRA";
			break;
		default:
			break;
	}
}
```
## Development Platform
OS: Windows 10 Version: 1903 (Build 18362.476)  
Unity Version: 2019.1.14f1  
Visual Studio Community 2019 Version: 16.4.0  
Scripting Runtime Version: .NET 4.x Equivalent  
API Compatibility Level: .NET Standard 2.0  
  
Copyright by alexh 

## Third Party Material
["SantaRun"](https://https://github.com/5ahmnm1920MTIN-3h/home-toRefac-SantaRun-smeerws) Game by [smeerws](https://github.com/smeerws)
  
# Santa Run

### Project description: 
This is a simple 2D side-scroll game. The Santa runs from left to right and has to avoid some obstacles by jumping over them.
The game ends when the Santa hits an obstacle.  The goal is to avoid as many obstacles as possible.

### Development platform: 
Windows 10, Unity version 2019.1.14f1, Visual Studio Community 2017, Scripting Runtime Version: .NET 4.0

### Target platform: 
WebGl and Standalone, RefRes: 1920 * 1080


### Visuals: 
<div>
<img src = "./Screenshots/sketch-SantaRun.JPG" width = "500">
</div>

[![SANTA RUN](https://i9.ytimg.com/vi/2C74XxBkFfI/mq1.jpg?sqp=CNWnze8F&rs=AOn4CLBrmO-tJ3gQ2BNeMxvrmQcsIhhcgQ)](https://www.youtube.com/embed/2C74XxBkFfI "Santa RUN")

https://www.youtube.com/embed/2C74XxBkFfI

### Necessary setup/execution steps: 
For playing the game go to: 
* WebGL: https://hs-teaching.github.io/WegGL-SantaRun/
* Standalone (.exe): Clone project and publish as Standalone

For development: Clone this project. 

### Third party material: 
* This game is based on the game Santa Run developed by Raja Biswas in the Udemy-course Unity 2018 Game Developmen by Example 
[Unity 2018 Game Development by Example](https://www.udemy.com/course/unity-2d-game-development-by-example/).
* Sprites are used from https://www.gameart2d.com/santa-claus-free-sprites.html


### Project state: 
Program is working correctly, no errors, refactoring is needed.
Refactoring needed: 
* del not used namespaces
* del unused variables
* del needless debugs
* del needless comments
* del unused methods
* rename variables (coding standards)
* rename methods (coding standards)
* fix poor conditional clauses
* fix poor formating
* replace magic string
* replace magic number

### Limitations: 
Only one level is implemented. 

### Lessons Learned: 
* Create 2D Scenes
* Use Quads for moving Backgrounds (Textures instead of Sprites)
* Use Particle System for snowing effect.
* Use Scene Management for switching between Scenes
* Create and control Animations (Animation, Animator and Scripts)
* Use the singelton pattern
* Spawn objects
* Use UI elements and manipulate UI elements with scrips


Copyright by smeerws