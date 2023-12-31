import React, { useEffect, useRef } from "react";
import styles from "./index.module.css";
import Logo from "../../../public/logo.png";
import Image from "next/image";
export default function Statistics() {
  return (
    <div className={styles.bgimg}>
      <div className={styles.topleft}></div>
      <div className={styles.middle}>
        <h1>COMING SOON</h1>
        <hr className={styles.myhr} />
      </div>
      <div className={styles.bottomleft}>
        <p>SoulWhisper</p>
      </div>
    </div>
  );
}
