# Unity WebGL with Firebase Integration

## Introduction
This project demonstrates how to integrate Unity WebGL with Firebase to create a web-based application. The application leverages Unity for building interactive WebGL content and Firebase for backend services, including real-time data handling.

## Features
- **Connecting Unity WebGL with Firebase**: Seamless integration of Firebase services with Unity WebGL builds.
- **Real-time Database Integration**: Store and retrieve data in real-time using Firebase Realtime Database.

## Installation and Setup

### Setting Up Unity for WebGL Builds
1. **Install Unity**: Ensure you have the latest version of Unity installed.
2. **Create a New Project**: Open Unity and create a new project.
3. **Switch to WebGL Platform**: Go to `File > Build Settings`, select `WebGL`, and click `Switch Platform`.

### Setting Up Firebase Project
1. **Create a Firebase Project**: Go to the Firebase Console and create a new project.
2. **Enable Firebase Services**: Enable Authentication, Realtime Database, and Cloud Storage from the Firebase Console.

### Adding Firebase SDK to Unity
1. **Add Firebase SDK**: Add these code to the head tag in index.html after build WebGL. Also add Firebase config in script tag below. Also add CRUD here!
  ```
  <script src="https://www.gstatic.com/firebasejs/8.10.0/firebase-app.js"></script>
  <script src="https://www.gstatic.com/firebasejs/8.10.0/firebase-firestore.js"></script>
  ```
  ```
  const firebaseConfig = {
    Add your Firebase project configuration here!
  }
  firebase.initializeApp(firebaseConfig);
  const db = firebase.firestore();

  function saveDataToFirestore(collectionName, docId, dataJson) {
    const data = JSON.parse(dataJson);
    return db.collection(collectionName).doc(docId).set(data)
        .then(() => {
            console.log("Document successfully written!");
            return true; 
        })
        .catch((error) => {
            console.error("Error writing document: ", error);
            return false; 
        });
  }
  ```
2. **Add WebGL Template folder and webgl_enscripten.json file**: Create a WebGLTemplates\webgl_emscripten.json inside Assets folder.
3. **Add Plugin**: Inside Assets, add folder Plugins/WebGL and create file SomethingPlugin.jslib (Depend on the language you want to use). Write code to call API here. Look at FirestorePlugin.jslib file in source code for more information.
4. **Call External Function**: Use C# to call function written by other languages in jslib file.


### Building the Unity WebGL App
1. **Build Settings**: Go to `File > Build Settings`, select `WebGL`, and click `Build`.
2. **Deploy to Firebase Hosting**: Follow the Firebase Hosting setup to deploy your WebGL build.

### Deploying to Firebase Hosting
1. **Install Firebase CLI**: Install the Firebase CLI tool.
2. **Initialize Firebase Hosting**: Run `firebase init` and select Hosting.
3. **Deploy**: Use `firebase deploy` to deploy your WebGL build.

## Configuration
### Firebase Hosting Setup
- **Hosting Configuration**: Configure `firebase.json` for hosting settings.
    ```json
    {
      "hosting": {
        "public": "build",
        "ignore": [
          "firebase.json",
          "**/.*",
          "**/node_modules/**"
        ]
      }
    }
    ```

## Troubleshooting
- **API Keys Issues**: Ensure API keys are correctly added to your project.
- **CORS Issues**: Configure CORS settings in Firebase to allow requests from your WebGL app.

## Contributing
- **Pull Requests**: Submit pull requests for new features or bug fixes.
- **Reporting Issues**: Report issues via the project's issue tracker.

## License
This project is licensed under the MIT License.
