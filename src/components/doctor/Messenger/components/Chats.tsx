//ngon m bug đi đcm

import React, {
  useContext,
  useEffect,
  useState,
  FunctionComponent,
} from "react";
import { useSelector } from "react-redux";
import { doc, onSnapshot } from "firebase/firestore";
import { db } from "../../../../config/firebase";
import { ChatContext } from "../../../../context/ChatContext";
import { UserState } from "@/redux/reducers"; // Assuming RootState is your root Redux state type
import { Button } from "@mui/material";

interface Chat {
  date: any;
  lastMessage?: { text: string };
  userInfo: {
    id: string;
  };
}

const Chats: FunctionComponent = () => {
  const [chats, setChats] = useState<[string, Chat][]>([]);

  // Adjust the useSelector to correctly extract the user state
  const currentUser = useSelector((state: UserState) => state);
  const { dispatch } = useContext(ChatContext);

  useEffect(() => {
    if (currentUser.id) {
      const unsub = onSnapshot(doc(db, "userChats", currentUser.id), (doc) => {
        const data = doc.data();
       // console.log("ee bailao bu du:", data?.chats[0].date as Date);
        if (data) {
          setChats(
            (Object.entries(data.chats) as [string, Chat][])?.sort((a, b) => b[1].date.toMillis() - a[1].date.toMillis()).filter(
              (item, index, self) =>
                index ==
                self.findIndex((t) => t[1].userInfo.id == item[1].userInfo.id)
            )
          );
        }
      });

      return () => {
        unsub();
      };
    }
  }, []);

  const handleSelect = (u: Chat["userInfo"]) => {
    console.log("dume", u);
    dispatch({ type: "CHANGE_USER", payload: u });
  };

  return (
    <div className="chats" style={{ overflowY: "auto", maxHeight: "70%" }}>
      {chats?.sort((a, b) => b[1].date.toMillis() - a[1].date.toMillis())
        .map((chat) => (
          <Button
            style={{
              display: "flex",
              alignItems: "center",
              gap: "10px",
              color: "white",
              cursor: "pointer",
            }}
            key={chat[1].userInfo.id}
            onClick={() => handleSelect(chat[1].userInfo)}
          >
            <div>
              <span style={{ fontSize: "18px", fontWeight: 500 }}>
                {chat[1].userInfo.id}
              </span>
              <p
                style={{
                  fontSize: "14px",
                  color: "lightgray",
                }}
              >
                {chat[1].lastMessage?.text}
              </p>
            </div>
          </Button>
        ))}
    </div>
  );
};

export default Chats;
