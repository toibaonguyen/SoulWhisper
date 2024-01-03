import React, { useContext, useEffect } from "react";
import Sidebar from "./components/Sidebar";
import Chat from "./components/Chat";
import "./index.module.scss";
import { ChatContext } from "@/context/ChatContext";

const Messenger = () => {
  const { data, dispatch } = useContext(ChatContext);
  useEffect(() => {
    //   return ()=>{
    //     if(data.chatId!=null){
    //       dispatch({type:"CHANGE_USER", payload:null})
    //     }
    // }
  }, []);
  return (
    <div
      style={{
        backgroundColor: "#a7bcff",
        height: "100vh",
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
      }}
    >
      <div
        style={{
          border: "1px solid white",
          borderRadius: "10px",
          width: "65%",
          height: "80%",
          display: "flex",
          overflow: "hidden",
        }}
      >
        <Sidebar />
        <Chat />
      </div>
    </div>
  );
};

export default Messenger;
