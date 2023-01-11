import axios from "axios";
import authHeader from "./auth-header";

const API_URL = "http://localhost:5296/api/"

export const  getRoomsList = () => {
 return axios.get(API_URL + "rooms", { headers: authHeader() });

};

