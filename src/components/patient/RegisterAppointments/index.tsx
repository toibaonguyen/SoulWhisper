import { CreateHabit } from "@/apis/Habits";
import { RegisterAppointment } from "@/apis/Registration";
import { UserState } from "@/redux/reducers";
import {
  Box,
  Button,
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  SelectChangeEvent,
  TextField,
} from "@mui/material";
import {  DateTimePicker, LocalizationProvider } from "@mui/x-date-pickers";
import React, { ChangeEvent, useState } from "react";
import { useSelector } from "react-redux";

import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';





const style = {
  position: "absolute" as "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 400,
  bgcolor: "white",
  border: "2px solid #000",
  boxShadow: 24,
  pt: 2,
  px: 4,
  pb: 3,
};

const AppointmentTypes = [
  "FIXED_TIME", // LỊCH HẸN THEO THỜI GIAN CỐ ĐỊNH
  "FLEXIBLE_SCHEDULING", // LỊCH HẸN LINH HOẠT
  "PRIORITY_SCHEDULING", // LỊCH HẸN ƯU TIÊN
  "FOLLOW_UP", // LỊCH HẸN TÁI KHÁM
  "EMERGENCY",
];

interface Props {
  doctorId: string;patientId:string
}

export default function AddHabitModal({ doctorId,patientId }: Props) {
  const [type, SetType] = useState<string>();
  const [startDate, SetStartDate] = useState<any>();

  const [endDate, SetEndDate] = useState<any>();
  const set_type = (event: SelectChangeEvent) => {
    SetType(event.target.value as string);
  };
  return (
    <LocalizationProvider dateAdapter={AdapterDayjs}>
      <Box sx={{ ...style, width: 400,borderRadius:10,display:"flex", flexDirection:"column" }} rowGap={5}>
        <h2 id="parent-modal-title" style={{ color: "black" }}>
          Register
        </h2>
        {/* <p id="parent-modal-description" style={{ color: "black" }}>
        Add you new habit
      </p> */}
        <FormControl fullWidth>
          <InputLabel id="demo-simple-select-label">Type</InputLabel>
          <Select
            labelId="demo-simple-select-label"
            id="demo-simple-select"
            value={type}
            label="Type"
            onChange={set_type}
          >
            {AppointmentTypes.map((t) => (
              <MenuItem value={t}>{t}</MenuItem>
            ))}
          </Select>
        </FormControl>
     
        <DateTimePicker
          label="Start time"
          value={startDate}
          onChange={(newValue) => SetStartDate(newValue as Date)}
        />
        <DateTimePicker
          label="End time"
          value={endDate}
          onChange={(newValue) => SetEndDate(newValue as Date)}
        />
        <Button
          style={{ marginTop: 10, left: 0 }}
          color="success"
          onClick={async () => {
            try {
              console.log("asdasdasd: ",patientId)
              await RegisterAppointment({
                appointment: {
                  type: type as string,
                  startTime: startDate as Date,
                  endTime: endDate as Date,
                  doctorId: doctorId,
                  patientId: patientId as string,
                },
                doctorId: doctorId,
                patientId: patientId as string,
                createdAt: new Date(),
              });
              alert("Success");
            } catch (e) {
              console.log(e)
              alert(e);
            }
          }}
        >
          Register
        </Button>
      </Box>
    </LocalizationProvider>
  );
}
