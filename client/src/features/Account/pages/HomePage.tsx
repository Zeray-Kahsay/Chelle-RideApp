import { Link } from "react-router-dom";

const HomePage = () => {
  return (
    <div className="flex flex-col items-center justify-center h-screen text-center space-y-6">
      <h1 className="text-4xl font-bold text-blue-600 tracking-wider">
        Welcome to ON~~TIME
      </h1>
      <h2 className="text-xl font-bold text-blue-400 tracking-widest">
        Arrive ON-TIME
      </h2>

      <div className="space-y-4">
        <p className="text-lg tracking-wider">
          Already have an account?{" "}
          <Link
            to="/login"
            className="text-blue-500 hover:underline font-semibold tracking-wider"
          >
            Login here
          </Link>
        </p>

        <p className="text-lg tracking-wider">
          New user?{" "}
          <Link
            to="register/role-selection"
            className="text-green-500 hover:underline font-semibold tracking-wider"
          >
            Register here
          </Link>
        </p>
      </div>
    </div>
  );
};

export default HomePage;
