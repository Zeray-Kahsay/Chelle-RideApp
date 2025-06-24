import axios from "axios";
import type { RegisterCustomerRequest } from "../types/RegisterCustomerRequest";

export const registerCustomer = async (data: RegisterCustomerRequest) => {
  const response = await axios.post("/api/account/register", data);
  return response.data;
};
