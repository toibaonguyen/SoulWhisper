import { Doctor } from "@/components/Home/DoctorProfile";
import React from "react";

export interface IAppointment {
  id: string;
  type: string;
  startTime: Date;
  endTime: Date;
  diagnosis: string | undefined;
  prescription: string | undefined;
  status: string;
  notes: string | undefined;
  doctorId: string;
  patientId: string;
}

export default function Appointment(props: IAppointment) {
  return (
    <div
      itemID={props.id}
      style={{
        margin: 10,
        borderRadius: 15,
        borderWidth: 1,
        borderColor: "black",
        width: "auto",
        backgroundColor: "white",
        padding:10
      }}
    >
      {props.id}
    </div>
  );
}
