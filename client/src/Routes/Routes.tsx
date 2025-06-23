import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import RegisterPage from "../pages/RegisterPage";
import RegisterCustomer from "../componenets/Account/Register/RegisterCustomer";
import RegisterDriverStep1 from "../componenets/Account/Register/RegisterDriverStep1";
import RegisterDriverStep2 from "../componenets/Account/Register/RegisterDriverStep2";
import RoleSelection from "../componenets/Account/Register/RoleSelection";
import HomePage from "../pages/HomePage";
import Login from "../componenets/Account/Login";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { index: true, element: <HomePage /> },
      { path: "login", element: <Login /> },
      {
        path: "register",
        element: <RegisterPage />,
        children: [
          { path: "role-selection", element: <RoleSelection /> },
          {
            path: "customer",
            element: <RegisterCustomer />,
          },
          { path: "driver-step1", element: <RegisterDriverStep1 /> },
          { path: "driver-step2", element: <RegisterDriverStep2 /> },
        ],
      },
    ],
  },
]);
