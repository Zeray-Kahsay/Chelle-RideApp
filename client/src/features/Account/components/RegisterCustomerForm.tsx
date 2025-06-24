import { useForm } from "react-hook-form";
import { useEffect, useState } from "react";
import { detectCountryPhoneCode } from "../utils/detectCountryPhoneCode";
import { getDialCodeFromCountry } from "../utils/CountryCodeUtils";
import type { RegisterCustomerFormData } from "../types/RegisterCustomerFormData";

interface Props {
  onSubmit: (data: RegisterCustomerFormData) => void;
}

export const RegisterCustomerForm = ({ onSubmit }: Props) => {
  const [defaultDialCode, setDefaultDialCode] = useState("+251");
  const {
    register,
    handleSubmit,
    setValue,
    formState: { errors },
  } = useForm<RegisterCustomerFormData>();

  // Detect country phone code on mount
  useEffect(() => {
    const detect = async () => {
      const code = await detectCountryPhoneCode();
      if (code) {
        const dial = getDialCodeFromCountry(code);
        setDefaultDialCode(dial);
        setValue("countryCode", dial); // Set hidden input
      }
    };
    detect();
  }, [setValue]);

  return (
    <form
      onSubmit={handleSubmit(onSubmit)}
      className="max-w-md mx-auto bg-white p-6 rounded-lg shadow-md space-y-4"
    >
      <h2 className="text-xl font-bold mb-4 tracking-wider text-blue-300">
        Customer Registration
      </h2>
      <input
        {...register("countryCode")}
        value={defaultDialCode}
        className="w-full px-4 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
      />

      <input
        {...register("phoneNumber", { required: "Phone number is required" })}
        placeholder="Phone Number"
        className="w-full px-4 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
      />
      {errors.phoneNumber && (
        <p className="text-red-500 text-sm">{errors.phoneNumber.message}</p>
      )}

      <input
        {...register("firstName", { required: "First name is required" })}
        placeholder="First Name"
        className="w-full px-4 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
      />
      {errors.firstName && (
        <p className="text-red-500 text-sm">{errors.firstName.message}</p>
      )}

      <input
        {...register("lastName", { required: "Last name is required" })}
        placeholder="Last Name"
        className="w-full px-4 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
      />
      {errors.lastName && (
        <p className="text-red-500 text-sm">{errors.lastName.message}</p>
      )}

      <input
        {...register("email")}
        placeholder="Email (optional)"
        type="email"
        className="w-full px-4 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
      />

      <input type="hidden" {...register("role")} value="Customer" />

      <button
        type="submit"
        className="w-full py-2 bg-blue-600 text-white rounded-md hover:bg-blue-700 transition-colors duration-200"
      >
        Register
      </button>
    </form>
  );
};
