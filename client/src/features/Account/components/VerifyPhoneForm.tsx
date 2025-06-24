import { useForm } from "react-hook-form";
import type { OTPFormInputs } from "../types/OTPFormInputs";

type Props = {
  onSubmit: (data: OTPFormInputs) => void;
};
const VerifyPhoneForm = ({ onSubmit }: Props) => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<OTPFormInputs>();

  return (
    <form
      onSubmit={handleSubmit(onSubmit)}
      className="max-w-md mx-auto space-y-4"
    >
      <input
        type="text"
        {...register("phoneNumber", { required: "Phone number is required" })}
        placeholder="Phone Number"
        className="input input-bordered w-full"
      />
      {errors.phoneNumber && <p className="text-red-500"> {errors.phoneNumber.message} </p>}
      <input
        type="text"
        {...register("code", {required: "Verification code is reqired"})}
        className="input input-bordered w-full"
      />
      {errors && <p className="text-red-500" > {errors.code?.message} </p>}

      <button type="submit" className="btn btn-success w-full">
        Verify
      </button>
    </form>
  );
};

export default VerifyPhoneForm;
