import axios from "../config/axios";


interface Habit {
    id?: string,
    type: string,
    name: string,
    description: string,
    patientId: string,
}



    
export async function CreateHabits(props: Habit) {
    try {
        let res = await axios.post("Habits", props);
        return res.data;
    }
    catch (e) {
        console.log(e)
        throw e;
    }
}


export async function GetAllHabits(patientId:string|null) {
    try {

        let url="Habits"
        if(patientId!=null)
        {
            url+=`?patientId=${patientId}`
        }
        let res = await axios.get(url);
        return res.data;
    }
    catch (e) {
        console.log(e)
        throw e;
    }
}

export async function DeleteHabit(id:string)
{
    try {

        let url=`Habits/${id}`
        let res = await axios.delete(url);
        return res.data;
    }
    catch (e) {
        console.log(e)
        throw e;
    }
}