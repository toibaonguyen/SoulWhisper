import { Habit } from "@/apis/Patient";
import React from "react";
import Accordion from '@mui/material/Accordion';
import AccordionSummary from '@mui/material/AccordionSummary';
import AccordionDetails from '@mui/material/AccordionDetails';
import {RemoveCircle} from "@mui/icons-material";
import Typography from '@mui/material/Typography';
import { Achievement } from "@/apis/Achievement";


interface IHabitItem extends Achievement   {

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
      <Typography>{props.title}</Typography>
    </AccordionSummary>
    <AccordionDetails>
      <Typography>
        {props.description}
      </Typography>
      <Typography>{props.activationStatus}</Typography>
    </AccordionDetails>
  </Accordion>
  );
}
