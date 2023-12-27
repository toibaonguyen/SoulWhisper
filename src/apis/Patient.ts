import { SERVER_URL } from "@/common/api";
import axios from "../config/axios";

type Patient = {
    id?: string,
    email: string,
    password: string,
    name: string,
    birthday: Date,
    gender: string,
    bloodType: string,
    activationStatus?: string
}

type Account = {
    email: string,
    password: string
}

export async function CreatePatient(props: Patient) {
    try {
        let res = await axios.post("Patients", {
            email: props.email, password: props.password,
            name: props.name,birthday:props.birthday.toISOString().split('T')[0],
            gender:props.gender,bloodType:props.bloodType
        });
        return res.data;
    }
    catch (e) {
        console.log(e)
        throw e;
    }
}

export async function GetPatientById(id: string) {
    try {
        let res = await axios.get(`Patients/${id}`);
        return res.data;
    }
    catch (e) {
        throw e;
    }
}

export async function LoginAsPatient(account: Account) {
    try {
        let res = await axios.post(`Patients/login`, account);
        return res.data;
    }
    catch (e) {
        throw e;
    }
}

