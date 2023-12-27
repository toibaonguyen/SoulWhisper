import { SERVER_URL } from "@/common/api";
import axios from "../config/axios";
import { Doctor } from "./Doctor";
import { Appointment } from "./Appointment";

interface DoctorshipRegistration {
    id: string | null
    doctor: Doctor
    status: string | null
    createdAt: Date | null
    expiredAt: Date | null
}
interface UpdateDoctorshipRegistration {
    status: string
}

interface AppointmentRegistration {
    id: string | null
    appointment: Appointment
    doctorId:string
    patientId:string
    status: string | null
    createdAt: Date
}
interface UpdateAppointmentRegistration {
    status: string
}
export async function RegisterDoctorship(props: DoctorshipRegistration) {
    try {
        let res = await axios.post("Registrations/doctorships", props);
        return res.data;
    }
    catch (e) {
        throw e;
    }
}

export async function GetDoctorshipRegistrations() {
    try {
        let res = await axios.get("Registrations/doctorships");
        return res.data;
    }
    catch (e) {
        throw e;
    }
}

export async function UpdateDoctorshipRegistrations(id: string, update: UpdateDoctorshipRegistration) {
    try {
        let res = await axios.patch(`Registrations/doctorships/${id}`, update);
        return res.data;
    }
    catch (e) {
        throw e;
    }
}
export async function RegisterAppointment(props: AppointmentRegistration) {
    try {
        let res = await axios.post("Registrations/appointments", props);
        return res.data;
    }
    catch (e) {
        throw e;
    }
}

export async function GetAppointmentRegistrations() {
    try {
        let res = await axios.get("Registrations/appointments");
        return res.data;
    }
    catch (e) {
        throw e;
    }
}

export async function UpdateAppointmentRegistrations(id: string, update: UpdateAppointmentRegistration) {
    try {
        let res = await axios.patch(`Registrations/appointments/${id}`, update);
        return res.data;
    }
    catch (e) {
        throw e;
    }
}