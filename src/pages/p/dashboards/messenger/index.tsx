import { useEffect, useRef, useState } from "react";
import {
  query,
  collection,
  orderBy,
  onSnapshot,
  limit,
} from "firebase/firestore";
import  db  from "@/config/firebase";
import ChatBox from "./ChatBox";


export default function A(){
  return <ChatBox/>
}
