import axios from "axios";

const API_URL = "http://localhost:5296/api/account/";

const login = (email: string, password: string) => {
  return axios
    .post(API_URL + "login", {
      email,
      password,
    })
    .then((response) => {
      if (response.data.token) {
        localStorage.setItem("user", JSON.stringify(response.data));
      }
      return response.data;
    });
};

const logout = () => {
  localStorage.removeItem("user");
};
const authService = {
  login,
  logout,
};

export default authService;