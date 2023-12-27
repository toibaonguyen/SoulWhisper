

import firebase from "firebase/compat/app";
import "firebase/firestore";

const firebaseConfig = {
    apiKey: "AIzaSyBMRDC2fIaFp3S1rE_lc7kz79It-gEKbpA",
    authDomain: "soulwhisper-chatapp.firebaseapp.com",
    projectId: "soulwhisper-chatapp",
    storageBucket: "soulwhisper-chatapp.appspot.com",
    messagingSenderId: "488005725532",
    appId: "1:488005725532:web:f37c615103ebc7d50de599",
    measurementId: "G-R4RNQ59HQ6"
};

if (!firebase.apps.length) {
    firebase.initializeApp(firebaseConfig);
}
const db = firebase.firestore;
export default {db}

