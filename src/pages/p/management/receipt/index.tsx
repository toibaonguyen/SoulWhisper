import type { NextPage } from "next";
import styles from "./index.module.css";

const Rectangle: NextPage = () => {
  return (
    <div className={styles.myBody}>
      <div className={styles.rectangleDiv} />
    </div>
  );
};

export default Rectangle;
