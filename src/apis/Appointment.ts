import axios from "../config/axios";

export interface Appointment {
    id?: string
    type: string
    startTime: Date
    endTime: Date
    diagnosis?: string
    prescription?: string
    notes?: string
    doctorId: string
    patientId: string
    status?: string
}
interface UpdateAppointment {
    diagnosis: string | null
    prescription: string | null
    notes: string | null
    status: string | null
}

export async function GetAppointments(limit: number | null, doctorId: string | null, patientId: string | null) {
    try {
        console.log(localStorage.getItem("accessToken"))
        let url1:string=""
        if(limit!=null)
        {
            url1+=`limit=${limit}`;
        }
        if(doctorId!=null)
        {
            if(limit!=null)
            {
                url1+="&&"
            }
            url1+=`doctorId=${doctorId}`
        }
        if(patientId!=null)
        {
            if(limit!=null||doctorId!=null)
            {
                url1+="&&"
            }
            url1+=`patienId=${patientId}`
        }
        axios.head
        let res = await axios.get("/Appointments?"+url1);
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