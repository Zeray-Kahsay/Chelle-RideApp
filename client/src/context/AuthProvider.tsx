import { jwtDecode, type JwtPayload } from "jwt-decode";
import { createContext, useState, useEffect, useContext } from "react";

import type { ReactNode } from "react";

interface AuthContextType {
  token: string | null;
  user: JwtPayload | null;
  login: (token: string) => void;
  logout: () => void;
}

interface AuthProviderProps {
  children: ReactNode;
}

const AuthContext = createContext<AuthContextType | null>(null);

export const AuthProvider = ({ children }: AuthProviderProps) => {
  const [token, setToken] = useState<string | null>(
    localStorage.getItem("token")
  );
  const [user, setUser] = useState<JwtPayload | null>(null);

  useEffect(() => {
    if (token) {
      const decode = jwtDecode<JwtPayload>(token);
      setUser(decode);
      localStorage.setItem("token", token);
    } else {
      setUser(null);
      localStorage.removeItem("token");
    }
  }, [token]);
  const login = (token: string) => setToken(token);
  const logout = () => setToken(null);
  return (
    <AuthContext.Provider value={{ token, user, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => useContext(AuthContext) as AuthContextType;
// useAuth has been moved to its own file for Fast Refresh compatibility.
