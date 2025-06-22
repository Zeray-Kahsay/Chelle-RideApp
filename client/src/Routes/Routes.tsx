import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import RegisterPage from "../pages/RegisterPage";
import RegisterCustomer from "../componenets/Register/RegisterCustomer";
import RegisterDriverStep1 from "../componenets/Register/RegisterDriverStep1";
import RegisterDriverStep2 from "../componenets/Register/RegisterDriverStep2";
import RoleSelection from "../componenets/Register/RoleSelection";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
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
