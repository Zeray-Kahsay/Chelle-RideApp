import { useAuth } from "../../context/AuthProvider";

const GoogleLogoutButton = () => {
  const { logout } = useAuth();
  return <button onClick={logout}>Logout</button>;
};

export default GoogleLogoutButton;
