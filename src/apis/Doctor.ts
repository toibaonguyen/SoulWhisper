import { SERVER_URL } from "@/common/api";
import axios from "../config/axios";

export interface Doctor {
    id:string|null,
    email: string,
    password: string,
    name: string,
    birthday: Date,
    gender: string,
    bloodType: string,
    activationStatus:string|null,
    specialty:string
}

interface Account{
    email:string,
    password:string
}



export async function GetDoctorById(id: string) {
    try {
        let res = await axios.get(`Doctors/${id}`);
        return res.data;
    }
    catch (e) {
        throw e;
    }
}

export async function LoginAsDoctor(account:Account)
{
    try {
        let res = await axios.get(`Doctors/login`);
        return res.data;
    }
    catch (e) {
        throw e;
    }
}