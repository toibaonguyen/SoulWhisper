import React, { useContext } from "react";
import Cam from "../img/cam.png";
import Add from "../img/add.png";
import More from "../img/more.png";
import Messages from "./Messages";
import Input from "./Input";
import { ChatContext } from "../../../../context/ChatContext";

const Chat = () => {
  const { data } = useContext(ChatContext);

  return (
    <div
      style={{
        flex: 2,
      }}
    >
      <div
        style={{
          height: "50px",
          backgroundColor: "#5d5b8d",
          display: "flex",
          alignItems: "center",
          justifyContent: "space-between",
          padding: "10px",
          color: "lightgray",
        }}
      >
        <span>{data.user.name}</span>
        <div style={{ display: "flex", gap: "10px" }}>
          <img
            style={{ height: "24px", cursor: "pointer" }}
            src={Cam.src}
            alt=""
          />
          <img
            style={{ height: "24px", cursor: "pointer" }}
            src={Add.src}
            alt=""
          />
          <img
            style={{ height: "24px", cursor: "pointer" }}
            src={More.src}
            alt=""
          />
        </div>
      </div>

      {data.chatId && (
        <>
          <Messages />
          <Input />
        </>
      )}
    </div>
  );
};

export default Chat;
