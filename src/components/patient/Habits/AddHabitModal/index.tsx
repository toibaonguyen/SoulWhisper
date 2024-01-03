import { CreateHabit } from "@/apis/Habits";
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
import React, { ChangeEvent, useState } from "react";
import { useSelector } from "react-redux";
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

const habitTypes = ["PHYSICAL", "SOCIAL", "ENERGY", "MENTAL", "PRODUCTIVITY"];

export default function AddHabitModal() {
  const uid = useSelector((state: UserState) => state.id);
  const [name, SetName] = useState<string>();
  const [type, SetType] = useState<string>();
  const [description, SetDescription] = useState<string>();
  const set_type = (event: SelectChangeEvent) => {
    SetType(event.target.value as string);
  };
  return (
    <Box sx={{ ...style, width: 400 }}>
      <h2 id="parent-modal-title" style={{ color: "black" }}>
        New habit
      </h2>
      <p id="parent-modal-description" style={{ color: "black" }}>
        Add you new habit
      </p>
      <FormControl fullWidth>
        <InputLabel id="demo-simple-select-label">Type</InputLabel>
        <Select
          labelId="demo-simple-select-label"
          id="demo-simple-select"
          value={type}
          label="Type"
          onChange={set_type}
        >
          {habitTypes.map((t) => (
            <MenuItem value={t}>{t}</MenuItem>
          ))}
        </Select>
      </FormControl>
      <TextField
        placeholder="Name"
        fullWidth
        style={{ marginTop: 10 }}
        onChange={(e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
          SetName(e.target.value.toString());
        }}
      />
      <TextField
        multiline
        placeholder="Description"
        fullWidth
        style={{ marginTop: 10 }}
        onChange={(e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
          SetDescription(e.target.value.toString());
        }}
      />
      <Button
        style={{ marginTop: 10, left: 0 }}
        color="success"
        onClick={async () => {
          try{
            await CreateHabit({
              type: type as string,
              name: name as string,
              description: description as string,
              patientId: uid as string,
            });
            alert("Success")
          }
          catch(e)
          {
            alert(e)
          }
        }}
      >
        Add
      </Button>
    </Box>
  );
}
