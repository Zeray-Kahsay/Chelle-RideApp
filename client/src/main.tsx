import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./styles/index.css";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { GoogleOAuthProvider } from "@react-oauth/google";
import { AuthProvider } from "./context/AuthProvider.tsx";
import { RouterProvider } from "react-router-dom";
import { router } from "./Routes/Routes.tsx";

const queryClient = new QueryClient();

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <GoogleOAuthProvider clientId={import.meta.env.VITE_GOOGLE_CLIENT_ID}>
      <QueryClientProvider client={queryClient}>
        <StrictMode>
          <AuthProvider>
            <RouterProvider router={router} />
          </AuthProvider>
        </StrictMode>
      </QueryClientProvider>
    </GoogleOAuthProvider>
  </StrictMode>
);
