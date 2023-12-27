import axios from "../config/axios";

export interface Appointment {
    id: string | null
    type: string
    startTime: Date
    endTime: Date
    diagnosis: string | null
    prescription: string | null
    notes: string | null
    doctorId: string
    patientId: string
    status: string | null
}
interface UpdateAppointment {
    diagnosis: string | null
    prescription: string | null
    notes: string | null
    status: string | null
}

export async function GetAppointments(limit: number | null, doctorId: string | null, patientId: string | null) {
    try {
        let res = await axios.get(`Appointments?limit=${limit}&&doctorId=${doctorId}&&patienId=${patientId}`);
        return res.data;
    }
    catch (e) {
        throw e;
    }
}

export async function UpdateAppointment(update: UpdateAppointment) {
    try {
        let res = await axios.patch(`Appointments`, { params: { update: update } });
        return res.data;
    }
    catch (e) {
        throw e;
    }
}