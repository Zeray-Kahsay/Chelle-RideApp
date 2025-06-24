import axios from "axios";
import type { RegisterUserRequest } from "../features/Account/types/RegisterUserRequest";

const API = axios.create({
  baseURL: "https://localhost:/5001/api",
});

export const registerUser = (data: RegisterUserRequest) => {
  return API.post("/account/register", data);
};
