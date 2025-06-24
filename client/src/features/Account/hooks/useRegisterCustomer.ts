import { useMutation } from "@tanstack/react-query";
import type { RegisterCustomerRequest } from "../types/RegisterCustomerRequest";
import { registerCustomer } from "../api/registerCustomer";

export const useRegisterCustomer = () => {
  return useMutation({
    mutationFn: (data: RegisterCustomerRequest) => registerCustomer(data),
  });
};
