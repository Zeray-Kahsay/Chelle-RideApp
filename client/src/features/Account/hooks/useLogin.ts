import { useMutation } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import type { LoginFormInput } from "../types/LoginUserRequest";
import axios, { AxiosError } from "axios";

type LoginResponse = { token: string };

export const useLogin = () => {
  const navigate = useNavigate();

  return useMutation<
    LoginResponse,
    AxiosError<{ message: string }>,
    LoginFormInput
  >({
    mutationFn: async (data: LoginFormInput) => {
      const response = await axios.post("/api/account/login", data);
      return response.data;
    },
    onSuccess: (data) => {
      localStorage.setItem("token", data.token);
      navigate("/dashboard");
    },
    onError: (err) => {
      if (err.response && err.response.status === 401) {
        alert("Invalid Phone number or Password. Please try again.");
        console.error("Login failed:", err.response.data.message);
      } else {
        console.error(
          "Login error:",
          err.response?.data?.message || err.message
        );
        alert("An error occurred while logging in. Please try again later.");
      }
    },
  });
};
