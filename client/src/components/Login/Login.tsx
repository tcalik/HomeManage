import React, { useState } from "react";
import axios from "axios";
import {useDispatch, useSelector} from "react-redux"

import { login } from "../../store/authSlice";
import { ThunkDispatch } from "@reduxjs/toolkit";
import { getRoomsList } from "../../services/getList";
 
const Login: React.FC = () => {

  const [email, setEmail] = useState("")
  const [password, setPassword] = useState("")
  const dispatch:any = useDispatch()

  const handleSubmit = (event: React.FormEvent) => {
  
    event.preventDefault();
    dispatch(login({email, password}))
  };

  const requestRooms = async () => {
    const roomsList = await getRoomsList();
    console.log(roomsList)
  }
  return (
    <div>
      <div className="Login grid grid-cols1 gap-2 w-48">
        <label className="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-1">Email</label>
        <input onChange={e => setEmail(e.target.value)} className="appearance-none block w-full bg-gray-200 text-gray-700 border border-red rounded py-2 px-2 mb-1"></input>
        <label className="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-1">Password</label>
        <input onChange={e => setPassword(e.target.value)} className="appearance-none block w-full bg-gray-200 text-gray-700 border border-gray-200 rounded py-2 px-2 mb-2" type="password"></input>
        <button onClick={handleSubmit} className="appearance-none block w-full bg-gray-400 text-gray-700 border border-gray-200 rounded py-2 px-2 mb-1">Submit</button>
      <button onClick={requestRooms}>List Rooms</button>
      </div>
    </div>
  );
};

export default Login;
