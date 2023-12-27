import React from "react";

const Message = ({ message }) => {
  const [user] = useAuthState(auth);

  return (
    <div
      className={`chat-bubble ${message.uid === user.uid ? "right" : ""}`}>
      {/* <img
        className="chat-bubble__left"
        src={message.avatar}
        alt="user avatar"
      /> */}
      <div className="chat-bubble__right">
        <p className="user-name">{message.uid}</p>
        <p className="user-message">{message.text}</p>
      </div>
    </div>
  );
};
export default Message;