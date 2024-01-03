import axios from "../config/axios";

export interface UpdateAchievement
{
   images?:string[]
type?:string
  title?:string
description?:string
dateEarned?:Date
  activationStatus?:string
}
export interface Achievement{
   id? :string
 images:string[]
 type :string
 title:string
description:string 
dateEarned:Date
 activationStatus? :string
}
export async function GetAchievements(doctorId: string|null) {
    try {
        if(doctorId!=null){
            
        let res = await axios.get(`Achievements?doctorId=${doctorId}`);
        return res.data;
        }
        let res = await axios.get(`Achievements`);
        return res.data;
    }
    catch (e) {
        throw e;
    }
}

export async function UpdateAchievements(achievementId:string,update:UpdateAchievement) {
    try {
        let res = await axios.patch(`Achievements/${achievementId}`,update);
        return res.data;
    }
    catch (e) {
        throw e;
    }
}