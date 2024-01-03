import React, { useContext, useState } from "react";
import { signOut } from "firebase/auth";
import { UserState } from "@/redux/reducers";
import { useSelector } from "react-redux";

const Navbar = () => {
  const currentUser = useSelector((state: UserState) => state.id);

  return (
    <div
      style={{
        display: "flex",
        alignItems: "center",
        backgroundColor: "#2f2d52",
        height: "50px",
        padding: "10px",
        justifyContent: "space-between",
        color: "#ddddf7",
      }}
    >
      <span style={{ color: "#5d5b8d", fontWeight: "bold", fontSize: "24px" }}>
        Private Chat
      </span>
      {/* <div style={{ display: "flex", gap: "10px" }}>
       
      </div> */}
    </div>
  );
};

export default Navbar;
