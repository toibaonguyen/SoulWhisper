import React, { useEffect, useState } from "react";
import Box from "@mui/system/Box";
import ContentContainer from "@/components/ContentContainer";
import { Autocomplete, Grid, Stack, TextField } from "@mui/material";
import { styled } from "@mui/system";
import ContentItem from "../ContentItem";
import Card from "@mui/material";
import Appointment, { IAppointment } from "./Appointment";
import { appointment1s } from "./testData";
const AppointmentStatuses = [
  "NOT_OCCURRED",
  "OCCURRED",
  "CANCELED",
  "RESCHEDULED",
  "ONGOING",
];
const AppointmentTypes = [
  "FIXED_TIME",
  "FLEXIBLE_SCHEDULING",
  "PRIORITY_SCHEDULING",
  "FOLLOW_UP",
  "EMERGENCY",
];

export default function Appointments() {
  const [status, SetStatus] = useState<string | null>(null);
  const [type, SetType] = useState<string | null>(null);
  const [appointments, SetAppointments] = useState<IAppointment[]>([]);
  useEffect(() => {
    SetAppointments(appointment1s);
  }, []);
  return (
    <Box>
      <Stack spacing={2}>
        <ContentContainer>
          <h4>Order by:</h4>
          <div style={{ display: "flex", flexDirection: "row" }}>
            <Autocomplete
              value={status}
              onChange={(event: any, newValue: string | null) => {
                SetStatus(newValue);
              }}
              id="controllable-statuses"
              options={AppointmentStatuses}
              sx={{ width: 300 }}
              renderInput={(params) => <TextField {...params} label="Status" />}
            />
            <Autocomplete
              value={type}
              onChange={(event: any, newValue: string | null) => {
                SetType(newValue);
              }}
              id="controllable-types"
              options={AppointmentTypes}
              sx={{ width: 300, marginLeft: 5 }}
              renderInput={(params) => <TextField {...params} label="Type" />}
            />
          </div>
        </ContentContainer>
        {
          (appointments.length>0&&type!=null&&status!=null)&&(
           <Stack gap={2}>
              {appointments.map((a) => {
                if (a.type == type && a.status == status) {
                  return (
                    <Appointment
                      id={a.id}
                      type={a.type}
                      startTime={a.startTime}
                      endTime={a.endTime}
                      prescription={a.prescription}
                      notes={a.notes}
                      doctorId={a.doctorId}
                      patientId={a.patientId}
                      diagnosis={a.diagnosis}
                      status={a.status}
                    />
                  );
                }
              })}
           </Stack >
          )
        }
        
      </Stack>
    </Box>
  );
}
