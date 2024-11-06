mergeInto(LibraryManager.library, {
    saveDataToFirestore: function (collectionName, docId, dataJson) {
    const db = firebase.firestore();
    console.log(dataJson)
    const data = JSON.parse(UTF8ToString(dataJson));
    console.log("Parsed Data:", data); // Log the data to ensure it's correct

    return db.collection(UTF8ToString(collectionName))
        .doc(UTF8ToString(docId))
        .set(data)
        .then(() => {
            console.log("Document successfully written!");
            return true;
        })
        .catch((error) => {
            console.error("Error writing document: ", error);
            return false;
        });
}
});
