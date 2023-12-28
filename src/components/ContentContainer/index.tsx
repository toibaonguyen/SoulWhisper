// CustomButton.tsx

import React, { ReactNode } from "react";
import styles from "./index.module.css";

interface CustomButtonProps {
  children: ReactNode;
}

const CustomButton: React.FC<CustomButtonProps> = ({ children }) => {
  return <div className={styles.container}>{children}</div>;
};

export default CustomButton;
