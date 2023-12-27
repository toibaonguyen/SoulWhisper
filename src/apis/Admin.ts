import { SERVER_URL } from "@/common/api";
import axios from "../config/axios";

interface Admin {
    id:string|null,
    email: string,
    password: string,
    name: string,
    birthday: Date,
    gender: string,
    bloodType: string,
    activationStatus:string|null
}

interface Account{
    email:string,
    password:string
}

export async function RegisterAdmin(props: Admin) {
    try {
        let res = await axios.post("Admins", props);
        return res.data;
    }
    catch (e) {
        throw e;
    }
}

export async function GetAdminById(id: string) {
    try {
        let res = await axios.get(`Admins/${id}`);
        return res.data;
    }
    catch (e) {
        throw e;
    }
}

export async function LoginAsAdmin(account:Account)
{
    try {
        let res = await axios.get(`Admins/login`);
        return res.data;
    }
    catch (e) {
        throw e;
    }
}