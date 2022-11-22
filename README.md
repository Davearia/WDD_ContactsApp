When app is downloaded firstly open a command prompt in the solutions client folder i.e. WDD_ContactsApp-master\WDD_Client\client
Run **npm install** to generate the node_modules folder and files
Run **ng build --watch --output-hashing none** to compile the app
Open the vs solution file in the root folder in visual studio, I used 2022. Make sure you have multiple projects set up for WDD_Client and WDD_WebApi
If you build the solution in visual studio and run it both UI and Web API should launch
