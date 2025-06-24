import { useNavigate } from "react-router-dom";
import { useRegisterCustomer } from "../hooks/useRegisterCustomer";
import { RegisterCustomerForm } from "../components/RegisterCustomerForm";
import type { RegisterCustomerFormData } from "../types/RegisterCustomerFormData";
import type { RegisterCustomerRequest } from "../types/RegisterCustomerRequest";

const RegisterCustomerPage = () => {
  const registerMutation = useRegisterCustomer();
  const navigate = useNavigate();

  const handleSubmit = async (formData: RegisterCustomerFormData) => {
    // Transform data to Backend request DTO
    const payload: RegisterCustomerRequest = {
      phoneNumber: `${formData.countryCode}${formData.phoneNumber}`, // full phone number
      firstName: formData.firstName,
      lastName: formData.lastName,
      email: formData.email,
      role: "Customer",
    };
    try {
      await registerMutation.mutateAsync(payload);
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
