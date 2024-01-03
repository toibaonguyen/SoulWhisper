import React, { useEffect, useState } from "react";
import Box from "@mui/system/Box";
import ContentContainer from "@/components/ContentContainer";
import {
  Autocomplete,
  Button,
  Fab,
  Grid,
  Stack,
  TextField,
  Modal,
} from "@mui/material";
import { Habit } from "@/apis/Patient";
import HabitItem from "./HabitItem";
import AddIcon from "@mui/icons-material/Add";
import AddHabitModal from "./AddHabitModal";
import { DeleteHabit, GetAllHabits } from "@/apis/Habits";
import { useSelector } from "react-redux";
import { UserState } from "@/redux/reducers";
const habitTypes = ["PHYSICAL", "SOCIAL", "ENERGY", "MENTAL", "PRODUCTIVITY"];

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

export default function Habits() {
  
  const uid = useSelector((state: UserState) => state.id);
  const [type, SetType] = useState<string | null>(null);
  const [habits, SetHabits] = useState<Habit[]>([]);
  const [checkFlag, SetCheckFlag] = useState<boolean>(false);
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => {
    setOpen(true);
  };
  const handleClose = () => {
    setOpen(false);
  };
  const RemoveHabit = async (id: string) => {
    await DeleteHabit(id);
    SetHabits(await GetAllHabits(uid));
  };
  useEffect(() => {
    async function FetchData() {
      try {
        console.log("PatientId88: ", uid);
        SetHabits(await GetAllHabits(uid));
      } catch (e) {
        console.log(e);
        SetHabits([]);
      }
    }

    FetchData();
  }, []);
  return (
    <Box>
      <Fab
        color="primary"
        aria-label="add"
        style={{ position: "absolute", bottom: 10, right: 10 }}
        onClick={handleOpen}
      >
        <AddIcon />
      </Fab>
      <Stack spacing={2}>
        <ContentContainer>
          <h4>Order by:</h4>
          <div
            style={{
              display: "flex",
              flexDirection: "row",
              alignContent: "space-around",
              justifyContent: "space-between",
            }}
          >
            <Autocomplete
              value={type}
              onChange={(event: any, newValue: string | null) => {
                SetType(newValue);
              }}
              id="controllable-statuses"
              options={habitTypes}
              getOptionLabel={(a) => a.replace("_", " ")}
              sx={{ width: 300 }}
              renderInput={(params) => (
                <>
                  <TextField {...params} label="Type" />
                </>
              )}
            />
          </div>
        </ContentContainer>
        {habits.length > 0 && type == null && (
          <Stack gap={1}>
            {habits.map((a) => {
              return (
                <HabitItem
                  id={a.id}
                  type={a.type}
                  name={a.name}
                  patientId={a.patientId}
                  description={a.description}
                  onRemove={async() => {
                   await RemoveHabit(a.id as string);
                  }}
                />
              );
            })}
          </Stack>
        )}
        {habits.length > 0 && type != null && (
          <Stack gap={1}>
            {habits.map((a) => {
              if (a.type == type) {
                return (
                  <HabitItem
                    id={a.id}
                    type={a.type}
                    name={a.name}
                    patientId={a.patientId}
                    description={a.description}
                    onRemove={async() =>await RemoveHabit(a.id as string)}
                  />
                );
              }
            })}
          </Stack>
        )}
      </Stack>
      <Modal open={open} onClose={handleClose}>
        <AddHabitModal />
      </Modal>
    </Box>
  );
}
