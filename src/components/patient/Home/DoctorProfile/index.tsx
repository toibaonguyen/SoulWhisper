import React from "react";
import ContentContainer from "../../../ContentContainer";
import { Avatar, Rating } from "@mui/material";

export interface Doctor {
  id: string;
  avatar: string;
  name: string;
  medicalSpecialty: string;
  rating: number;
}

export interface OnClickDoctor {
  onClick: (id: string) => Promise<void>;
}

interface Props extends Doctor, OnClickDoctor {}

export default function DoctorProfile(props: Props) {
  return (
    <ContentContainer>
      <button
        id={props.id}
        style={{ alignSelf: "center" }}
        onClick={async () => {
          await props.onClick(props.id);
        }}
      >
        <div
          style={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            padding: 20,
            overflow: "hidden",
            textOverflow: "ellipsis",
            width: 400,
            whiteSpace: "nowrap",
          }}
        >
          <Avatar src={props.avatar} />
          <h3 style={{ marginTop: 10 }}>{props.name}</h3>
          <div>{props.medicalSpecialty}</div>

          <Rating value={props.rating} readOnly />
        </div>
      </button>
    </ContentContainer>
  );
}
