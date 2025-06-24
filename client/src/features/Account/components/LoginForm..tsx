import { useForm } from "react-hook-form";
import type { LoginRequest } from "../types/LoginRequest";

type LoginFormProps = {
  onSubmit: (data: LoginRequest) => void;
};

const LoginForm = ({ onSubmit }: LoginFormProps) => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<LoginRequest>();

  return (
    <div className="max-w-md mx-auto mt-10 p-6 border rounded-lg shadow-lg bg-white">
      <h2 className="text-2xl font-semibold mb-6 text-center tracking-wider">
        Login
      </h2>
      <form onSubmit={handleSubmit(onSubmit)} className="space-y-4">
        <div>
          <label className="block text-sm font-medium mb-1 tracking-wider">
            Phone Number
          </label>
          <input
            type="tel"
            {...register("phoneNumber", {
              required: "Phone number is required",
            })}
            className="w-full border rounded px-3 py-2"
          />
          {errors.phoneNumber && (
            <p className="text-red-500 text-sm">{errors.phoneNumber.message}</p>
          )}
        </div>

        <div>
          <label className="block text-sm font-medium mb-1 tracking-wider">
            Password
          </label>
          <input
            type="password"
            {...register("password", { required: "Password is required" })}
            className="w-full border rounded px-3 py-2"
          />
          {errors.password && (
            <p className="text-red-500 text-sm">{errors.password.message}</p>
          )}
        </div>

        <button
          type="submit"
          className="w-full bg-blue-600 text-white py-2 rounded hover:bg-blue-700 tracking-widest"
        >
          Login
        </button>
      </form>
    </div>
  );
};

export default LoginForm;
