import * as React from "react";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import FormControlLabel from "@mui/material/FormControlLabel";
import Checkbox from "@mui/material/Checkbox";
import Link from "@mui/material/Link";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { RadioGroup, Radio, FormControl, FormLabel } from "@mui/material";
import { DateTimePicker } from "@mui/x-date-pickers/DateTimePicker";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { CreatePatient } from "@/apis/Patient";

// TODO remove, this demo shouldn't need to reset the theme.
const defaultTheme = createTheme();

export default function SignUp() {
  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    console.log({
      email: data.get("email"),
      password: data.get("password"),
      birthday: data.get("birthday"),
      name:data.get("name"),
      gender:data.get("gender")
    });

    try{
      await CreatePatient({
        email: data.get("email")?.toString() || "",
        password: data.get("password")?.toString() || "",
        birthday: new Date(Date.parse(data.get("birthday")?.toString().replace("/","-") || "2000-10-10")),
        name: data.get("name")?.toString() || "",
        gender: data.get("gender")?.toString() || "MALE",
        bloodType: "",
       
      })

      console.log("OKOK")
    }
    catch(e)
    {
      console.log("????")
      console.error(e);
    }
  };

  return (
    <LocalizationProvider dateAdapter={AdapterDayjs}>
      <ThemeProvider theme={defaultTheme}>
        <Container component="main" maxWidth="xs">
          <CssBaseline />
          <Box
            sx={{
              marginTop: 8,
              display: "flex",
              flexDirection: "column",
              alignItems: "center",
            }}
          >
            <Typography component="h1" variant="h5">
              Sign up
            </Typography>
            <Box
              component="form"
              noValidate
              onSubmit={handleSubmit}
              sx={{ mt: 3 }}
            >
              <Grid container spacing={2}>
                <Grid item xs={12} sm={6}>
                  <TextField
                    autoComplete="given-name"
                    name="name"
                    required
                    fullWidth
                    id="name"
                    label="Name"
                    autoFocus
                  />
                </Grid>
                <Grid item xs={12} sm={6}>
                  <DateTimePicker format="YYYY-MM-DD" views={["year","month","day"]} name="birthday"/>
                </Grid>
                <Grid item xs={12}>
                  <TextField
                    required
                    fullWidth
                    id="email"
                    label="Email Address"
                    name="email"
                    autoComplete="email"
                  />
                </Grid>
                <Grid item xs={12}>
                  <TextField
                    required
                    fullWidth
                    name="password"
                    label="Password"
                    type="password"
                    id="password"
                    autoComplete="new-password"
                  />
                </Grid>
                <Grid item xs={12}>
                  <FormControl component="fieldset">
                    <FormLabel component="legend">
                      Choose your gender:
                    </FormLabel>
                    <RadioGroup
                      aria-label="gender"
                      name="gender"
                      // value={gender}
                      // onChange={handleGenderChange}
                      row // Hiển thị lựa chọn theo hàng ngang
                    >
                      <FormControlLabel
                        value="MALE"
                        control={<Radio />}
                        label="Male"
                      />
                      <FormControlLabel
                        value="FEMALE"
                        control={<Radio />}
                        label="Female"
                      />
                      <FormControlLabel
                        value="OTHER"
                        control={<Radio />}
                        label="Other"
                      />
                      <FormControlLabel
                        value="UNKNOWN"
                        control={<Radio />}
                        label="Unknown"
                      />
                    </RadioGroup>
                  </FormControl>
                </Grid>
                <Grid item xs={12}>
                  <FormControlLabel
                    control={
                      <Checkbox value="allowExtraEmails" color="primary" />
                    }
                    label="I want to receive inspiration, marketing promotions and updates via email."
                  />
                </Grid>
              </Grid>
              <Button
                type="submit"
                fullWidth
                variant="contained"
                sx={{ mt: 3, mb: 2 }}
              >
                Sign Up
              </Button>
              <Grid container justifyContent="flex-end">
                <Grid item>
                  <Link href="/p/sign-in" variant="body2">
                    Already have an account? Sign in
                  </Link>
                </Grid>
              </Grid>
            </Box>
          </Box>
        </Container>
      </ThemeProvider>
    </LocalizationProvider>
  );
}
