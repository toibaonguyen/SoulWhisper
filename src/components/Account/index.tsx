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
import React, { useState } from "react";

export default function Account() {
  const [id, SetId] = useState("asfasfafs");
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
              justifyContent:"space-evenly",
              flex: 3,
              padding: 10,
            }}
          >
            <div style={{ display: "flex", flexDirection: "column" }}>
              <text>New password</text>
              <TextField
                style={{ marginTop: 5 }}
                size="small"
                placeholder="Password"
              />
            </div>
            <div style={{ display: "flex", flexDirection: "column",justifyContent:"center"}}>
              <Button variant="contained" color="success">
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
            <text>ID: {id}</text>
            <text>Name: {id}</text>
            <text>Birthday: {id}</text>
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
