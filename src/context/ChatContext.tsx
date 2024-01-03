import { UserState } from "@/redux/reducers";
import {
    Dispatch,
  ReactNode,
  createContext,
  useContext,
  useReducer,
  useState,
} from "react";
import { useSelector } from "react-redux";

export const ChatContext = createContext<Chat>({data: {chatId:null, user: null},dispatch: ()=>null });

interface Chat {
  data: { chatId: string|null ; user: any };
  dispatch:Dispatch<{
    type: string;
    payload: any;
}>
}

interface Children {
  children: ReactNode;
}

export const ChatContextProvider = ({ children }: Children) => {
  const currentUser=useSelector((state:UserState)=>state)
  const INITIAL_STATE = {
    chatId: null,
    user: {},
  };

  const chatReducer = (
    state: { chatId: string | null; user: any },
    action: { type: string; payload: {id:string} }
  ) => {
    switch (action.type) {
      case "CHANGE_USER":
        return {
          user: action.payload,
          chatId:
            currentUser.id as string > action.payload.id
              ? currentUser.id + action.payload.id
              : action.payload.id + currentUser.id,
        };

      default:
        return state;
    }
  };

  const [state, dispatch] = useReducer(chatReducer, INITIAL_STATE);

  return (
    <ChatContext.Provider value={{ data: state, dispatch }}>
      {children}
    </ChatContext.Provider>
  );
};
