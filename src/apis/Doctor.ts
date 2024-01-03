import { SERVER_URL } from "@/common/api";
import axios from "../config/axios";

export interface Doctor {
    id:string|null,
    email: string,
    password: string,
    name: string,
    birthday: Date,
    gender: string,
    activationStatus:string|null,
    specialty:string,
    avatar:string|null
}

interface Account{
    email:string,
    password:string
}


export interface UpdateDoctor {

    password: string,

}
export async function GetDoctors(limit: number|null) {
    try {
        let url="Doctors";
        if(limit!=null)
        {
            url+=`?limit=${limit}`
        }
        let res = await axios.get(url);
        return res.data;
    }
    catch (e) {
        throw e;
    }
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
        let res = await axios.post(`Doctors/login`,account);
        return res.data;
    }
    catch (e) {
        throw e;
    }
}
export async function ChangeDoctorPassword(id: string, props: UpdateDoctor) {
    try {
        let res = await axios.patch(`Patients/${id}`, props);
        return res;
    }
    catch (e) {
        throw e;
    }
}

