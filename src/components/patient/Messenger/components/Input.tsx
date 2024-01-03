import React, { PureComponent, memo, useContext, useState } from "react";
import Img from "../img/img.png";
import Attach from "../img/attach.png";
import { ChatContext } from "../../../../context/ChatContext";
import {
  arrayRemove,
  arrayUnion,
  collection,
  doc,
  getDoc,
  getDocs,
  onSnapshot,
  query,
  serverTimestamp,
  setDoc,
  Timestamp,
  updateDoc,
  where,
} from "firebase/firestore";
import { db, storage } from "../../../../config/firebase";
import { v4 as uuid } from "uuid";
import { getDownloadURL, ref, uploadBytesResumable } from "firebase/storage";
import { useSelector } from "react-redux";
import { UserState } from "@/redux/reducers";
import { arrayIncludes } from "@mui/x-date-pickers/internals/utils/utils";

const Input = memo(() => {
  const [text, setText] = useState("");
  const [img, setImg] = useState<any>(null);

  const currentUserID = useSelector((state: UserState) => state.id);
  const { data } = useContext(ChatContext);

  const handleSend = async () => {
    if (!text) {
      return;
    }
    if (img) {
      const storageRef = ref(storage, uuid());

      const uploadTask = uploadBytesResumable(storageRef, img);

      uploadTask.on(
        "state_changed",
        (error) => {
          //TODO:Handle Error
        },
        () => {
          getDownloadURL(uploadTask.snapshot.ref).then(async (downloadURL) => {
            await updateDoc(doc(db, "chats", data.chatId as string), {
              messages: arrayUnion({
                id: uuid(),
                text,
                senderId: currentUserID,
                date: Timestamp.now(),
                img: downloadURL,
              }),
            });
          });
        }
      );
    } else {
      await updateDoc(doc(db, "chats", data.chatId as string), {
        messages: arrayUnion({
          id: uuid(),
          text,
          senderId: currentUserID,
          date: Timestamp.now(),
        }),
      });
      if (!(await getDoc(doc(db, "userChats", data.user.id))).exists()) {
        await setDoc(doc(db, "userChats", data.user.id), { chats: [] });
      }

      if (
        !(await getDoc(doc(db, "userChats", currentUserID as string))).exists()
      ) {
        await setDoc(doc(db, "userChats", currentUserID as string), {
          chats: [],
        });
      }
      await updateDoc(doc(db, "userChats", data.user.id), {
        chats: arrayUnion({
          ["lastMessage"]: {
            text,
          },
          ["date"]: Timestamp.now(),
          userInfo: { id: currentUserID },
        }),
      });
      await updateDoc(doc(db, "userChats", currentUserID as string), {
        chats: arrayUnion({
          lastMessage: {
            text,
          },
          date: Timestamp.now(),
          userInfo: { id: data.user.id },
        }),
      });
      // const collectionRef = collection(db, "userChats",data.user.id)
      // const q = query(collectionRef);
      // const docSnap = await getDocs(q);
      // docSnap.forEach((doc) => {
      //   console.log("okok",doc.data());
      // });
    }

    setText("");
    setImg(null);
  };
  return (
    <div
      style={{
        height: "50px",
        backgroundColor: "white",
        padding: "10px",
        display: "flex",
        alignItems: "center",
        justifyContent: "space-between",
      }}
    >
      <input
        style={{
          width: "100%",
          border: "none",
          outline: "none",
          color: "#2f2d52",
          fontSize: "18px",
        }}
        type="text"
        placeholder="Type something..."
        onChange={(e) => setText(e.target.value)}
        value={text}
      />
      <div style={{ display: "flex", alignItems: "center", gap: "10px" }}>
        <img
          src={Attach.src}
          alt=""
          style={{ height: "24px", cursor: "pointer" }}
        />
        <input
          type="file"
          style={{ display: "none" }}
          id="file"
          onChange={(e) => {
            setImg(e.target.files ? e.target.files[0] : null);
          }}
        />
        <label htmlFor="file">
          <img src={Img.src} alt="" />
        </label>
        <button
          style={{
            border: "none",
            padding: "10px 15px",
            color: "white",
            backgroundColor: "#8da4f1",
            cursor: "pointer",
          }}
          onClick={handleSend}
        >
          Send
        </button>
      </div>
    </div>
  );
});

export default Input;
