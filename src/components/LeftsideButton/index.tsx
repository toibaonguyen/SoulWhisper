// CustomButton.tsx

import React, { ReactNode } from "react";
import styles from "./index.module.css";

interface CustomButtonProps {
  children : ReactNode;
  onClick: () => void;
  onSelected: boolean;
}

const CustomButton: React.FC<CustomButtonProps> = ({
  children ,
  onClick,
  onSelected = false,
}) => {
  return (
    <button
      className={
        onSelected ?styles.onSelectedCustomButton: styles.customButton 
      }
      onClick={onClick}
    >
      {children }
    </button>
  );
};

export default CustomButton;
