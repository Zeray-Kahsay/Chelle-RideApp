import axios from "axios";
import type { LoginRequest } from "../types/LoginRequest";

export const login = async (data: LoginRequest) => {
  const response = await axios.post("/account/login", data);
  return response.data;
};
