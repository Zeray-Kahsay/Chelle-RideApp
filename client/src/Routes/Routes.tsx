import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import RegisterPage from "../features/Account/pages/RegisterPage";
import HomePage from "../features/Account/pages/HomePage";
import LoginForm from "../features/Account/components/LoginForm.";
import RoleSelectionForm from "../features/Account/components/RoleSelectionForm";
import RegisterDriverFormStep1 from "../features/Account/components/RegisterDriverFormStep1";
import RegisterDriverFormStep2 from "../features/Account/components/RegisterDriverFormStep2";
import RegisterCustomerPage from "../features/Account/pages/RegisterCustomerPage";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { index: true, element: <HomePage /> },
      { path: "login", element: <LoginForm /> },
      {
        path: "register",
        element: <RegisterPage />,
        children: [
          { path: "role-selection", element: <RoleSelectionForm /> },
          {
            path: "customer",
            element: <RegisterCustomerPage />,
          },
          { path: "driver-step1", element: <RegisterDriverFormStep1 /> },
          { path: "driver-step2", element: <RegisterDriverFormStep2 /> },
        ],
      },
    ],
  },
]);
