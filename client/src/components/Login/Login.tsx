import React, { useState } from "react";
import axios from "axios";
import {useDispatch, useSelector} from "react-redux"
import {userActions} from "../../store/userSlice"
 
const Login: React.FC = () => {

  const [login, setLogin] = useState("")
  const [password, setPassword] = useState("")
  const count = useSelector((state: any) => state.counter)
  const dispatch = useDispatch()

  const handleSubmit = (event: React.FormEvent) => {
  
    event.preventDefault();
    /*axios
      .post("http://localhost:5296/api/account/login", {
        email: login,
        password: password,
      })
      .then((res) => {
        console.log(res);
      })
      .catch((err) => {
        console.log(err);
      });*/
     dispatch(userActions.increment())
     console.log(count)
  };
  return (
    <div>
      <div className="Login grid grid-cols1 gap-2 w-48">
        <label className="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-1">Login</label>
        <input onChange={e => setLogin(e.target.value)} className="appearance-none block w-full bg-gray-200 text-gray-700 border border-red rounded py-2 px-2 mb-1"></input>
        <label className="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-1">Password</label>
        <input onChange={e => setPassword(e.target.value)} className="appearance-none block w-full bg-gray-200 text-gray-700 border border-gray-200 rounded py-2 px-2 mb-2" type="password"></input>
        <button onClick={handleSubmit} className="appearance-none block w-full bg-gray-400 text-gray-700 border border-gray-200 rounded py-2 px-2 mb-1">Submit</button>
      </div>
    </div>
  );
};

export default Login;
