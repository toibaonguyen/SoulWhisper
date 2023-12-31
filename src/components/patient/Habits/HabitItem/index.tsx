import { Habit } from "@/apis/Patient";
import { Doctor } from "@/components/Home/DoctorProfile";
import React from "react";
import Accordion from '@mui/material/Accordion';
import AccordionSummary from '@mui/material/AccordionSummary';
import AccordionDetails from '@mui/material/AccordionDetails';
import {RemoveCircle} from "@mui/icons-material";
import Typography from '@mui/material/Typography';


interface IHabitItem extends Habit   {

  onRemove:()=>void
}

export default function HabitItem(props: IHabitItem) {
  return (
    <Accordion >
    <AccordionSummary
      aria-controls="panel1a-content"
      id="panel1a-header"
      onContextMenu={props.onRemove}
    >
      <Typography>{props.name}</Typography>
    </AccordionSummary>
    <AccordionDetails>
      <Typography>
        {props.description}
      </Typography>
    </AccordionDetails>
  </Accordion>
  );
}
