import { useState, type ChangeEvent, type FormEvent } from "react";
import { useNavigate } from "react-router-dom";

const RegisterCustomer = () => {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    phoneNumber: "",
    firstName: "",
    lastName: "",
    email: "",
    password: "",
    confirmPassword: "",
  });

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault();

    // api call
    try {
      navigate(`/verify-phone?phone=${formData.phoneNumber}&role=customer`);
    } catch (error) {
      navigate("/register/error");
      console.error("Registration error:", error);
    }
  };

  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-50 p-4">
      <form
        onSubmit={handleSubmit}
        className="bg-white p-6 rounded-2xl shadow-md w-full max-w-md space-y-4"
      >
        <h2 className="text-xl font-semibold text-gray-700 text-center">
          Register as Customer
        </h2>

        <input
          type="text"
          name="firstName"
          placeholder="First Name"
          required
          onChange={handleChange}
          className="w-full p-3 border rounded-xl"
        />

        <input
          type="text"
          name="lastName"
          placeholder="Last Name"
          required
          onChange={handleChange}
          className="w-full p-3 border rounded-xl"
        />

        <input
          type="tel"
          name="phoneNumber"
          placeholder="Phone Number"
          required
          onChange={handleChange}
          className="w-full p-3 border rounded-xl"
        />

        <input
          type="email"
          name="email"
          placeholder="Email (optional)"
          onChange={handleChange}
          className="w-full p-3 border rounded-xl"
        />
        <input
          type="password"
          name="password"
          placeholder="Password"
          onChange={handleChange}
          className="w-full p-3 border rounded-xl"
        />
        <input
          type="password"
          name="confirmPassword"
          placeholder="Confirm Password"
          onChange={handleChange}
          className="w-full p-3 border rounded-xl"
        />

        <button
          type="submit"
          className="w-full bg-blue-600 text-white py-3 rounded-xl hover:bg-blue-700 transition"
        >
          Continue
        </button>
      </form>
    </div>
  );
};

export default RegisterCustomer;
