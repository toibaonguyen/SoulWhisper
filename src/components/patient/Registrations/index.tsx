import React, { useEffect, useState } from "react";
import Box from "@mui/system/Box";
import ContentContainer from "@/components/ContentContainer";
import { Autocomplete, Grid, Stack, TextField } from "@mui/material";
import {
  AppointmentRegistration,
  GetAppointmentRegistrations,
} from "@/apis/Registration";

export default function Registrations() {
  const [registrations, SetRegistrations] = useState<AppointmentRegistration[]>(
    []
  );
  useEffect(() => {
    async function as() {
      try {
        SetRegistrations(await GetAppointmentRegistrations());
      } catch (e) {
        console.log("loi", e);

        SetRegistrations([]);
      }
    }
    as()
  }, []);
  return (
    <Box>
      <Stack spacing={2}>
        {registrations.map((r) => (
          <ContentContainer>
            <div
              style={{
                display: "flex",
                flexDirection: "row",
                justifyContent: "space-evenly",
              }}
            >
              <div>
                <h2>Start at: {r.appointment.startTime.toDateString()}</h2>
                <h2>End at: {r.appointment.startTime.toDateString()}</h2>
              </div>
              <div>
                <text>{r.status}</text>
              </div>
            </div>
          </ContentContainer>
        ))}
        {registrations.length == 0}
      </Stack>
    </Box>
  );
}
