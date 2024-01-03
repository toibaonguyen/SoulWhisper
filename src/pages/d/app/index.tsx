// App.js
import Image from "next/image";
import React, { useReducer } from "react";
import styles from "./index.module.css";
import LeftsideButton from "@/components/LeftsideButton";
import Logo from "../../../../public/logo.png";
import Home from "@/components/patient/Home";
import Appointments from "@/components/doctor/Appointments";
import Statistics from "@/components/patient/Statistics";
import Account from "@/components/doctor/Account";
import Habits from "@/components/patient/Habits";
import Receipts from "@/components/patient/Receipts";
import Registrations from "@/components/patient/Registrations";
import Messager from "@/components/doctor/Messenger"
import { ChatContext, ChatContextProvider } from "@/context/ChatContext";
import Achievements from "@/components/doctor/Achievements";


interface AppState {
  home: boolean;
  appointment: boolean;
  messenger: boolean;
  statistics: boolean;
  account: boolean;
  profile: boolean;
  habit: boolean;
  registrations: boolean;
  receipts: boolean;
}
type Action =
  | { type: "CHOOSE_HOME" }
  | { type: "CHOOSE_APPOINTMENT" }
  | { type: "CHOOSE_MESSENGER" }
  | { type: "CHOOSE_STATISTICS" }
  | { type: "CHOOSE_ACCOUNT" }
  | { type: "CHOOSE_PROFILE" }
  | { type: "CHOOSE_HABIT" }
  | { type: "CHOOSE_REGISTRATIONS" }
  | { type: "CHOOSE_RECEIPTS" };
const appReducer = (state: AppState, action: Action) => {
  switch (action.type) {
    case "CHOOSE_HOME":
      return {
        home: true,
        appointment: false,
        messenger: false,
        statistics: false,
        account: false,
        profile: false,
        habit: false,
        registrations: false,
        receipts: false,
      };
    case "CHOOSE_APPOINTMENT":
      return {
        home: false,
        appointment: true,
        messenger: false,
        statistics: false,
        account: false,
        profile: false,
        habit: false,
        registrations: false,
        receipts: false,
      };
    case "CHOOSE_MESSENGER":
      return {
        home: false,
        appointment: false,
        messenger: true,
        statistics: false,
        account: false,
        profile: false,
        habit: false,
        registrations: false,
        receipts: false,
      };
    case "CHOOSE_STATISTICS":
      return {
        home: false,
        appointment: false,
        messenger: false,
        statistics: true,
        account: false,
        profile: false,
        habit: false,
        registrations: false,
        receipts: false,
      };
    case "CHOOSE_ACCOUNT":
      return {
        home: false,
        appointment: false,
        messenger: false,
        statistics: false,
        account: true,
        profile: false,
        habit: false,
        registrations: false,
        receipts: false,
      };
    case "CHOOSE_PROFILE":
      return {
        home: false,
        appointment: false,
        messenger: false,
        statistics: false,
        account: false,
        profile: true,
        habit: false,
        registrations: false,
        receipts: false,
      };
    case "CHOOSE_HABIT":
      return {
        home: false,
        appointment: false,
        messenger: false,
        statistics: false,
        account: false,
        profile: false,
        habit: true,
        registrations: false,
        receipts: false,
      };
    case "CHOOSE_REGISTRATIONS":
      return {
        home: false,
        appointment: false,
        messenger: false,
        statistics: false,
        account: false,
        profile: false,
        habit: false,
        registrations: true,
        receipts: false,
      };
    case "CHOOSE_RECEIPTS":
      return {
        home: false,
        appointment: false,
        messenger: false,
        statistics: false,
        account: false,
        profile: false,
        habit: false,
        registrations: false,
        receipts: true,
      };

    default:
      return state;
  }
};

function App() {
  const initialState = {
    home: true,
    appointment: false,
    messenger: false,
    statistics: false,
    account: false,
    profile: false,
    habit: false,
    registrations: false,
    receipts: false,
  };
  const [appState, dispatch] = useReducer(appReducer, initialState);
  return (
    <ChatContextProvider>
    <div className={styles.container}>
      <div>
        <div className={styles["left-side"]}>
          {
          /* Nội dung phía bên trái */
          }
          <div
            style={{
              display: "flex",
              flexDirection: "row",
              alignItems: "center",
            }}
          >
            <Image
              src={Logo}
              alt="Logo.png"
              style={{
                maxHeight: 50,
                maxWidth: 50,
                alignSelf: "center",
                borderRadius: 50,
              }}
            />

            <h2 style={{ marginLeft: 15 }}>Welcome</h2>
          </div>

          <div className={styles["button-container"]}>
            <h3>Home</h3>
            <LeftsideButton
              onSelected={appState.home}
              onClick={() => {
                dispatch({ type: "CHOOSE_HOME" });
              }}
            >
              Home
            </LeftsideButton>
            <h3>Dashboard</h3>
            <LeftsideButton
              onSelected={appState.appointment}
              onClick={() => {
                dispatch({ type: "CHOOSE_APPOINTMENT" });
              }}
            >
              Appointments
            </LeftsideButton>
            <LeftsideButton
              onSelected={appState.messenger}
              onClick={() => {
                dispatch({ type: "CHOOSE_MESSENGER" });
              }}
            >
              Messenger
            </LeftsideButton>
            <LeftsideButton
              onSelected={appState.statistics}
              onClick={() => {
                dispatch({ type: "CHOOSE_STATISTICS" });
              }}
            >
              Statistics
            </LeftsideButton>
            <h3>Management</h3>
            <LeftsideButton
              onSelected={appState.account}
              onClick={() => {
                dispatch({ type: "CHOOSE_ACCOUNT" });
              }}
            >
              Account
            </LeftsideButton>

            <LeftsideButton
              onSelected={appState.habit}
              onClick={() => {
                dispatch({ type: "CHOOSE_HABIT" });
              }}
            >
              Achievements
            </LeftsideButton>
            <LeftsideButton
              onSelected={appState.registrations}
              onClick={() => {
                dispatch({ type: "CHOOSE_REGISTRATIONS" });
              }}
            >
              Registrations
            </LeftsideButton>
            <LeftsideButton
              onSelected={appState.receipts}
              onClick={() => {
                dispatch({ type: "CHOOSE_RECEIPTS" });
              }}
            >
              Receipts
            </LeftsideButton>
          </div>
        </div>
      </div>
      <div className={styles["right-side"]}>
        {appState.home && <Home />}
        {appState.appointment && <Appointments />}
        {appState.messenger &&<Messager/>}
        {appState.statistics && <Statistics />}
        {appState.account && <Account />}
        {appState.habit && <Achievements />}
        {appState.registrations && <Registrations />}
        {appState.receipts && <Receipts />}
      </div>
    </div>
    </ChatContextProvider>
  );
}

export default App;
