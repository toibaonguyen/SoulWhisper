import React, { useEffect, useState } from "react";
import {
  MDBCol,
  MDBContainer,
  MDBRow,
  MDBCard,
  MDBCardText,
  MDBCardBody,
  MDBCardImage,
  MDBTypography,
  MDBIcon,
} from "mdb-react-ui-kit";
import { useRouter } from "next/router";
import styles from "./index.module.css";
import { Button, Modal } from "@mui/material";
import { Doctor, GetDoctorById } from "@/apis/Doctor";
import "mdb-react-ui-kit/dist/css/mdb.min.css";
import "@fortawesome/fontawesome-free/css/all.min.css";
import RegisterAppointments from "@/components/patient/RegisterAppointments";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { LocalizationProvider } from "@mui/x-date-pickers";
import { useSelector } from "react-redux";
import { UserState } from "@/redux/reducers";

export default function PersonalProfile() {
  const currentUser=useSelector((state:UserState)=>state)
  const router = useRouter();
  const doctorId = router.query.id as string;
  const [doctor, SetDoctor] = useState<any>();
  const [open, setOpen] = React.useState(false);

  useEffect(() => {
    console.log("DAY NE CHA LOZ:", doctorId);    console.log("Mas mayf con cho nay:", currentUser.id);
    if (!doctorId) {
      return;
    }
    async function GetDoctor() {
      try {
        const d = await GetDoctorById(doctorId);
        console.log(d);
        SetDoctor(d);
      } catch (e) {
        console.log(e);
      }
    }
    GetDoctor();
  }, [doctorId]);
  if (!doctor) {
    return null;
  }
  return (
      <section className="vh-100" style={{ backgroundColor: "#f4f5f7" }}>
        <MDBContainer className="py-5 h-100">
          <MDBRow className="justify-content-center align-items-center h-100">
            <MDBCol lg="6" className="mb-4 mb-lg-0">
              <MDBCard className="mb-3" style={{ borderRadius: ".5rem" }}>
                <MDBRow className="g-0">
                  <MDBCol
                    md="4"
                    sm={styles["gradient-custom"]}
                    className="text-center text-black "
                    style={{
                      borderTopLeftRadius: ".5rem",
                      borderBottomLeftRadius: ".5rem",
                    }}
                  >
                    <MDBCardImage
                      src={doctor?.avatar as string}
                      alt="Avatar"
                      className="my-5"
                      style={{ width: "80px" }}
                      fluid
                    />
                    <MDBTypography tag="h5">{doctor?.name}</MDBTypography>
                    <MDBCardText>{doctor?.specialty.replaceAll("_"," ")}</MDBCardText>
                    <MDBTypography tag="h6">
                      Activation:{" "}
                      <h6
                        style={{
                          color: (function () {
                            if (doctor.activationStatus == "PENDING") {
                              return "yellow";
                            } else if (doctor.activationStatus == "ACTIVE") {
                              return "green";
                            } else {
                              return "red";
                            }
                          })(),
                        }}
                      >
                        {doctor?.activationStatus}
                      </h6>
                    </MDBTypography>
                  </MDBCol>
                  <MDBCol md="8">
                    <MDBCardBody className="p-4">
                      <MDBTypography tag="h6">Information</MDBTypography>
                      <hr className="mt-0 mb-4" />
                      <MDBRow className="pt-1">
                        <MDBCol size="6" className="mb-3">
                          <MDBTypography tag="h6">Id</MDBTypography>
                          <MDBCardText className="text-muted">
                            {doctor?.id}
                          </MDBCardText>
                        </MDBCol>
                        <MDBCol size="6" className="mb-3">
                          <MDBTypography tag="h6">Email</MDBTypography>
                          <MDBCardText className="text-muted">
                            {doctor?.email}
                          </MDBCardText>
                        </MDBCol>
                      </MDBRow>
                      <hr className="mt-0 mb-4" />
                      <MDBRow className="pt-1">
                        <MDBCol size="6" className="mb-3">
                          <MDBTypography tag="h6">Birthday</MDBTypography>
                          <MDBCardText className="text-muted">
                            {doctor?.birthday.toString()}
                          </MDBCardText>
                        </MDBCol>
                        <MDBCol size="6" className="mb-3">
                          <MDBTypography tag="h6">Gender</MDBTypography>
                          <MDBCardText className="text-muted">
                            {doctor?.gender}
                          </MDBCardText>
                        </MDBCol>
                      </MDBRow>

                      <div className="d-flex justify-content-start">
                        {doctor.activationStatus == "ACTIVE" && (
                          <Button onClick={() => setOpen(true)}>
                            Register for appointments
                          </Button>
                        )}
                      </div>
                    </MDBCardBody>
                  </MDBCol>
                </MDBRow>
              </MDBCard>
            </MDBCol>
          </MDBRow>
        </MDBContainer>
        <Modal
          open={open}
          onClose={() => setOpen(false)}
          aria-labelledby="modal-modal-title"
          aria-describedby="modal-modal-description"
        >
          {<RegisterAppointments doctorId={doctorId} patientId={currentUser.id as string}/>}
        </Modal>
      </section>
  );
}
