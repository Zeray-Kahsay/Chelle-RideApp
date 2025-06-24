import { useNavigate } from "react-router-dom";
import { login } from "../api/login";
import { useMutation } from "@tanstack/react-query";
import LoginForm from "../components/LoginForm.";

const LoginPage = () => {
  const navigate = useNavigate();

  const { mutate, isPending, isError, error } = useMutation({
    mutationFn: login,
    onSuccess: (data) => {
      localStorage.setItem("token", data.token);
      navigate("/dashboard");
    },
  });
  return (
    <div className="p-4">
      <LoginForm onSubmit={mutate} />
      {isPending && <p className="text-blue-500 mt-2">Logging in ... </p>}
      {isError && <p className="text-red-500 mt-2"> {error.message} </p>}
    </div>
  );
};

export default LoginPage;
