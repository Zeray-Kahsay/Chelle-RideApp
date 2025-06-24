import { useMutation } from "@tanstack/react-query";
import { registerUser } from "../api/userApi";
import type { RegisterUserRequest } from "../features/Account/types/RegisterUserRequest";

export const useRegisterUser = () => {
  return useMutation({
    mutationFn: (data: RegisterUserRequest) => registerUser(data),
  });
};
