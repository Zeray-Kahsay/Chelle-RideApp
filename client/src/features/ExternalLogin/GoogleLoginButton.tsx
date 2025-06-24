import axios from "axios";
import { useAuth } from "../../context/AuthProvider";
import { GoogleLogin, type CredentialResponse } from "@react-oauth/google";

const GoogleLoginButton = () => {
  const { login } = useAuth();

  const handleSuccess = async (credentialResponse: CredentialResponse) => {
    const { credential } = credentialResponse;
    const response = await axios.post("/auth/google-token-login", credential);
    const { token } = response.data;
    login(token);
  };

  return <GoogleLogin onSuccess={handleSuccess} />;
};

export default GoogleLoginButton;
