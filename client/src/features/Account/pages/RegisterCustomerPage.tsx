import { useNavigate } from "react-router-dom";
import { useRegisterCustomer } from "../hooks/useRegisterCustomer";
import type { RegisterCustomerRequest } from "../types/RegisterCustomerRequest";
import { RegisterCustomerForm } from "../components/RegisterCustomerForm";

const RegisterCustomerPage = () => {
  const registerMutation = useRegisterCustomer();
  const navigate = useNavigate();

  const handleSubmit = async (data: RegisterCustomerRequest) => {
    try {
      await registerMutation.mutateAsync(data);
      navigate("/verify-phone");
    } catch (error) {
      console.error("Registration failed", error);
    }
  };

  return (
    <div className="p-4">
      <RegisterCustomerForm onSubmit={handleSubmit} />
    </div>
  );
};

export default RegisterCustomerPage;
