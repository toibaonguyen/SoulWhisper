import { FirestoreError, doc, onSnapshot } from "firebase/firestore";
import React, { useContext, useEffect, useState } from "react";
import { ChatContext } from "../../../../context/ChatContext";
import { db } from "../../../../config/firebase";
import Message from "./Message";

const Messages = () => {
  const [messages, setMessages] = useState<any>([]);
  const { data } = useContext(ChatContext);

  useEffect(() => {
    const unSub = onSnapshot(
      doc(db, "chats", data.chatId as string),
      (doc) => {
        if (doc.exists() && doc.data()) {
          const datas = doc.data();
          if (datas.messages && Array.isArray(datas.messages)) {
            setMessages(datas.messages);
          } else {
            setMessages(datas.messages);
          }
        } else {
          setMessages([]);
        }
      },
      (e: FirestoreError) => {
        console.error("LOI TELE:", e);
      }
    );

    return () => {
      unSub();
    };
  }, [data.chatId]);

  return (
    <div
      style={{
        backgroundColor: "#ddddf7",
        padding: "10px",
        height: "calc(100% - 160px)",
        overflow: "scroll",
      }}
    >
      {messages?.map((m: { id: React.Key | null | undefined }) => (
        <Message message={m} key={m.id} />
      ))}
    </div>
  );
};

export default Messages;
