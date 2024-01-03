import React, {
  ReactElement,
  ReactHTMLElement,
  ReactNode,
  useContext,
  useEffect,
  useRef,
} from "react";
import { ChatContext } from "../../../../context/ChatContext";
import { useSelector } from "react-redux";
import { UserState } from "@/redux/reducers";

interface props {
  message: any;
}

const Message = ({ message }: props) => {
  const currentUserID = useSelector((state: UserState) => state.id);
  const ref = useRef<HTMLDivElement>(null);

  useEffect(() => {
    ref.current?.scrollIntoView({ behavior: "smooth" });
  }, [message]);

  return (
    <div
      ref={ref}
      style={
        message.senderId === currentUserID
          ? {
              display: "flex",
              gap: "20px",
              marginBottom: "20px",
              backgroundColor: "white",
              flexDirection: "row-reverse",
              borderRadius:5,
            }
          : {
              display: "flex",
              gap: "20px",
              marginBottom: "20px",
              backgroundColor: "#85C1E9",
              borderRadius:5,
            }
      }
    >
      <div
        style={{
          display: "flex",
          flexDirection: "column",
          color: "gray",
          fontWeight: 300,
        }}
      >
        {/* <span>{(message.date == Date.now())?"just now":message.date}</span> */}
      </div>
      <div
        style={{
          maxWidth: "80%",
          display: "flex",
          flexDirection: "column",
          gap: "10px",
        }}
      >
        <p>{message.text}</p>
        {message.img && <img src={message.img} alt="" />}
      </div>
    </div>
  );
};

export default Message;
