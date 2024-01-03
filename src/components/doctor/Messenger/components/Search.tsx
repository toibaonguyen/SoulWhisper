import React, { useContext, useState } from "react";
import {
  collection,
  query,
  where,
  getDocs,
  setDoc,
  doc,
  updateDoc,
  serverTimestamp,
  getDoc,
} from "firebase/firestore";
import { db } from "..//../../../config/firebase";
import { useSelector } from "react-redux";
import { UserState } from "@/redux/reducers";
import { Doctor, GetDoctorById } from "@/apis/Doctor";
import { GetPatientById, Patient } from "@/apis/Patient";
import { Button } from "@mui/material";
import { ChatContext } from "@/context/ChatContext";
const Search = () => {
  const { dispatch } = useContext(ChatContext);
  const [userID, setUserID] = useState("");
  const [user, setUser] = useState<Doctor | Patient | null>(null);
  const [err, setErr] = useState(false);
  const { role, id } = useSelector((state: UserState) => state);

  const handleSearch = async () => {
    try {
      setErr(false);
      console.log("TAO LA: ", id);
      if (role == "PATIENT") {
        const a = await GetDoctorById(userID);
        console.log("USER IS: ", a);
        setUser(a);
      } else if (role == "DOCTOR") {
        const a = await GetPatientById(userID);
        console.log("USER IS: ", a);
        setUser(a);
      }
    } catch (err) {
      console.log("CONMEMAY NHA LOZ FIREBASE ", err);
      setErr(true);
    }
  };

  const handleKey = async (e: React.KeyboardEvent<HTMLInputElement>) => {
    console.log("TAO DANG SEARCH");
    e.code === "Enter" && (await handleSearch());
  };

  const handleSelect = async () => {
    //check whether the group(chats in firestore) exists, if not create

    const combinedId =
      (id as string) > (user?.id as string)
        ? (((id as string) + user?.id) as string)
        : (((user?.id as string) + id) as string);
    dispatch({ type: "CHANGE_USER", payload: user });
    try {
      const res = await getDoc(doc(db, "chats", combinedId));

      if (!res.exists()) {
        //create a chat in chats collection
        await setDoc(doc(db, "chats", combinedId), { messages: [] });

        //create user chats
        await updateDoc(doc(db, "userChats", id as string), {
          [combinedId + ".userInfo"]: {
            id: user?.id,
          },
          [combinedId + ".date"]: serverTimestamp(),
        });

        await updateDoc(doc(db, "userChats", user?.id as string), {
          [combinedId + ".userInfo"]: {
            id: id,
          },
          [combinedId + ".date"]: serverTimestamp(),
        });
      }
    } catch (err) {}
  };
  return (
    <div style={{ borderBottom: "1px solid gray" }}>
      <div style={{ padding: "10px" }}>
        <input
          type="text"
          placeholder="Find a user"
          onKeyDown={handleKey}
          onChange={(e) => setUserID(e.target.value)}
          value={userID}
        />
      </div>
      {err && <span>User not found!</span>}
      {user && (
        <Button
          style={{
            padding: "10px",
            display: "flex",
            alignItems: "center",
            gap: "10px",
            color: "white",
            cursor: "pointer",
          }}
          onClick={handleSelect}
        >
          <div style={{ fontSize: "18px", fontWeight: 500 }}>
            <span>{user.name}</span>
          </div>
        </Button>
      )}
    </div>
  );
};

export default Search;
