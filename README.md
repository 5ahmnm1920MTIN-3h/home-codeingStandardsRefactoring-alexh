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
1. **DRY - Don’t Repeat Yourself**
Falls mein einen Block von Code mehrmals ausführt, ist es besser diesen in eine Methode zu verpacken, und dann nur auf diese Methode zu verweisen
2. **KISS - Keep it Simple, Stupid**
Am besten ist es, wenn man den einfachsten Weg zum Ziel wählt, also unnötige Komplexität vermeiden. So ist es einfacher später sich im Code wieder einzufinden.
3. **YAGNI - You Ain’t Gonna Need It**
Variablen und Methoden die man nicht braucht, weglöschen, ansonsten wird der Code nur unübersichtlicher.
4. **Principle of least Astonishment**
Benenne Variablen und Methoden so, dass es klar ist welche Aufgabe diese erfüllen
5. **SoC - Separation of Concerns**
Codeblöcke sollten beispielweise mit einer leeren Zeile logisch getrennt werden. Bespiel: 
3 String Variablen werden deklariert
Leer
3 Integer Variablen werden deklariert

## Was versteht man unter Code Smell?
Ein Quellcode der unter „Code Smell“ leidet funktioniert zwar, ist aber simpel ausgedrückt schlecht strukturiert und schlecht formatiert.

## Recherche von 10 Code Smells die Eure Projekt betreffen können, inkl. Beschreibung und Beispiel.
1. Unnötige Namespaces: Namespaces die im Code nicht benötigt werden können problemlos gelöscht werden. Beispiel: System.Collections wird bei den meisten C# Scripts für Unity nicht gebraucht, und kann somit gelöscht werden.
2. Nichtgebrauchte Variablen: Variablen die deklariert werden aber niemals verwendet werden, sollte gelöscht werden.
3. Unnötige Debug Logs: Konsolennachrichten die nicht mehr gebraucht werden, sollten gelöscht werden, da ansonsten die Konsole unnötig zugemüllt wird. Vorallem bei einem Debug.Log in einer Update Methode die bei jedem Frame ausgeführt werden, wird die Konsole extrem voll und andere einmalige Konsoleneinträge gehen in der Menge unter.
4. Unnötige Methoden: Methoden die im gesamten Code nicht einmal ausgeführt werden, sollten gelöscht werden.
5. Magical String: Ein String Wert der mitten im Code verwendet wird sollte zuvor als eigene Variable deklariert werden. Im Code sollte diese Variable verwendet werden. Vor allem wenn dieser String öfters verwendet wird ist dies von Vorteil, da man so den Wert als Variable nur einmal ändern muss und nicht überall einzeln.
6. Magical Number: Ein numerischer Wert (Bsp: int, float, …) der mitten im Code verwendet wird sollte zuvor als eigene Variable deklariert werden. Im Code sollte diese Variable verwendet werden. Vor allem wenn dieser Wert öfters verwendet wird ist dies von Vorteil, da man so den Wert als Variable nur einmal ändern muss und nicht überall einzeln.
7. Poor formating: Ein schlecht formatierter Code ist unangenehm zu lesen und nachzuvollziehen, vor allem für andere. Beispiele sind unnötige Leerzeichen oder zu wenig oder zu viele Tabulatorstopps.
8. Falsche Variablen Benennung: Variablen müssen stets im camelCase benennt werden. Heißt ohne jegliche Leerzeichen, der erste Buchstabe klein und alle anderen eigentlich eigenständigen Wörter beginnen groß. Dies ist Teil von den Coding Standards. 
9. Falsche Methoden Benennung: Methoden müssen stets im PascalCase benennt werden. Heißt ohne jegliche Leerzeichen, der erste Buchstabe groß und alle anderen eigentlich eigenständigen Wörter beginnen ebenfalls groß. Dies ist Teil von den Coding Standards.
10. Keine Kommentare: Kommentare sind vor allem dann hilfreich, wenn andere am Code mitarbeiten oder falls man später nach einiger Zeit nochmal daran weiterarbeiten will. Man sollte also bei komplexeren Codeblöcken anmerken, welche Funktion dieser erfüllt. Allerdings sollte man nicht übertreiben. Selbsterklärenden Code sollte man nicht kommentieren.

## Development Platform
OS: Windows 10 Version: 1903 (Build 18362.476)
Unity Version: 2019.1.14f1
Visual Studio Community 2019 Version: 16.4.0
Scripting Runtime Version: .NET 4.x Equivalent
API Compatibility Level: .NET Standard 2.0

## Third Party Material
"SantaRun" Game by [smeerws](https://github.com/smeerws)