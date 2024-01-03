import React from "react";
import Navbar from "./Navbar";
import Search from "./Search";
import Chats from "./Chats";

const Sidebar = () => {
  return (
    <div style={{ flex: 1, backgroundColor: "#3e3c61", position: "relative" }}>
      <Navbar />
      {/* <Search /> */}
      <Chats />
    </div>
  );
};

export default Sidebar;
