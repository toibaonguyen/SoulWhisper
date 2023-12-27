import React, { useState } from "react";
import { addDoc, collection, serverTimestamp } from "firebase/firestore";
import { db } from "@/config/firebase";

const SendMessage = () => {
  const [message, setMessage] = useState("");

  const sendMessage = async (event) => {
    event.preventDefault();
    if (message.trim() === "") {
      alert("Enter valid message");
      return;
    }

    await addDoc(collection(db, "messages"), {
      text: message,
      createdAt: serverTimestamp(),
      uid: userId,
    });
    setMessage("");
    scroll.current.scrollIntoView({ behavior: "smooth" });
  };

  return (
    <form className="send-message" onSubmit={(event) => sendMessage(event)}>
      <label htmlFor="messageInput" hidden>
        Enter Message
      </label>
      <input
        id="messageInput"
        name="messageInput"
        type="text"
        className="form-input__input"
        placeholder="type message..."
        value={message}
        onChange={(e) => setMessage(e.target.value)}
      />
      <button type="submit">Send</button>
    </form>
  );
};
export default SendMessage;
