import {
  Box,
  Divider,
  FormControlLabel,
  RadioGroup,
  Stack,
  TextField,
  Radio,
  Button,
} from "@mui/material";
import { DateTimePicker } from "@mui/x-date-pickers";
import React, { ChangeEvent, useEffect, useReducer, useState } from "react";
import { useSelector } from "react-redux";
import { UserState } from "@/redux/reducers";
import { ChangePatientPassword, GetPatientById } from "@/apis/Patient";

const reducer = (
  state: { id: string; name: string; birthday: Date; bloodType: string },
  action: {
    type: string;
    payload: { id: string; name: string; birthday: Date; bloodType: string };
  }
) => {
  switch (action.type) {
    case "SET_USER":
      return action.payload;
    default:
      return state;
  }
};
export default function Account() {
  const id = useSelector((state: UserState) => state.id);
  const [state, dispatch] = useReducer(reducer, {
    id: "",
    name: "",
    birthday: new Date(),
    bloodType: "",
  });
  const [newPassword, SetNewPassword] = useState("");
  const onChangePassword = (e: React.ChangeEvent<HTMLInputElement>) => {
    SetNewPassword(e.target.value);
  };
  useEffect(() => {
    const fetchPatient = async () => {
      const a = await GetPatientById(id as string);
      dispatch({
        type: "SET_USER",
        payload: {
          id: a.id,
          name: a.name,
          birthday: a.birthday,
          bloodType: a.bloodType,
        },
      });
    };
    fetchPatient();
  }, []);
  const UpdatePassword = async () => {
    try {
      console.log("patientid:", id);
      console.log(newPassword);
      const mes = await ChangePatientPassword(id as string, {
        password: newPassword,
      });
      alert("Success");
    } catch (e) {
      alert(`Error: ${e}`);
    }
  };
  return (
    <Box>
      <Stack spacing={2}>
        <div
          style={{
            backgroundColor: "#2ECFC0",
            padding: 15,
            borderRadius: 15,
            display: "flex",
            justifyContent: "center",
          }}
        >
          <h2 style={{ color: "white" }}>Account</h2>
        </div>
        <div
          style={{
            backgroundColor: "white",
            padding: 15,
            borderRadius: 15,
            display: "flex",
            justifyContent: "center",
            flexDirection: "row",
          }}
        >
          <Stack
            sx={{
              justifyContent: "space-evenly",
              flex: 3,
              padding: 10,
            }}
          >
            <div style={{ display: "flex", flexDirection: "column" }}>
              <h4>New password</h4>
              <TextField
                style={{ marginTop: 5 }}
                size="small"
                placeholder="Password"
                onChange={onChangePassword}
              />
            </div>
            <div
              style={{
                display: "flex",
                flexDirection: "column",
                justifyContent: "center",
              }}
            >
              <Button
                variant="contained"
                color="success"
                onClick={UpdatePassword}
              >
                Save
              </Button>
            </div>
          </Stack>
          <Divider orientation="vertical" flexItem />
          <Stack
            sx={{
              justifyContent: "center",
              flex: 2,
              paddingLeft: 5,
              marginTop: 5,
            }}
            spacing={2}
          >
            <h3>Infomation</h3>
            <h3>ID: {id}</h3>
            <h3>Name: {state.name}</h3>
            <h3>Birthday: {state.birthday.toString()}</h3>
            <h3>BloodType: {state.bloodType}</h3>
            <Divider />
            <h3>Gender</h3>
            <RadioGroup
              aria-labelledby="demo-radio-buttons-group-label"
              name="radio-buttons-group"
              value={"male"}
            >
              <FormControlLabel
                value="female"
                control={<Radio />}
                label="Female"
              />
              <FormControlLabel value="male" control={<Radio />} label="Male" />
              <FormControlLabel
                value="other"
                control={<Radio />}
                label="Other"
              />
            </RadioGroup>
          </Stack>
        </div>
      </Stack>
    </Box>
  );
}
