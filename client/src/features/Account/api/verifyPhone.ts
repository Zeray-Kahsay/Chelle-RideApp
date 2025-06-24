import axios from "axios";

type VerifyPhonePayload = {
  phoneNumber: string;
  code: string;
};

export const verifyPhone = async (data: VerifyPhonePayload) => {
  const response = await axios.post("/api/account/verify-phone", data);
  return response.data;
};
