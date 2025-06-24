import { useNavigate } from "react-router-dom";
import { verifyPhone } from "../api/verifyPhone";
import { useMutation } from "@tanstack/react-query";
import VerifyPhoneForm from "../components/VerifyPhoneForm";

const VerifyPhonePage = () => {
  const navigate = useNavigate();

  const { mutate, isPending, isError, error } = useMutation({
    mutationFn: verifyPhone,
    onSuccess: () => {
      navigate("/login");
    },
  });
  return (
    <div className="p-4">
      <h2 className="text-xl font-bold mb-4 text-center">Verify Your Phone</h2>
      <VerifyPhoneForm onSubmit={mutate} />
      {isPending && <p className="text-blue-500 mt-2">Verifying...</p>}
      {isError && <p className="text-red-500 mt-2">{error.message} </p>}
    </div>
  );
};

export default VerifyPhonePage;
