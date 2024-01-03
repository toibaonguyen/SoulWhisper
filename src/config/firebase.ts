
import { initializeApp } from "firebase/app";
import { getStorage } from "firebase/storage";
import { getFirestore } from "firebase/firestore";


const firebaseConfig = {
    apiKey: "AIzaSyBMRDC2fIaFp3S1rE_lc7kz79It-gEKbpA",
    authDomain: "soulwhisper-chatapp.firebaseapp.com",
    projectId: "soulwhisper-chatapp",
    storageBucket: "soulwhisper-chatapp.appspot.com",
    messagingSenderId: "488005725532",
    appId: "1:488005725532:web:f37c615103ebc7d50de599",
    measurementId: "G-R4RNQ59HQ6"
};

export const app = initializeApp(firebaseConfig);
export const storage = getStorage();
const db =  getFirestore();

console.log("db????????: ",db);
export {db}