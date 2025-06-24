import { useState } from "react";
import { useNavigate, useSearchParams } from "react-router-dom";

const VerifyPhoneForm = () => {
  const [params] = useSearchParams();
  const navigate = useNavigate();
  const [code, setCode] = useState("");

  const phone = params.get("phone");
  const role = params.get("role");

  const handleVerify = async () => {
    try {
      if (code === "123456") {
        if (role === "driver") {
          navigate("/register/driver-step2");
        } else {
          navigate("/register/success");
        }
      } else {
        alert("Invalid verification code");
      }
    } catch (error) {
      console.error("Verification error:", error);
      navigate("/register/error");
    }
  };

  return (
    <div className="min-h-screen flex flex-col justify-center items-center bg-gray-50 p-4">
      <div className="bg-white p-6 rounded-2xl shadow-md w-full max-w-md text-center space-y-6">
        <h2 className="text-xl font-semibold text-gray-700">
          Verify Your Phone
        </h2>
        <p className="text-gray-500">Enter the 6-digit code sent to {phone}</p>

        <input
          type="text"
          value={code}
          onChange={(e) => setCode(e.target.value)}
          placeholder="Verification Code"
          className="w-full p-3 border rounded-xl text-center"
        />

        <button
          onClick={handleVerify}
          className="w-full bg-green-600 text-white py-3 rounded-xl hover:bg-green-700 transition"
        >
          Verify
        </button>
      </div>
    </div>
  );
};

export default VerifyPhoneForm;
